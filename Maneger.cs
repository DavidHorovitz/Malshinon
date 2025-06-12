using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Maneger
    {
        People people = new People();
        DAL dAL = new DAL();

        public string setFirstNameOfReporter ()
        {
            Console.WriteLine("'enter your first name");
            string first_name = Console.ReadLine();
            validation(first_name);
            return first_name;
        }
        public string setLastNameOfReporter()
        {
            Console.WriteLine("'enter your last name");
            string last_name = Console.ReadLine();
            validation(last_name);
            return last_name;
        }
        public string setFirstNameOfTarget()
        {
            Console.WriteLine("'enter target first name");
            string first_name = Console.ReadLine();
            validation(first_name);
            return first_name;
        }
        public string setLastNameOfTarget()
        {
            Console.WriteLine("'enter target last name");
            string last_name = Console.ReadLine();
            validation(last_name);
            return last_name;
        }

        public string setInformation()
        {
            Console.WriteLine("please enter the information");
            string infomation = Console.ReadLine();
            validation(infomation);
            return infomation;
        }

        public string validation(string text)
        {
                while (text == "")
                {
                    Console.WriteLine("enter again");
                    text = Console.ReadLine();
                }
                return text;
          
        }
        public void starter ()
        {
           
            string get_FirstNameOfReporter = setFirstNameOfReporter();
            string get_FirstNameOfTarget = setFirstNameOfTarget();


            bool reporter = people.checkPersonIfExist(get_FirstNameOfReporter);
            bool target = people.checkTarget(get_FirstNameOfTarget);

            if (reporter && target)
            {
                dAL.insertReports(get_FirstNameOfReporter, get_FirstNameOfTarget, setInformation());
            }
            else if (reporter)
            {
                dAL.InsertPeople(get_FirstNameOfTarget, setLastNameOfTarget(),"target");
                dAL.insertReports(get_FirstNameOfReporter, get_FirstNameOfTarget, setInformation());
            }
            else if (target)
            {
                dAL.InsertPeople(get_FirstNameOfReporter, setLastNameOfReporter(),"reporter");
                dAL.insertReports(get_FirstNameOfReporter, get_FirstNameOfTarget, setInformation());
            }
            else
            {
                dAL.InsertPeople(get_FirstNameOfReporter, setLastNameOfReporter(), "reporter");
                dAL.InsertPeople(get_FirstNameOfTarget, setLastNameOfTarget(),"target");
                dAL.insertReports(get_FirstNameOfReporter, get_FirstNameOfTarget, setInformation());
            }
        }
    }
}
