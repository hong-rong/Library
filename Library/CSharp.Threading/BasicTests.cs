using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net;
using System.Linq;
using System.Net.NetworkInformation;

namespace CSharp.Threading
{
    public static class TaskExtension
    {
        public static void HandleExceptions(this Task task)
        {
            task.ContinueWith(ant => Debug.WriteLine(ant.Exception.Message), TaskContinuationOptions.OnlyOnFaulted);
        }
    }

    //Threading in C#, by Joe Albahari
    [TestClass]
    public class BasicTests
    {
        private static readonly object _locker = new object();
        private SemaphoreSlim _sem = new SemaphoreSlim(3);

        #region basic

        public void StartThreadTask()
        {
            Debug.WriteLine("in start thread task");
        }

        [TestMethod]
        public void BasicElementsTest()
        {
            var task = new ThreadStart(StartThreadTask);
            new Thread(task).Start();

            var auto = new AutoResetEvent(false);
            auto.Set(); //only allow next thread calling WaitOne() to be let through
            var auto2 = new EventWaitHandle(false, EventResetMode.AutoReset);

            var manu = new ManualResetEvent(false);
            manu.Set(); //allows any number of threads calling WaitOne() to be let through
            var manu2 = new EventWaitHandle(false, EventResetMode.ManualReset);

            //CountdownEvent can be solved by structured parallelism
            EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.AutoReset, "MyCompany.MyApp.SomeName");
            //for cross-process

            //WaitHandle.WaitAll();
            //WaitHandle.WaitAny();
        }

        #region two way

        private EventWaitHandle _ready = new AutoResetEvent(false);
        private EventWaitHandle _go = new AutoResetEvent(false);
        private string _message;

        [TestMethod]
        public void TwoWaySignalingTest()
        {
            new Thread(Work).Start();
            _ready.WaitOne();
            lock (_locker) _message = "ooo";
            _go.Set();

            _ready.WaitOne();
            lock (_locker) _message = "ahhh";
            _go.Set();

            _ready.WaitOne();
            lock (_locker) _message = null;
            _go.Set();
        }

        private void Work()
        {
            while (true)
            {
                _ready.Set();
                _go.WaitOne();
                lock (_locker)
                {
                    if (_message == null) return;
                    Debug.WriteLine(_message);
                }
            }
        }

        #endregion

        #region producer

        class ProducerConsumerQueue : IDisposable
        {
            private EventWaitHandle _wh = new AutoResetEvent(false);
            private Thread _worker;
            private readonly object _locker = new object();
            private Queue<string> _tasks = new Queue<string>();

            public ProducerConsumerQueue()
            {
                _worker = new Thread(Work);
                _worker.Start();
            }

            public void Enquque(string task)
            {
                lock (_locker) _tasks.Enqueue(task);
                _wh.Set();
            }

            public void Dispose()
            {
                Enquque(null);
                _worker.Join();
                _wh.Close();
            }

