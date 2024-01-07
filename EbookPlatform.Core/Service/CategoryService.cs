using EbookPlatform.Core.Service.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.Service
{
    public class CategoryService : ICategoryService
    {
        private MyEbookPlatformContext _context;
        public CategoryService(MyEbookPlatformContext context)
        {
            _context = context;
        }
        public int AddCategory(Category category)
        {
            try
            {
                _context.categories.Add(category);
                _context.SaveChanges();
                return category.categoryID;
            }
            catch (Exception )
            {

                return 0;
            }
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                _context.categories.Update(category);
                _context.SaveChanges(); 
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Category FindCategoryByID(int categoryID)
        {
 
            return _context.categories.Find(categoryID);
        }

        public List<Category> ShowAllCategory()
        {
            return _context.categories.Where(c => !c.isDeleted && c.parentID == null).ToList();
        }

        public List<Category> ShowAllSubCategory(int categoryID)
        {
           return _context.categories.Where(c=> !c.isDeleted && c.parentID == categoryID).ToList();
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                _context.categories.Update(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool doesExist(string title, int catid)
        {
            return _context.categories.Any(c => c.title == title && c.categoryID != catid);
        }
    }
}
