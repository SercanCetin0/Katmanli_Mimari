using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from x in context.Products
                             join c in context.Categories
                             on x.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = x.ProductId, ProductName = x.ProductName, CategoryName = c.CategoryName, UnitInStock = x.UnitsInStock };
                return result.ToList();
            }
        }
    }
}
