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
            string version = ver.GetVersion();
            string versionActuel = "1.0.1";   
            string versionDefault = "1.0.0";
            Assert.Multiple(() =>
            {
                Assert.That(version, Is.EqualTo(versionActuel), $"la version doit être identique {version} & 1.0.1");
                Assert.That(ver.UrlOk, Is.True, "Si URL est valide alors UrlOk = true");
            });
            Assert.Multiple(() =>
            {
                Assert.That(ver.UrlOk, Is.True, "Si URL est valide alors UrlOk = true");
                Assert.That(version, Is.Not.EqualTo(versionDefault), $"la version ne doit pas être identique {version} & {versionDefault} valeur par défaut.");
            });
        }
    }
}