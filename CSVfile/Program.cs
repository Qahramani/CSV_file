using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CSVfile
{
    internal class Program
    {
        
        static void Main()
        {
            string[] file = ReadFile("values.csv");
            List<Person> people = new List<Person>();

            people = GetPeople(file);
            PrintPeople(people);
            Console.ReadKey();
        }
        /// <summary>
        /// Read from File and return lines
        /// </summary>
        /// <param name="filename">Path to file</param>
        /// <returns>String array of file lines</returns>
        static string[] ReadFile(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            return lines;
        }
        /// <summary>
        /// Get people from file
        /// </summary>
        /// <param name="file">File lines</param>
        /// <returns>List of people</returns>
        static List<Person> GetPeople(string[] file)
        {
            Dictionary<int,List<string>> file_items = new Dictionary<int,List<string>>();
            List<Person> people = new List<Person>();
            //get items from file
            for(int i = 0;i < file.Length; i++)
                file_items.Add(i, GetItems(file[i]));
           //create person objects
            for( int i = 1;  i < file.Length; i++)
            {
                Person p;
                string firtname = "", lastname = "", occupation = "" ;
                int age = 0;
                for(int j = 0; j < file_items[0].Count(); j++)
                {
                    // check what value we are on
                    switch (file_items[0][j].ToLower())
                    {
                        case "firstname":
                            firtname = file_items[i][j];
                            break;
                        case "lastname":
                            lastname = file_items[i][j];
                            break;
                        case "occupation":
                            occupation = file_items[i][j];
                            break;
                        case "age":
                            age = int.Parse(file_items[i][j]);
                            break;
                        default:
                            Console.WriteLine($"Head '{file_items[0][j]}' is not valid header");
                            break;
                    }
                }
                p = new Person(firtname, lastname, occupation, age);
                people.Add(p);
            }

            //return new instance of people
            return new List<Person>(people);
        }
        /// <summary>
        /// Get items from line
        /// </summary>
        /// <param name="line">Line</param>
        /// <returns>List of items</returns>
        static List<string> GetItems(string line)
        {
            string current_word = "";
            List<string> items = new List<string>();
            // split line
            foreach (char item in line)
            {
                if(item == ',')
                {
                    if(current_word != "")
                    {
                        items.Add(current_word);
                        current_word = "";
                    }
                }
                else
                {
                    current_word += item.ToString();
                }

            }
            // add left over items if it exists
            if(current_word != "") items.Add(current_word);

            //return new instance of items list
            return new List<string> (items);
        }
        /// <summary>
        /// Print information about every person in people
        /// </summary>
        /// <param name="people">List of people</param>
        static void PrintPeople(List<Person> people)
        {
            foreach(Person p in people)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName} is {p.Age.ToString()} years old and works as a(n) {p.Ocupation}");
            }
        }
    }
}
