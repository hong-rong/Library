using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm.String.StringSorts
{
    [DebuggerDisplay("Name = {Name}, Secion = {Section}")]
    public struct NameSection
    {
        public string Name { get; set; }
        public int Section { get; set; }
    }

    public class TestSample
    {
        public static NameSection[] NameSections = new NameSection[] 
        {
            new NameSection(){Name="Anderson", Section= 2},
            new NameSection(){Name="Brown",  Section= 3 },
            new NameSection(){Name="Davis",  Section= 3 },
            new NameSection(){Name="Garcia",  Section= 4},
            new NameSection(){Name="Harris",  Section= 1},
            new NameSection(){Name="Jackson",  Section= 3},
            new NameSection(){Name="Johnson",  Section= 4},
            new NameSection(){Name="Jones",  Section= 3 },
            new NameSection(){Name="Martin",  Section= 1 },
            new NameSection(){Name="Martinez", Section= 2 },
            new NameSection(){Name="Miller",  Section= 2 },
            new NameSection(){Name="Moore",  Section= 1 },
            new NameSection(){Name="Robinson",  Section= 2},
            new NameSection(){Name="Smith",  Section= 4 },
            new NameSection(){Name="Taylor",  Section= 3 },
            new NameSection(){Name="Thomas",  Section= 4 },
            new NameSection(){Name="Thompson", Section=  4},
            new NameSection(){Name="White",  Section= 2 },
            new NameSection(){Name="Williams",  Section= 3},
            new NameSection(){Name="Wilson",  Section= 4}
        };

        public static string[] License = new string[] 
        {
            "4PGC938",
            "2IYE230",
            "3CIO720",
            "1ICK750",
            "1OHV845",
            "4JZY524",
            "1ICK750",
            "3CIO720",
            "1OHV845",
            "1OHV845",
            "2RLA629",
            "2RLA629",
            "3ATW723"
        };

        public static string[] Target = new string[] 
        {
            "she",
            "sells",
            "seashells",
            "by",
            "the",
            "sea",
            "shore",
            "the",
            "shells",
            "she",
            "sells",
            "are",
            "surely",
            "seashells"
        };
    }
}
