using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RepositoryPattern_Repository
{
    public class StreamingContentRepository
    {
        //Field
        private List<StreamingContent> _listOfContent = new List<StreamingContent>(); // of our CRUD methods can use the same Lists by way of a field


        // Create

        // use void to follow single purpose responsiblity; don't need to return anything bc we are just adding something to the list.
        // public so anybody can see it
        // what do we want to do with the content object witha  StreamingContent class
        // need to give it a StreamingContect 

        public void AddContentToList(StreamingContent content)
        {
            _listOfContent.Add(content); //use underscore to show this is field and not a property; use camelCase
        }
             

        // Read

        public List<StreamingContent> GetContentList()
        {
            return _listOfContent; // when callinng this method, you can access the list but only when you call this method
        }


        // Update

        public bool UpdateExistingContent (string originalTitle, StreamingContent newContent)
        {
            //Find content
            StreamingContent oldContent = GetContentByTitle(originalTitle);



            // Update content

            if(oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.MaturityRating = newContent.MaturityRating;
                oldContent.IsFamilyFriendly = newContent.IsFamilyFriendly;
                oldContent.StarRating = newContent.StarRating;
                oldContent.TypeOfGenre = newContent.TypeOfGenre;
                return true;  //this gives us feedback that something has been done.
            } else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveContentFromList(string title)
        {
            StreamingContent content = GetContentByTitle(title); //new StreamingContent object called content; going to call method GetContentByTitle

            if(content == null) // usese object content that is either True or False
            {
                return false;
            }

            int initialCount = _listOfContent.Count; // counts the number of items on the list
            _listOfContent.Remove(content); // actually removes the content from list

            if (initialCount > _listOfContent.Count) // verifies that the item has been removed
            {
                return true;

            } else
            {
                return false;
            }

        }


        //Helper Method

        public StreamingContent GetContentByTitle (string title)
        {
            foreach (StreamingContent content in _listOfContent) // for each item (_listOfConent) I am going to validate title against
            {
                if(content.Title == title.ToLower())
                {
                    return content;
                }
            }

            return null; //bc it is a reference type we can return a null
        }
    }
}
