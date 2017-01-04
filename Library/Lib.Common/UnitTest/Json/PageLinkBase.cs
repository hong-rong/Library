using System;

namespace Lib.Common.UnitTest.Json
{
    class PageLinkBase
    {
        public virtual Guid Id { get; set; }

        public virtual Guid ProgramId { get; set; }

        public virtual string AnchorText { get; set; }

        public virtual PageLinkState PageLinkState { get; set; }

        public virtual int Order { get; set; }

        public virtual Guid? PageLinkContainerId { get; set; }

        public virtual string PageLinkContainerName { get; set; }
    }
}
