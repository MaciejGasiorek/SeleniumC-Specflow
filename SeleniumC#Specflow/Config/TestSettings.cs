using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumCsharpSpecflow.Driver.DriverFixture;

namespace SeleniumCsharpSpecflow.Config
{
    public class TestSettings
    {
        public BrowserType BrowserType { get; set; }
        public Uri? ApplicationUrl { get; set; }
        public Uri? LocalApplicationUrl { get; set; }
        public float? TimeoutInternal { get; set; }
        public TestRunType TestRunType {  get; set; }
        public Uri GridUri {  get; set; }
    }

    public enum TestRunType
    {
        Grid,
        Local,
        
    }
}
