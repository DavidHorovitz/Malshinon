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

        public string getFirstNameOfReporter ()
        {
            Console.WriteLine("'enter your first name");
            string first_name = Console.ReadLine();
            validation(first_name);
            return first_name;
        }
        public string getLastNameOfReporter()
        {
            Console.WriteLine("'enter your last name");
            string last_name = Console.ReadLine();
            validation(last_name);
            return last_name;
        }
        public string getFirstNameOfTarget()
        {
            Console.WriteLine("'enter target first name");
            string first_name = Console.ReadLine();
            validation(first_name);
            return first_name;
        }
        public string getLastNameOfTarget()
        {
            Console.WriteLine("'enter target last name");
            string last_name = Console.ReadLine();
            validation(last_name);
            return last_name;
        }

        public string getInformation()
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
           
            string get_FirstNameOfReporter = getFirstNameOfReporter();
            string get_FirstNameOfTarget = getFirstNameOfTarget();

            bool reporter = people.checkMalshin(get_FirstNameOfReporter);
            bool target = people.checkTarget(get_FirstNameOfTarget);

            if (reporter && target)
            {
                dAL.insertReports(get_FirstNameOfReporter, get_FirstNameOfTarget, getInformation());
            }
            else if (reporter)
            {
                dAL.InsertPeople(get_FirstNameOfTarget, getLastNameOfTarget());
                dAL.insertReports(get_FirstNameOfReporter, get_FirstNameOfTarget, getInformation());
            }
            else if (target)
            {
                dAL.InsertPeople(get_FirstNameOfReporter, getLastNameOfReporter());
                dAL.insertReports(get_FirstNameOfReporter, get_FirstNameOfTarget, getInformation());
            }
            else
            {
                dAL.InsertPeople(get_FirstNameOfReporter, getLastNameOfReporter());
                dAL.InsertPeople(get_FirstNameOfTarget, getLastNameOfTarget());
                dAL.insertReports(get_FirstNameOfReporter, get_FirstNameOfTarget, getInformation());
            }
        }
    }
}
