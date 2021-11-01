using NUnit.Framework;
using DummyCDCI.Controllers;

namespace DummyCDCI.Test
{
    [TestFixture]
    public class Tests
    {
        private TestController controller;

        [SetUp]
        public void Setup()
        {
            controller = new TestController();
        }

        [Test]
        public void Test1()
        {
            Assert.IsTrue(controller.GetTest() == 1 || controller.GetTest() == 1 || controller.GetTest() == 1);
        }
    }
}