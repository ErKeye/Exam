using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question1;

namespace Question1Test
{
    [TestClass]
    public class EncoderTest
    {
        [TestMethod]
        public void TestSize0()
        {
            TestNSize(string.Empty);
        }

        public void TestSizeNoMod()
        {
            TestNSize("123");
        }

        public void TestSizeNoMod1()
        {
            TestNSize("1234");
        }

        public void TestSizeNoMod2()
        {
            TestNSize("12345");
        }
        public void TestDefault()
        {
            TestNSize("This is a test string");
        }


        public void TestNSize(string to_encode)
        {
            Program.InitTranscodeArray();
            string encoded, decoded;
            encoded = Program.Encode(to_encode);
            decoded = Program.Decode(encoded);
            Assert.IsTrue(to_encode != encoded);
            Assert.IsTrue(to_encode == decoded);
        }
    }
}
