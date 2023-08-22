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
            var prodRepo = new ProductRepo(conn);

            //prodRepo.InsertProduct("Fallout: New Vegas", 30.00, 1);

            //prodRepo.UpdateProductName(940, "Artichoke");

            prodRepo.DeleteProduct(940);

            var products = prodRepo.GetAllProducts();

            foreach(var product in products)
            {
                Console.WriteLine($"Name: {product.Name} | Price: {product.Price} | Category: {product.CategoryID} | {product.ProductId}");
            }

        }

    }
}
