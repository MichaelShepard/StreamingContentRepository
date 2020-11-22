using System;
using _06_RepositoryPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_RepositoryPattern_Tests
{
    [TestClass]
    public class StreamingContentTests
    {
        [TestMethod]
        public void SetTitle_ShouldSetCorrectString()
        {

            StreamingContent content = new StreamingContent(); //content is a new instance, creating a blank slate

            content.Title = "Toy Story";  // assigning a name

            string expected = "Toy Story";
            string actual = content.Title;

            Assert.AreEqual(expected, actual); // this is what we are plugging in to see if they match
        }
    }
}
