using TestFramework.Config;
using TestFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestFramework.Base
{
    public class BaseStep : Base
    {
        public BaseStep(SeleniumDriver webDriverConfig) : base(webDriverConfig)
        {
        }

        //in case of requiring some methods to steps, this class can be omited and be inherited direct from base but maybe some methods just for steps will be put
    }
}
