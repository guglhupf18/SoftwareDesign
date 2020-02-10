using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        
        public void Test1()
        {
            string mailaddress = "ich@provider.com";
            bool result = UnitTest1.Program.IsEmailAddress(mailaddress);
            Assert.True(result, mailaddress + " nicht als Email-Adresse erkannt, obwohl korrekt.");
        }
    }
}
