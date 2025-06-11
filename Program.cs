using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Program
    {

        static void Main(string[] args)
        {
            DAL dAL = new DAL();
            //Console.WriteLine(dAL.GetNum_reports());
            //Console.WriteLine(dAL.GetNum_mentions());


            //Maneger maneger = new Maneger();
            //maneger.starter();
            //Console.WriteLine(dAL.GetType("ff"));
            dAL.GetNum_reports("ely");

        }
    }
}
