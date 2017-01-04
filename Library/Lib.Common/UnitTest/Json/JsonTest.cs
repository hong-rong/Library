using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Lib.Common.UnitTest.Json
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        public void SerializeToJsonTest()
        {
            var pl = new PageLink
                {
                    Id = new Guid("D4B1B2C0-84C7-4E24-B96A-776AF73CA4B1"),
                    AnchorText = "Super 10 Sparkle Top",
                    PageLinkContainerId = new Guid("B576FCA2-5FB5-4E7C-AF41-63786909C8DB"),
                    SourcePage = new Page { Id = new Guid("584B2705-11A4-4001-A5D2-01008BC95962") },
                    TargetPage = new Page { Id = new Guid("22786F99-BBC7-48B5-A48C-01300E3D5111") },
                };

            var value = JsonConvert.SerializeObject(pl);

            Debug.WriteLine(value);


        }
    }
}
