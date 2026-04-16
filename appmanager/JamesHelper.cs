using System;
using System.Collections.Generic;
using System.Text;
using MinimalisticTelnet;

namespace mantis_tests
{
    public class JamesHelper : HelperBase
    {
        public JamesHelper(ApplicationManager manager) : base(manager) { }

        public void Add(AccountData account)
        {
            if (Verify(account))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("adduser " + account.Name + " " + account.Password);
            //System.Console.Out.WriteLine(telnet.Read());
            System.Diagnostics.Trace.WriteLine(telnet.Read());

        }

        public void Delete(AccountData account)
        {
            if (!Verify(account))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("deluser " + account.Name);
            //System.Console.Out.WriteLine(telnet.Read());
            System.Diagnostics.Trace.WriteLine(telnet.Read());
        }



        public bool Verify(AccountData account)
        {
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("verify " + account.Name);
            String s = telnet.Read();
            //System.Console.Out.WriteLine(s);
            //System.Diagnostics.Trace.WriteLine(s);
            //Console.Out.Write(s);
            System.Diagnostics.Debug.WriteLine(s);
            return !s.Contains("User " + account.Name + " does not exist\r\n");
        }

        private TelnetConnection LoginToJames()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            //System.Console.Out.WriteLine(telnet.Read());
            System.Diagnostics.Trace.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            //System.Console.Out.WriteLine(telnet.Read());
            System.Diagnostics.Trace.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            //System.Console.Out.WriteLine(telnet.Read());
            System.Diagnostics.Trace.WriteLine(telnet.Read());
            return telnet;
        }
    }
}
