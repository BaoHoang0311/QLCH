using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using DAL;
using Services;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LT_PRODUCT lt = new LT_PRODUCT();
            var sp = lt.doc_danh_Sach();

        }
    }
}
