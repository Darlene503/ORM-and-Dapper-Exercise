using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ORM_Dapper
{
    public class ProductRepo : IProductRepo
    {
        private readonly IDbConnection _connection;

        public ProductRepo(IDbConnection connection)
        {
            _connection = connection;

        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }

        public void IsertProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO Products (Name,Price, CategoryID) VALUES (@name, @price, @categoryID);", new { name = name, price = price, categoryID = categoryID });
        }
        public void UpdateProductName(int productID, string newName)
        {
            _connection.Execute("UPDATE Products SET Name = @newName WHERE ProductsID = @productID;",
                new { productID = productID, newName = newName });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM Reviews WHERE ProductID = @productID;", new { @productID = productID});
            _connection.Execute("DELETE FROM Sales WHERE ProductID = @productID;", new { @productID = productID });
            _connection.Execute("DELETE FROM Products WHERE ProductID = @productID;", new { @productID = productID });
        }

        
    }

}
