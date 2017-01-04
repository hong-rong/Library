namespace Lib.Common.UnitTest.Json
{
    class PageLink : PageLinkBase
    {
        public virtual Page SourcePage { get; set; }

        public virtual Page TargetPage { get; set; }
    }
}
