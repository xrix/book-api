using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buku.API.Mappings;
using AutoMapper;

namespace Buku.Tests
{
    [TestClass]
    public class BukuAPIMapperTest
    {

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            AutoMapperConfig.Initialize(); // initialize automapper
        }

        [TestMethod]
        public void BukuAPIMapper_AutomapperConfigurationIsValid()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