            private void Work()
            {
                while (true)
                {
                    string task = null;
                    lock (_locker)
                    {
                        if (_tasks.Count > 0)
                        {
                            task = _tasks.Dequeue();
                            if (task == null) return;
                        }
                        if (task != null)
                        {
                            Debug.WriteLine("Performing task: " + task);
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            _wh.WaitOne();
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void ProduceTest()
        {
            using (ProducerConsumerQueue q = new ProducerConsumerQueue())
            {
                q.Enquque("Hello");
                for (int i = 0; i < 10; i++)
                {
                    q.Enquque("Say " + i);
                }
                q.Enquque("Goodbye!");
            }
        }

        #endregion

        #endregion

        #region using

        #region EAP

        [TestMethod]
        public void EapTest()
        {
            //event-based asnchronous pattern (EAP)
            using (WebClient wc = new WebClient())
            {
                wc.DownloadStringCompleted += (sender, args) =>
                {
                    if (args.Cancelled)
                        Debug.WriteLine("canceled");
                    else if (args.Error != null)
                        Debug.WriteLine("Exception: " + args.Error);
                    else
                    {
                        Debug.WriteLine(args.Result.Length + " chars were downloaded");
                    }
                };
                wc.DownloadStringAsync(
                    new Uri("https://msdn.microsoft.com/en-us/library/system.net.webclient(v=vs.110).aspx"));
            }
            Thread.Sleep(1000000);
        }

        static BackgroundWorker _bw;

        [TestMethod]
        public void BackgroundWorker()
        {
            _bw = new BackgroundWorker();
            _bw.WorkerReportsProgress = true;
            _bw.WorkerSupportsCancellation = true;
            _bw.DoWork += BackgroundWorkerDoWork;
            _bw.RunWorkerCompleted += RunWorkerCompleted;
            _bw.ProgressChanged += ProgressChanged;
            _bw.RunWorkerAsync("message to worker");
            Thread.Sleep(5000);
            if (_bw.IsBusy) _bw.CancelAsync();
            //Console.ReadLine();
            Thread.Sleep(10000);
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine("Reached: " + e.ProgressPercentage + "%");
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) Debug.WriteLine("You canceled!");
            else if (e.Error != null) Console.WriteLine("worker exception: " + e.Error);
            else Debug.WriteLine("complete: " + e.Result);
        }

        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i += 20)
            {
                if (_bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                _bw.ReportProgress(i);
                Thread.Sleep(1000);
            }
            e.Result = 123;
            Debug.WriteLine("In background worker task: " + e.Argument);
        }

        #endregion

        [ThreadStatic]
        private static int _x;

        [TestMethod]
        public void TestToken()
        {
            var cancelSource = new CancellationTokenSource();
            new Thread(() => Work(cancelSource.Token)).Start();
            //cancelSource.Cancel();
        }

        private void Work(CancellationToken cancelToken)
        {
            //cancelToken.WaitHandle.WaitOne();
            if (cancelToken.IsCancellationRequested)
            {
                Debug.WriteLine("canceled!");
                //cancelToken.ThrowIfCancellationRequested();
            }
        }

        [TestMethod]
        public void TestTimer()
        {
            Timer time = new Timer(Tick, "tick...", 500, 1000);
            Thread.Sleep(1000);
            time.Dispose();
        }

        static void Tick(object data)
        {
            Debug.WriteLine(data);
        }


        #endregion

        #region parallel

        #region plink and parallel for & foreach

        [TestMethod]
        public void PlinkTest()
        {
            IEnumerable<int> numbers = Enumerable.Range(3, 100000 - 3);
            var parallelQuery = from n in numbers.AsParallel()
                                where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
                                select n;
            int[] primes = parallelQuery.ToArray();
            Debug.WriteLine(primes.Length);

            "abcdef".AsParallel().Select(c => char.ToUpper(c)).ForAll(Console.WriteLine);
        }

        [TestMethod]
        public void PLinkCallingBlockTest()
        {
            var pings = from site in new[]
            {
                "www.albahari.com",
                "www.linqpad.net",
                "www.oreilly.com",
                "www.takeonit.com",
                "stackoverflow.com",
                "www.rebeccarey.com"
            }
                .AsParallel()
                .WithDegreeOfParallelism(6)
                        let p = new Ping().Send(site)
                        select new
                        {
                            site,
                            Result = p.Status,
                            Time = p.RoundtripTime
                        };
            //Debug.WriteLine(pings.ToArray().Length);
        }

        [TestMethod]
        public void ParallelInvokeTest()
        {
            //Parallel.Invoke(
            //    () => new WebClient().DownloadFile("", ""),
            //    () => new WebClient().DownloadFile("", ""));

            //thread-unsafe
            //var data = new List<string>();
            //Parallel.Invoke(
            //    () => data.Add(new WebClient().DownloadString("")),
            //    () => data.Add(new WebClient().DownloadString("")));

            var data = new ConcurrentBag<string>();
            var options = new ParallelOptions { MaxDegreeOfParallelism = 4 };
            Parallel.Invoke(options,
                () => data.Add(new WebClient().DownloadString("http://www.foo.com")),
                () => data.Add(new WebClient().DownloadString("http://www.far.com")));
            foreach (var d in data)
            {
                Debug.WriteLine(d);
            }
        }

        [TestMethod]
        public void ParallelForTest()
        {
            //Parallel.For(0, 100, Foo);
            //Parallel.ForEach(Enumerable.Range(0, 100), Foo);
            Parallel.ForEach("Hello, world", (c, state, i) =>
            {
                //state.Stop();
                //state.Break();
                Debug.WriteLine(state);
                Debug.WriteLine(c.ToString() + i);
            });
        }

        private void Foo(int i)
        {
            Debug.WriteLine(i);
        }

        #endregion

        #region basic task

        [TestMethod]
        public void BasicTaskTest()
        {
            //Task.Factory.StartNew(() => Debug.WriteLine("Hello from a task!"));

            //var task = Task.Factory.StartNew<string>(() =>
            //{
            //    using (var wc = new WebClient())
            //    {
            //        return wc.DownloadString("http://www.linqpad.net");
            //    }
            //});

            //var task = new Task(() => Debug.WriteLine("Hello"));
            //task.Start();
            //Debug.WriteLine(task);
            int a = 0;
            var task = Task.Factory.StartNew(state => Greet("Hello"), "Greeting");
            Debug.WriteLine(task.AsyncState);
            Debug.WriteLine(a);
            task.Wait();
        }

        private void Greet(string message)
        {
            int b = 0;
            Debug.WriteLine(message);
            Debug.WriteLine(b);
        }

        #endregion

        [TestMethod]
        public void ParentTaskTest()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Debug.WriteLine("parent");
                Task.Factory.StartNew(() =>
                {
                    Debug.WriteLine("detached");
                });
                Task.Factory.StartNew(() =>
                {
                    Debug.WriteLine("child");
                }, TaskCreationOptions.AttachedToParent);
                throw new InvalidOperationException("in parent task");
            });
            Debug.WriteLine("main");
            parent.Wait();
        }

