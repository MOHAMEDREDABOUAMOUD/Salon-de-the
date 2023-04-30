using System.Data.SqlClient;

namespace Salon_de_thé
{
    public static class Program
    {
        public static SqlConnection connection;
        public static SqlCommand command;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            connection = new SqlConnection();
            connection.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=salon-de-thé;Integrated Security=True;Pooling=False";
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}