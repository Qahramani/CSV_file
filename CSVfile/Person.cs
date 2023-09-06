using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVfile
{
    internal class Person
    {

        private string _firstname = "";
        private string _lastname = "";
        private string _occupation = "";
        private int _age = 0;

        public string FirstName { get { return _firstname; } }
        public string LastName { get { return _lastname; } }
        public string Ocupation { get { return _occupation; } }
        public int Age { get { return _age; } }


        public Person(string firstname, string lastname, string ocupation, int age)
        {
            _firstname = firstname;
            _lastname = lastname;
            _occupation = ocupation;
            _age = age;
        }
    }
}
