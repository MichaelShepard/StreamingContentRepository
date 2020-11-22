using System;
using _06_RepositoryPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_RepositoryPattern_Tests
{
    [TestClass]
    public class StreamingContentRepositoryTests
    {

        //Test initialize Method

        private StreamingContentRepository _repo;
        private StreamingContent _content;



        [TestInitialize] // This says that everything right after this must run first

        public void Arrange()
        {

            _repo = new StreamingContentRepository(); // streatming repository field that has conent
            _content = new StreamingContent("Rubber", "A car tyre comes to life with teh power to make people explode and goes on a " +
                "murderous rampage through the Californian desert", "R", 5.8, false, GenreType.Drama ); // added some content

            _repo.AddContentToList(_content); //


        }

        // Add Method Test
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            // Arrange --> setting up the playing field
            StreamingContent content = new StreamingContent(); // sets up a new instance of conent
            content.Title = "Toy Story";


            StreamingContentRepository repository = new StreamingContentRepository();


            // Act --> Get / Run the code we want to test
            repository.AddContentToList(content);
            StreamingContent contentFromDirectory = repository.GetContentByTitle("Toy Story"); 


            //Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(contentFromDirectory);
        
        }

        // Update Method Test

        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange
            //Test Initialize
            StreamingContent newContent = new StreamingContent("Rubber", "A car tyre comes to life with teh power to make people explode and goes on a " +
                "murderous rampage through the Californian desert", "R", 5.8, false, GenreType.RomCom);


            //Act
            bool updateResult = _repo.UpdateExistingContent("Rubber", newContent);

            //Assert
            Assert.IsTrue(updateResult);
        }


        [DataTestMethod]
        [DataRow("Rubber", true)]
        [DataRow("Toy Story", false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(string originalTitle, bool shouldUpdate)
        {
            //Arrange
            //Test Initialize
            StreamingContent newContent = new StreamingContent("Rubber", "A car tyre comes to life with teh power to make people explode and goes on a " +
                "murderous rampage through the Californian desert", "R", 5.8, false, GenreType.RomCom);


            //Act
            bool updateResult = _repo.UpdateExistingContent(originalTitle, newContent);

            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);


        }

        [TestMethod]
        public void DeleteConent_ShouldReturnTrue()
        {

            // Arrange - use the initialize



            //Act

            bool deleteResult = _repo.RemoveContentFromList(_content.Title);


            //Assert
            Assert.IsTrue(deleteResult);

        }
    }
}
