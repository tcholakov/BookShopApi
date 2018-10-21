namespace BookShop.Services.Test.Book
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Services.Book;
    using BookShop.Services.Infrastructure.Mapping;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class BookServiceTest
    {
        [Fact]
        public async Task FilterShouldReturnCorrectResultsWithSeachTextAndOrder()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<BookShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var bookShopDbContext = new BookShopDbContext(dbContextOptions);

            var firstBook = new Book
            {
                Id = 1,
                Title = "Test Title 1",
                Description = "test description 1",
                AuthorId = 1
            };

            var secondBook = new Book
            {
                Id = 2,
                Title = "Test Title 2",
                Description = "test description 2",
                AuthorId = 1
            };

            var thirdBook = new Book
            {
                Id = 3,
                Title = "Test Title 3",
                Description = "title 1",
                AuthorId = 1
            };

            var category = new Category
            {
                Id = 1,
                Name = "First category"
            };

            var bookCategory = new BookCategory
            {
                BookId = 1,
                CategoryId = 1
            };

            var author = new Author
            {
                Id = 1,
                FirstName = "User",
                LastName = "Testov"
            };

            bookShopDbContext.Add(category);
            bookShopDbContext.Add(bookCategory);
            bookShopDbContext.Add(author);
            bookShopDbContext.Add(firstBook);
            bookShopDbContext.Add(secondBook);
            bookShopDbContext.Add(thirdBook);

            await bookShopDbContext.SaveChangesAsync();
            
            var configuration = new MapperConfiguration(config => config.AddProfile<AutoMapperServiceProfile>());
            var mapper = new Mapper(configuration);

            var bookService = new BookService(bookShopDbContext, mapper);

            // Act
            var result = await bookService.Filter("1");

            // Assert
            result
                .Should()
                .HaveCount(2);

            var firstResultBook = result.ElementAt(0);
            var secondResultBook = result.ElementAt(1);

            firstResultBook.Id.Should().Be(firstBook.Id);
            firstResultBook.Categories.Count().Should().Be(1);
            firstResultBook.Categories.First().Should().Be(category.Name);
            firstResultBook.Author.Id.Should().Be(author.Id);
            firstResultBook.Author.FirstName.Should().Be(author.FirstName);
            firstResultBook.Author.LastName.Should().Be(author.LastName);

            secondResultBook.Id.Should().Be(thirdBook.Id);
            secondResultBook.Categories.Should().BeNullOrEmpty();
            secondResultBook.Author.Id.Should().Be(author.Id);
            secondResultBook.Author.FirstName.Should().Be(author.FirstName);
            secondResultBook.Author.LastName.Should().Be(author.LastName);
        }
    }
}
