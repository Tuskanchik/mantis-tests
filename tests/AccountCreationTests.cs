using NUnit.Framework;

namespace mantis_tests

{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [Test]
        public void TestAccountRegistration()
        {
            String baseName = "testuser12";

            AccountData account = new AccountData()
            {
                
                Name = baseName,
                Password = "password",
                Email = baseName + "@localhost.localdomain"
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }
    }
}