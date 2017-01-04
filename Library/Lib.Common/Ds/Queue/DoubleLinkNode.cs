using Lib.Common.Ds.Common;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Ds.Queue
{
    public class DoubleLinkNode<T> : LinkNodeBase<T, DoubleLinkNode<T>>
    {
        public DoubleLinkNode<T> Previous { get; set; }
    }
}
