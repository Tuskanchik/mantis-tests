using NUnit.Framework;

namespace mantis_tests

{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [Test]
        public void TestAccountRegistration()
        {
            String baseName = "sa";

            AccountData account = new AccountData()
            {
                
                Name = baseName,
                Password = "secret",
                Email = baseName + "@localhost.localdomain"
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }
    }
}