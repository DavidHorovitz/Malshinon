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



        public People(string _First_Name, string _Last_Name)
        {
            first_name = _First_Name;
            last_name = _Last_Name;
        }
        DAL dAL = new DAL();

        public bool checkMalshin(string nameOfMalshim, string nameOfTarget)
        {
            foreach (var name in dAL.getAllNames())
            {
                if ( name== nameOfMalshim)
                {
                    return true;
                }
            }
            dAL.InsertPeople(nameOfMalshim, nameOfTarget);
            return false;
        }
        public bool checkTarget(string nameOfMalshim, string nameOfTarget)
        {
            foreach (var name in dAL.getAllNames())
            {
                if (name == nameOfTarget)
                {
                    return true ;
                }
            }
            dAL.InsertPeople(nameOfMalshim, nameOfTarget);
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
