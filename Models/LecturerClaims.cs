using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace POE1.Models
{
    public class LecturerClaims
    {
        [Required]
        public string user_email { get; set; }
        public string user_Id { get; set; }

        public string module_name { get; set; }
        public string hour_work { get; set; }

        public string hour_rate { get; set; }

        public string description { get; set; }
        



        //connection
        connection connect = new connection();
        public string insert_LecturerClaim(string module_name, string hour_work, string hour_rate, string description, string filename)
        {

            //temp variable message
            string message = "";
            string user_Id = get_id();
            string user_email = get_email();

            string total = "" + (int.Parse(hour_work) * int.Parse(hour_rate));


            string query = "insert into LecturerClaim values('" + user_email + "' , '" + module_name + "','" + user_Id + "' , '" + hour_work + "', '" + hour_rate + "' ,'" + description + "' ,'none', 'none','" + total + "' ,'" + filename + "','pending');";

            try
            {
                using (SqlConnection connects = new SqlConnection(connect.Connecting()))
                {
                    connects.Open();

                    using (SqlCommand done = new SqlCommand(query, connects))
                    {
                        done.ExecuteNonQuery();
                        message = "done";

                    }
                    connects.Close();

                }
            }
            catch (IOException error)
            {
                message = error.Message;
            }
            return message;


        }

        //get id
        public string get_id()
        {
            //hold id varibale
            string hold_id = "";

            try
            {
                using (SqlConnection connects = new SqlConnection(connect.Connecting()))
                {
                    connects.Open();

                    using (SqlCommand prepare = new SqlCommand("select * from active", connects))
                    {
                        using (SqlDataReader getID = prepare.ExecuteReader())

                        {
                            if (getID.HasRows)
                            {

                                //check all, but get one
                                while (getID.Read())
                                {
                                    //then get it
                                    hold_id = getID["id"].ToString();
                                }
                            }

                            getID.Close();


                        }
                    }

                    connects.Close();
                }

            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
                hold_id = error.Message;
            }
            return hold_id;
        }

        //get email
        public string get_email()
        {
            //hold id varibale
            string hold_email = "";

            try
            {
                using (SqlConnection connects = new SqlConnection(connect.Connecting()))
                {
                    connects.Open();

                    using (SqlCommand prepare = new SqlCommand("select * from active", connects))
                    {
                        using (SqlDataReader getemail = prepare.ExecuteReader())

                        {
                            if (getemail.HasRows)
                            {

                                //check all, but get one
                                while (getemail.Read())
                                {
                                    //then get it
                                    hold_email = getemail["email"].ToString();
                                }
                            }
                            getemail.Close();

                        }
                    }

                    connects.Close();
                }

            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
                hold_email = error.Message;
            }
            return hold_email;
        }

    }
}
