using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntegrationTests.Config
{
    public class TestSettings
    {
        public Uri? ApplicationUrl { get; set; }
        public Uri? LocalApplicationUrl { get; set; }
        public float? TimeoutInternal { get; set; }
        public TestRunType TestRunType {  get; set; }
        public Uri GridUri {  get; set; }
        public Uri ApiUrl {  get; set; }
}

    public enum TestRunType
    {
        Grid,
        Local,
        
    }
}
