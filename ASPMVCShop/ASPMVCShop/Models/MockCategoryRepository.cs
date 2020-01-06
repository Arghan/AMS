using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPMVCShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{ CategoryId=1, CategoryName="Fruit pies", Description = "Description Fruit pies"},
                new Category{ CategoryId=2, CategoryName="Cheese cakes", Description = "Description cheese cakes"},
                new Category{ CategoryId=3, CategoryName="Seasonal pies", Description = "Ho ho ho"}
            };
    }
}
