using FavouriteAccounts.ui.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FavouriteAccounts.ui.Tests
{
    [TestClass]
    public class IBANRetrieverUnitTest
    {
        [TestMethod]
        public void WhenCorrectBankAccountProvided_IBANCodeShouldBeTakenFromProperPoositions()
        {
            // arrange
            var ibanRetriever = new IBANRetriever();

            // act
            var ibanCode = ibanRetriever.RetrieveIBANCodeFromAcccountNumber("01234567890011223344");

            // assert
            Assert.AreEqual("4567", ibanCode);
        }

        [TestMethod]
        public void WhenBankAccountProvidedWithImproperLength_ExceptionShouldBeThrown()
        {
            // arrange
            var ibanRetriever = new IBANRetriever();
            var exceptionThrown = false;

            // act
            try
            {
                var ibanCode = ibanRetriever.RetrieveIBANCodeFromAcccountNumber("0123456789001122334455");
            }
            catch(Exception exc)
            {
                exceptionThrown = true;
            }

            // assert
            Assert.AreEqual(true, exceptionThrown);
        }
    }
}
