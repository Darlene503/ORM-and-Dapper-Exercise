using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Transactions;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var depRepo = new DepartmentRepo(conn);

            Console.WriteLine("Enter as new department name: ");

            var depName = Console.ReadLine();

            depRepo.InsertDepartment(depName);

            var departments = depRepo.GetAllDepartments();

            foreach(var dep in departments) 
            {
                Console.WriteLine($"ID: {dep.DepartmentID} | Name: {dep.Name}");
            }


        }

    }
}
