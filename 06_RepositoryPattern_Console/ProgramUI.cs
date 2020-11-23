using _06_RepositoryPattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RepositoryPattern_Console
{
    class ProgramUI
    {

        private StreamingContentRepository _contentRepo = new StreamingContentRepository(); // field names use the underscore with Camel Case
        
        
        
        // Method that runs/starts the UI part of the application
        public void Run() //entry into this class; make it public so somebody can call this method; control the flow or access to the UI
        {
            SeedContentList(); // runs one time to seed list of titles
            Menu();
        }


        //Menu Method
        private void Menu()
        {

            bool keepRunning = true;

            while (keepRunning)

            {

                //Display options to the user
                Console.WriteLine("Select a menu option: \n" +
                    "1. Create New Content \n" +
                    "2. View All Conent \n" +
                    "3. View Content By Title \n" +
                    "4. Update Existing Content \n" +
                    "5. Delete Existing Content \n" +
                    "6. Exit");

                //Get the users input
                string input = Console.ReadLine();

                //Evaluate users input and act accordingly
                switch (input)
                {
                    case "1":
                        // Create new conent
                        CreateNewContent();
                        break;
                    case "2":
                        // View all content
                        DisplayAllContent();
                        break;
                    case "3":
                        // View content by title
                        DisplayConentByTitle();
                        break;
                    case "4":
                        // Update existing content
                        UpdateExistingContent();
                        break;
                    case "5":
                        // Delete existing content
                        DeleteExistingContent();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("Good Bye!!");
                        keepRunning = false; // breaks while loop
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Press any key to conitnue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        // Create new StreamingContent
        private void CreateNewContent()
        {
            Console.Clear();  // clears the content
            StreamingContent newContent = new StreamingContent(); // Creates a blank streamingcontent object; we can then immediately assign them upon user input

            // Title
            Console.WriteLine("Enter the title for the content:");
            newContent.Title = Console.ReadLine();

            // Description
            Console.WriteLine("Enter the description for the new content: ");
            newContent.Description = Console.ReadLine();


            // Maturity Rating
            Console.WriteLine("Enter the rating for the content (G, PG, PG-13, etc): ");
            newContent.MaturityRating = Console.ReadLine();

            // Star Rating
            Console.WriteLine("Enter the star count for the content (5.8, 10, 1.5, etc: ");
            string starAsString = Console.ReadLine();
            newContent.StarRating = double.Parse(starAsString);

            // Is family friendly
            Console.WriteLine("Is this content family friendly (y/n): ");
            string familyFriendlyString = Console.ReadLine().ToLower(); //converts to lowercase

            if (familyFriendlyString == "y")
            {
                newContent.IsFamilyFriendly = true;
            }
            else
            {
                newContent.IsFamilyFriendly = false;
            }


            // Genre Type

            /*Horror =1, //resets starting value from 0 t0 1
            RomCom,
            SciFi,
            Documentary,
            Bromance,
            Drama, 
            Action*/
            // Setting the enum numbers to input
            Console.WriteLine("Enter the Genre Number: /n" +
                "1. Horror /n" +
                "2. RomCom /n" +
                "3. SciFir /n" +
                "4. Documentary /n" +
                "5. Bromance /n" +
                "6. Drama /n" +
                "7. Action");

            string genreAsString = Console.ReadLine();
            int genreAsInt = int.Parse(genreAsString);
            newContent.TypeOfGenre = (GenreType)genreAsInt; // I have a number genreAsInt and an Enum GenreType, I am going to cast the int to the enum which is a genre type; 

            _contentRepo.AddContentToList(newContent);

        }

        // View current StreamingConent that is saved
        private void DisplayAllContent()
        {
            Console.Clear();
            List<StreamingContent> listOfConent = _contentRepo.GetContentList();

            foreach(StreamingContent content in listOfConent)
            {
                Console.WriteLine($"Title: {content.Title}\n" + 
                    $"Desc: {content.Description}");
            }

        }

        // View existing content by title
        private void DisplayConentByTitle()
        {
            Console.Clear();
            // Prompt the user to give me a title
            Console.WriteLine("Enter the title of the content you'd like to see:");

            // Get the user's input
            string title = Console.ReadLine();

            // Find the content by that title
            StreamingContent content =_contentRepo.GetContentByTitle(title);

            // Display said content if it is not null
            if (content != null)
            {
                Console.WriteLine($"Title: {content.Title} \n" +
                    $"Desc: {content.Description} \n " +
                    $"Maturity Rating: {content.MaturityRating} \n" +
                    $"Starts: {content.StarRating} \n" +
                    $"Is Family Friendly: {content.IsFamilyFriendly} \n" +
                    $"Genre: {content.TypeOfGenre}");
            } else {
                Console.WriteLine("I could not find that title.");
            }

        }

        // Update existing content
        private void UpdateExistingContent()
        {

        }

        // Delete existing content
        private void DeleteExistingContent()
        {

        }


        //Seed Method
        private void SeedContentList()
        {
            StreamingContent sharknado = new StreamingContent("Sharknado", "Tornado, but with sharks", "TV-14", 3.3, true, GenreType.Action);
            StreamingContent theRoom = new StreamingContent("The Room", "Banker's life gets turned upside down", "R", 3.7, false, GenreType.Drama);
            StreamingContent rubber = new StreamingContent("Rubber", "Car tire comes to life and goes on a killing spree.", "R", 5.8, false, GenreType.Documentary);

            _contentRepo.AddContentToList(sharknado);
            _contentRepo.AddContentToList(theRoom);
            _contentRepo.AddContentToList(rubber);
        }
    }
}
