using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeServiceTests
    {
        [TestMethod]
        public void GetJoke_ValidJoke_SuccessfulReturn()
        {
            JokeService instance = new JokeService();
            string expResult = "This is a joke";
            instance.SetJoke(expResult);
            string result = instance.GetJoke();
            Assert.Equals(expResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetJoke_NullJoke_ThrowsNullException()
        {
            JokeService? instance;
            instance = new JokeService();
            string result = instance.GetJoke();
        }

    }

}
