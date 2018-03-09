using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFeaturesOverview
{
    [TestClass]
    public class InitiaizersDemo
    {
        //  collection initializer (existed in previous verions) 
        private List<string> messages = new List<string>
        {
            "Page not Found",
            "Page moved, but left a forwarding address.",
            "The web server can't come out to play today."
        };

        //  dictionary initializer (new in c# 6)
        private Dictionary<string, string> _webErrors = new Dictionary<string, string>
        {
            ["404"] = "Page not Found",
            ["302"] = "Page moved, but left a forwarding address.",
            ["500"] = "The web server can't come out to play today."
        };
    }


}
