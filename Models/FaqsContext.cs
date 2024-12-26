using Microsoft.EntityFrameworkCore;
namespace FAQs.Models
    {
    public class FaqsContext : DbContext
        {
        public FaqsContext (DbContextOptions<FaqsContext> options) : base(options)
            {
            }
        public DbSet<FAQ> FAQs { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<Topic> Topic { get; set; } = null!;
        protected override void OnModelCreating (ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId= "gen", Name="General"},
                new Category { CategoryId= "hist", Name = "History" }
                );
            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "asp", Name = "ASP.NET Core" },
                new Topic { TopicId = "blz", Name = "Blazor" },
                new Topic { TopicId = "ef", Name = "Entity Framework" }
                );
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { FAQId = 1, Question = "What is ASP.NET Core?", Answer="trjuy",TopicId= "asp", CategoryId= "gen" },
                new FAQ { FAQId = 2, Question = "When was ASP.NET Core built?", Answer = "1995", TopicId = "asp", CategoryId = "hist" },
                new FAQ { FAQId = 3, Question = "What is Blazor", Answer = "wgreg", TopicId = "blz", CategoryId = "gen" },
                new FAQ { FAQId = 4, Question = "When was Blazor released?", Answer = "2006", TopicId = "blz", CategoryId = "hist" },
                new FAQ { FAQId = 5, Question = "What is Entity Framework?", Answer = "wgrefdgzrgbg", TopicId = "ef", CategoryId = "gen" },
                new FAQ { FAQId = 6, Question = "When was Entity Framework released?", Answer = "2010", TopicId = "ef", CategoryId = "hist" }
                );
            }
        }
    }
