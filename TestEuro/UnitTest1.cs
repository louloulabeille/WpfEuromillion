using EuroLib;

namespace TestEuro
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestVersionEuro()
        {
            VersionEuro ver = new("http://localhost/Euro/version.txt");
            HttpClient client = new ();
            string version = ver.GetVersion(client);

            Assert.That(version.Equals("1.0.1"), $"la version doit être identique {version} & 1.0.1");
            //Assert.AreEqual(version ,"1.0.1", $"la version doit être identique {version} & 1.0.0");
            Assert.IsTrue(ver.UrlOk, "Si la connexion se fait la valeur est UrlOk = true");
        }
    }
}