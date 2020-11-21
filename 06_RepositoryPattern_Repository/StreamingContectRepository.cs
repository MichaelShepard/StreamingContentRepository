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




        // Update



        // Delete

    }
}
