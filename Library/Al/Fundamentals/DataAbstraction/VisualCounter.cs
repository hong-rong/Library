using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.DataAbstraction
{
    public class VisualCounter
    {
        private readonly int _maximumOperations;
        private readonly int _maximumAbsoluteOperations;
        private int _operationCounter;
        private int _totalOperationCounter;

        public VisualCounter(int N, int Max)
        {
            _maximumOperations = N;
            _maximumAbsoluteOperations = Max;
            _operationCounter = 0;
        }

        public void Increment()
        {
            ++_operationCounter;

            if (Math.Abs(_operationCounter) > _maximumAbsoluteOperations)
            {
                --_operationCounter;
                throw new InvalidOperationException(string.Format("Operation exceed maxximum value: {0}", _maximumAbsoluteOperations));
            }

            ++_totalOperationCounter;

            if (_totalOperationCounter > _maximumOperations)
            {
                --_totalOperationCounter;
                throw new InvalidOperationException();
            }
        }

        public void Decrement()
        {
            --_operationCounter;

            if (Math.Abs(_operationCounter) > _maximumAbsoluteOperations)
            {
                ++_operationCounter;
                throw new InvalidOperationException(string.Format("Operation exceed maxximum value: {0}", _maximumAbsoluteOperations));
            }

            ++_totalOperationCounter;

            if (_totalOperationCounter > _maximumOperations)
            {
                --_totalOperationCounter;
                throw new InvalidOperationException();
            }
        }

        public int Tally()
        {
            return _operationCounter;
        }

        public override string ToString()
        {
            return string.Format("Current counter: {0}, total operations: {1}", _operationCounter, _totalOperationCounter);
        }
    }
}
