using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Zencoder.Test
{
    [TestClass]
    public class EnumLowercaseJsonConverterTest : TestBase
    {
        #region SimpleEnum enum

        public enum SimpleEnum
        {
            Red,
            Green,
            Blue
        }

        #endregion

        [TestMethod]
        public void SimpleEnumTest()
        {
            ExecuteTest("\"red\"", SimpleEnum.Red);
            ExecuteTest("\"green\"", SimpleEnum.Green);
            ExecuteTest("\"blue\"", SimpleEnum.Blue);

            ExecuteTest("\"RED\"", SimpleEnum.Red);
            ExecuteTest("\"GREEN\"", SimpleEnum.Green);
            ExecuteTest("\"BLUE\"", SimpleEnum.Blue);

            ExecuteTest("\"rEd\"", SimpleEnum.Red);
            ExecuteTest("\"Green\"", SimpleEnum.Green);
            ExecuteTest("\"BLUe\"", SimpleEnum.Blue);
        }

        [TestMethod]
        public void SimpleEnumNullableTest()
        {
            ExecuteTest<SimpleEnum?>("\"red\"", SimpleEnum.Red);
            ExecuteTest<SimpleEnum?>("\"green\"", SimpleEnum.Green);
            ExecuteTest<SimpleEnum?>("\"blue\"", SimpleEnum.Blue);

            ExecuteTest<SimpleEnum?>("\"RED\"", SimpleEnum.Red);
            ExecuteTest<SimpleEnum?>("\"GREEN\"", SimpleEnum.Green);
            ExecuteTest<SimpleEnum?>("\"BLUE\"", SimpleEnum.Blue);

            ExecuteTest<SimpleEnum?>("\"rEd\"", SimpleEnum.Red);
            ExecuteTest<SimpleEnum?>("\"Green\"", SimpleEnum.Green);
            ExecuteTest<SimpleEnum?>("\"BLUe\"", SimpleEnum.Blue);
        }

        private static void ExecuteTest<T>(string jsonText, T expectedResult)
        {
            var converter = new EnumLowercaseJsonConverter();
            var result = JsonConvert.DeserializeObject<T>(jsonText, converter);

            Assert.IsInstanceOfType(result, typeof (T));
            Assert.AreEqual(expectedResult, result);
        }
    }
}