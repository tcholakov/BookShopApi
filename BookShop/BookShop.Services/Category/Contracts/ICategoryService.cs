namespace BookShop.Services.Category.Contracts
{
    using System.Threading.Tasks;
    using BookShop.Services.Models.Category;

    public interface ICategoryService
    {
        Task<int> Create(string name);

        Task<CategoryServiceModel> GetByName(string name);
    }
}
