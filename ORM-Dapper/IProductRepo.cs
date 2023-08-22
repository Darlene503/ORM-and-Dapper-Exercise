using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();
        public void InsertProducts(string name, double price, int categoryID);
    }

    
}
