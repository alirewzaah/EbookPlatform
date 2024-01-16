using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EbookPlatform.DataLayer;

namespace EbookPlatform.Core.Service.Interface
{
    public interface ICategoryService
    {
        List<Category> ShowAllCategory();

        int AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        List<Category> ShowAllSubCategory(int categoryID);
        Category FindCategoryByID(int categoryID);
        public bool doesExist(string title, int catid);
        public List<Category> Showsubcategory();
    }
}
