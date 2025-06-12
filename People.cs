using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Prepare;

namespace Malshinon
{

    internal class People
    {
        int id;
        string secret_code;
        
        string first_name;
        string last_name;
        string type;
        public int num_reports;
        public int num_mentions;

        //Maneger maneger = new Maneger();

        //public People()
        //{
        //    first_name = maneger.getFirstNameOfReporter();
        //    last_name = maneger.getLastNameOfReporter();
        //}
        DAL dAL = new DAL();

        public bool checkPersonIfExist(string firstName)
        {
            foreach (var name in dAL.getAllNames())
            {
                if ( name== firstName)
                {
                    return true;
                }
            }
            return false;
        }
       





        //public int checkIfNameExists()
        //{
        //    string quary = $"SELECT `id` FROM `people` WHERE `first_name`={First_Name} AND `last_name`={Last_Name} ";
        //    cmd = new MySqlCommand(quary, _conn);
        //    cmd.ExecuteNonQuery();
        //    reader = cmd.ExecuteReader();


        //    if (reader.Read())
        //    {
        //        return reader.Read();
        //    }
        //    else
        //    {
        //        return;
        //    }



    }   //}
}
