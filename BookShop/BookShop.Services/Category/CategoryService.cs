namespace BookShop.Services.Category
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Services.Category.Contracts;
    using BookShop.Services.Models.Category;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly BookShopDbContext bookShopDbContext;
        private readonly IMapper mapper;

        public CategoryService(BookShopDbContext bookShopDbContext, IMapper mapper)
        {
            this.bookShopDbContext = bookShopDbContext;
            this.mapper = mapper;
        }

        public async Task<int> Create(string name)
        {
            var category = new Category
            {
                Name = name
            };

            this.bookShopDbContext.Add(category);
            await this.bookShopDbContext.SaveChangesAsync();

            return category.Id;
        }

        public async Task<CategoryServiceModel> GetByName(string name)
        {
            var categoryServiceModel = await this.bookShopDbContext
                .Categories
                .Where(category => category.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                .Select(categoryDataModel => this.mapper.Map<CategoryServiceModel>(categoryDataModel))
                .FirstOrDefaultAsync();

            return categoryServiceModel;
        }
    }
}
