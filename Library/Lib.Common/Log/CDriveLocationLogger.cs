namespace Lib.Common.Log
{
    public class CDriveLocationLogger : MyLogger
    {
        public CDriveLocationLogger()
            : this(@"C:\")
        { }

        public CDriveLocationLogger(string filePath)
            : base(filePath)
        { }
    }
}
