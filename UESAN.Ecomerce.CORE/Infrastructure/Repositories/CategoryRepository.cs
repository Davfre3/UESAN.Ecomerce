using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecomerce.CORE.Core.Entities;
using UESAN.Ecomerce.CORE.Core.Interfaces;

namespace UESAN.Ecomerce.CORE.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Data.StoreDbContext _context;
        public CategoryRepository(Data.StoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategoriesAll()
        {
            //var context = new data.storedbcontext();
            //var categories = context.category.tolist();

            //return categories;
            return _context.Category.ToList();

        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category?> GetCategoriesId(int id)
        {
            //return await _context.Category.FindAsync(id);
            return await _context.Category.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        //public async Task<bool> InsertCategory(Category category)
        //{
        //    await _context.Category.AddAsync(category);
        //    int rows = await _context.SaveChangesAsync();
        //    return rows > 0;
        //}

        public async Task<int> InsertCategory(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();

            return category.Id;

        }

        public async Task DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category != null)
            {
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategoryLogic(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category != null)
            {
                category.IsActive = false;
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCategory(Category category)
        {
            var existingCategory = await _context.Category.FindAsync(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Description = category.Description;
                existingCategory.IsActive = category.IsActive; 


                await _context.SaveChangesAsync();
            }
        }

    }
}
