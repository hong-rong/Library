using System;

namespace Lib.Common.UnitTest.Json
{
    class Page
    {
        public virtual Guid Id { get; set; }

        public virtual Guid ProgramId { get; set; }

        public virtual string Url { get; set; }

        public virtual string Title { get; set; }
    }
}
