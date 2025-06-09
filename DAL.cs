using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon
{
    internal class DAL
    {
        private string connStr = "server=127.0.0.1;user=root;password=;database=malshinon";
        private MySqlConnection _conn;
        private MySqlCommand cmd = null;
        private MySqlDataReader reader = null;
        public People People;
        public Intelreports intelreports;
        

        public MySqlConnection openConnection()
        {
            if (_conn == null)
            {
                _conn = new MySqlConnection(connStr);
            }

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();

                Console.WriteLine("Connection successful.");
            }

            return _conn;
        }

        public void closeConnection()
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
                _conn = null;
            }
        }

        public DAL()
        {
            try
            {
                openConnection();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }

        }
        public void InsertPeople(string firstName, string lastName)
        {
            //People people = new People(firstName, lastName);

            try
            {
                openConnection();
                string query = "INSERT INTO People (first_name, last_name, secret_code, type, num_reports, num_mentions) " +
                               "VALUES (@FirstName, @LastName, @SecretCode, @Type, 0, 0)";
                MySqlCommand cmd = new MySqlCommand(query, _conn);

                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@SecretCode",GetCecret_code());
                cmd.Parameters.AddWithValue("@Type", GetType());

                cmd.ExecuteNonQuery();
                insertReports("malshin", "target","aaaaaaaa");

            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                Console.WriteLine($"Duplicate entry: {firstName} {lastName} already exists.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
            finally
            {
                closeConnection();
            }
        }
       
            

        
        public string GetCecret_code()
        {

            Random rnd = new Random();
            
            String str = "abcdefghijklmnopqrstuvwxyz";
            int size = 35;
            String ran = "";
            for (int i = 0; i < size; i++)
            {
                int x = rnd.Next(35);
                ran = ran + str[x];
            }
            return ran;
        }
        public string getType()
        {
            string Type = "repoter";
            return Type;

        }
        public int GetNum_reports()
        {

            return People.num_reports;
        }
        public int GetNum_mentions()
        {
            return People.num_mentions;
        }
        public List<string> getAllNames()
        {
            List<string> names = new List<string>(); 

            string query = "SELECT `first_name` FROM `people`";

            using (var cmd = new MySqlCommand(query, _conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    string name = reader.GetString("first_name"); 
                    names.Add(name); 
                }
            }
            return names; 
        }
        public int GetPersonId(string firstName)
        {
            int idPearson = -1;

            string query = "SELECT id FROM people WHERE first_name = @FirstName ";
            using (var cmd = new MySqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                openConnection();
                var reader = cmd.ExecuteScalar();
                
            }

            return idPearson;
        }


        //public string getName()
        //{
        //    string query = "SELECT `first_name` FROM `people`";
        //    MySqlCommand cmd = new MySqlCommand(query, _conn);
        //    reader= cmd.ExecuteReader();
        //    return reader.Read();
        //}
        public void insertReports(string malshin, string target, string text )
        {
            //People people = new People("ab", "gg");

            try
            {
                int reporterId = GetPersonId(malshin);
                int targetId = GetPersonId(target);

                string quary = $"INSERT INTO`intelreports` (`reporter_id`,`target_id`,`text`,`timestamp`)" +
                       "VALUES (@reporter_id, @target_id, @text, @timestamp)";
                cmd = new MySqlCommand(quary, _conn);
                //MySqlCommand cmd = new MySqlCommand(query, _conn);

                cmd.Parameters.AddWithValue("@reporter_id", reporterId);
                cmd.Parameters.AddWithValue("@target_id",targetId);
                cmd.Parameters.AddWithValue("@text", text);
                cmd.Parameters.AddWithValue("@timestamp", getTime());


                //reader = cmd.ExecuteReader();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                Console.WriteLine("");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }
        public string getTime()
        {
            DateTime currentTime = DateTime.Now;
            string timey = currentTime.ToString();
            return timey;
        }




        //public int GetNum_reports()
        //{
        //    openConnection();
        //    string query = "SELECT  COUNT(intelreports.reporter_id) FROM people JOIN intelreports ON people.id = intelreports.reporter_id";
        //    cmd = new MySqlCommand(query, _conn);
        //    reader = cmd.ExecuteReader();
        //    return reader.FieldCount;
        //}
        //public int GetNum_mentions()
        //{
        //    openConnection();
        //    string query = "SELECT  COUNT(intelreports.reporter_id) FROM people JOIN intelreports ON people.id = intelreports.`target_id`";
        //    cmd = new MySqlCommand(query, _conn);
        //    reader = cmd.ExecuteReader();
        //    return reader.GetValue();

    }





        //public void inserIntelReport()


        //cmd = new MySqlCommand(quary, _conn);
        //cmd.ExecuteNonQuery();
        //reader = cmd.ExecuteReader();

        //public List<Agent> GetAgents()
        //{
        //    List<Agent> agants = new List<Agent>();
        //    MySqlCommand cmd = null;
        //    MySqlDataReader reader = null;
        //    try
        //    {
        //        string query = "SELECT * FROM agents";
        //        openConnection();
        //        cmd = new MySqlCommand(query, _conn);
        //        reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            int _id = reader.GetInt32("id");
        //            string _codeName = reader.GetString("codeName");
        //            string _realName = reader.GetString("realName");
        //            string _location = reader.GetString("location");
        //            string _status = reader.GetString("status");
        //            int _missionsCompleted = reader.GetInt32("missionsCompleted");

        //            Agent agent = new Agent(_id, _codeName, _realName, _location, _status, _missionsCompleted);
        //            agants.Add(agent);

        //        }

        //    }
        //    catch (MySqlException ex)
        //    {
        //        Console.WriteLine($"Error while fetching agents: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error while fetching agents: {ex.Message}");
        //    }
        //    finally
        //    {
        //        if (reader != null && !reader.IsClosed)
        //            reader.Close();

        //        closeConnection();
        //    }

        //return agants;


        //public List<Employee> getEmployees(string query = "SELECT * FROM employees")
        //{
        //    List<Employee> empList = new List<Employee>();
        //    MySqlCommand cmd = null;
        //    MySqlDataReader reader = null;

        //    try
        //    {
        //        openConnection();
        //        cmd = new MySqlCommand(query, _conn);
        //        reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            int employeeNumber = reader.GetInt32("employeeNumber");
        //            string lastName = reader.GetString("lastName");
        //            string firstName = reader.GetString("firstName");
        //            string jobTitle = reader.GetString("jobTitle");

        //            Employee emp = new Employee(employeeNumber, firstName, lastName, jobTitle);
        //            empList.Add(emp);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error while fetching employees: {ex.Message}");
        //    }
        //    finally
        //    {
        //        if (reader != null && !reader.IsClosed)
        //            reader.Close();

        //        closeConnection();
        //    }

        //    return empList;
        //}
        //    }
        //    public void printAgentList(List<Agent> agents)
        //    {
        //        foreach (Agent agent in agents)
        //        {
        //            Console.WriteLine(agent);
        //        }
        //    }
        //}



    
}