        [TestMethod]
        public void TaskExceptionTest()
        {
            //int x = 0;
            //Task<int> calc = Task.Factory.StartNew(() => 7 / x);
            //try
            //{
            //    Debug.WriteLine(calc.Result);
            //}
            //catch (AggregateException aex)
            //{
            //    Debug.WriteLine(aex.InnerException.Message);
            //}

            TaskCreationOptions opt = TaskCreationOptions.AttachedToParent;
            var parent = Task.Factory.StartNew(() =>
            {
                Task.Factory.StartNew(() =>
                {
                    Task.Factory.StartNew(() => { throw null; }, opt);
                }, opt);
            });

            try
            {
                parent.Wait();
            }
            catch (AggregateException aex)
            {
                Debug.WriteLine(aex);
            }
        }

        [TestMethod]
        public void CancelTaskTest()
        {
            var cancelSource = new CancellationTokenSource();
            CancellationToken token = cancelSource.Token;
            Task task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                token.ThrowIfCancellationRequested();
            }, token);
            cancelSource.Cancel();

            try
            {
                task.Wait();
            }
            catch (AggregateException aex)
            {
                if (aex.InnerException is TaskCanceledException)
                    Debug.WriteLine("Task cancel!");
            }
        }

        [TestMethod]
        public void TaskContinueTest()
        {
            //Task task1 = Task.Factory.StartNew(() => Debug.WriteLine("antecedant.."));
            //Task task2 = task1.ContinueWith(ant => Debug.WriteLine("...continuation"));

            //Task.Factory.StartNew(() => 8)
            //    .ContinueWith(ant => ant.Result * 2)
            //    .ContinueWith(ant => Debug.WriteLine(ant.Result));

            //var continuation = Task.Factory.StartNew(() => { throw null; })
            //                .ContinueWith(ant =>
            //                {
            //                    if (ant.Exception != null) throw ant.Exception;
            //                });
            //continuation.Wait();

            //Task task1 = Task.Factory.StartNew(() => { throw null; });
            ////Task error = task1.ContinueWith(ant => Debug.WriteLine(ant.Exception), TaskContinuationOptions.OnlyOnFaulted);
            //task1.HandleExceptions();
            //Task ok = task1.ContinueWith(ant => Debug.WriteLine("success"), TaskContinuationOptions.NotOnFaulted);
            //ok.Wait();

            //var task1 = Task.Factory.StartNew(() => Debug.WriteLine("X"));
            //var task2 = Task.Factory.StartNew(() => Debug.WriteLine("Y"));
            //Task.Factory.ContinueWhenAll(new[] { task1, task2 }, tasks => Debug.WriteLine("Done: " + tasks.Length));
            CancellationTokenSource cancelSource = new CancellationTokenSource();
            CancellationToken token = cancelSource.Token;
            var task = Task.Factory.StartNew(() =>
            {
                token.WaitHandle.WaitOne();
                Debug.WriteLine("task");
            }, token);
            task.ContinueWith(ant => Debug.WriteLine("X"));
            task.ContinueWith(ant => Debug.WriteLine("Y"));

            //WaitHandle.SignalAndWait();
            //task.Wait();
        }

        [TestMethod]
        public void HandleTaskExceptionTest()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                int[] numbers = { 0 };
                var childFactory = new TaskFactory
                 (TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);

                childFactory.StartNew(() => 5 / numbers[0]);   // Division by zero
                childFactory.StartNew(() => numbers[1]);      // Index out of range
                childFactory.StartNew(() => { throw null; });  // Null reference
            });

            try
            {
                parent.Wait();
            }
            catch (AggregateException aex)
            {
                aex.Flatten().Handle(ex =>
                {
                    if (ex is DivideByZeroException)
                    {
                        Debug.WriteLine("Divide by zero");
                        return true;
                    }
                    return false;
                });
            }
        }

        #endregion

        #region collection

        [TestMethod]
        public void ConBagTest()
        {
            var missSpelings = new ConcurrentBag<int>();
            int a;
            missSpelings.TryTake(out a);
        }

        [TestMethod]
        public void TaskCompletionTest()
        {
            //var source = new TaskCompletionSource<int>();
            //new Thread(() =>
            //{
            //    Thread.Sleep(5000);
            //    source.SetResult(123);
            //}).Start();
            //Task<int> task = source.Task;
            //Debug.WriteLine(task.Result);
            var source = new TaskCompletionSource<int>();
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                Debug.WriteLine("int task");
                source.SetResult(111);
            });

            Debug.WriteLine(source.Task.Result);
        }

        [TestMethod]
        public void BlockingCollectionTest()
        {
            for (int i = 0; i < 100; i++)
            {
                int n = i;
                using (var q = new PCQueueWithBlockingCollection(4))
                {
                    q.EnqueueTask(() => Debug.WriteLine(n));
                }
            }
            Thread.Sleep(5000);
        }

        public class PCQueueWithBlockingCollection : IDisposable
        {
            class WorkItem
            {
                public readonly TaskCompletionSource<object> TaskSource;
                public readonly Action Action;
                public readonly CancellationToken? CancelToken;

                public WorkItem(TaskCompletionSource<object> taskSource,
                    Action action, CancellationToken? cancelToken)
                {
                    TaskSource = taskSource;
                    Action = action;
                    CancelToken = cancelToken;
                }
            }

            BlockingCollection<WorkItem> _taskQ = new BlockingCollection<WorkItem>();

            public PCQueueWithBlockingCollection(int workerCount)
            {
                for (int i = 0; i < workerCount; i++)
                {
                    Task.Factory.StartNew(Consume);
                }
            }

            public Task EnqueueTask(Action action)
            {
                return EnqueueTask(action, null);
            }

            public Task EnqueueTask(Action action, CancellationToken? cancelToken)
            {
                var tcs = new TaskCompletionSource<object>();
                _taskQ.Add(new WorkItem(tcs, action, cancelToken));
                return tcs.Task;
            }

            private void Consume()
            {
                foreach (var item in _taskQ.GetConsumingEnumerable())
                {
                    if (item.CancelToken.HasValue && item.CancelToken.Value.IsCancellationRequested)
                    {
                        item.TaskSource.SetCanceled();
                    }
                    else
                    {
                        try
                        {
                            item.Action();
                        }
                        catch (OperationCanceledException ex)
                        {
                            //if(ex.CancellationToken == item.CancelToken)
                            Debug.WriteLine(ex.Message);
                        }
                    }
                }
            }

            public void Dispose()
            {
                _taskQ.CompleteAdding();
            }
        }

        #endregion

        #region p/c

        [TestMethod]
        public void PCTest()
        {
            var tasks = new List<Task<int>>();
            using (var q = new PCQueue(4))
            {
                for (int i = 0; i < 10; i++)
                {
                    int n = i;
                    Task<int> task = q.Enqueue(() => Debug.WriteLine(n));
                    tasks.Add(task);
                }
            }
            Task.WaitAll(tasks.ToArray());
            foreach (Task<int> task in tasks)
            {
                Debug.WriteLine(task.Result);
            }
        }

        public class PCQueue : IDisposable
        {
            class WorkItem
            {
                public readonly TaskCompletionSource<int> TaskSource;
                public readonly Action Action;
                public readonly CancellationToken? CancelToken;
                public WorkItem(TaskCompletionSource<int> taskSource, Action action, CancellationToken? cancelToken)
                {
                    TaskSource = taskSource;
                    Action = action;
                    CancelToken = cancelToken;
                }
            }

            BlockingCollection<WorkItem> _taskQ = new BlockingCollection<WorkItem>();

            public PCQueue(int workerCount)
            {
                for (int i = 0; i < workerCount; i++)
                {
                    Task.Factory.StartNew(Consume);
                }
            }

            public Task<int> Enqueue(Action action)
            {
                return Enqueue(action, null);
            }

            public Task<int> Enqueue(Action action, CancellationToken? cancelToken)
            {
                var tcs = new TaskCompletionSource<int>();
                _taskQ.Add(new WorkItem(tcs, action, cancelToken));
                return tcs.Task;
            }

            public void Consume()
            {
                foreach (var workItem in _taskQ.GetConsumingEnumerable())
                {
                    if (workItem.CancelToken.HasValue && workItem.CancelToken.Value.IsCancellationRequested)
                    {
                        workItem.TaskSource.SetCanceled();
                    }
                    else
                    {
                        try
                        {
                            workItem.Action();
                            workItem.TaskSource.SetResult(Thread.CurrentThread.ManagedThreadId * 1000);
                        }
                        catch (Exception ex)
                        {
                            workItem.TaskSource.SetException(ex);
                        }
                    }
                }
            }

            public void Dispose()
            {
                _taskQ.CompleteAdding();
            }
        }

        #endregion
    }
}