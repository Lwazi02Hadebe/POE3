namespace POE1
{
    public class connection
    {
        //return connection string method
        public string Connecting()
        {
            //then return the connection
            //return "Data Source=(localdb)\\ mecca17;Initial Catalog=mecca17;";

            return "Server=(localdb)\\Local;Database=ProjectDB1;Trusted_Connection=True;";
        }
    }
}
