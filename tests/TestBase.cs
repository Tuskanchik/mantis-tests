using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace mantis_tests
{
    public class TestBase
    {
        public bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;
        
        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        [TearDown]
        public void TeardownTest()
        {
            //app.Auth.Logout();
        }
    }
}
