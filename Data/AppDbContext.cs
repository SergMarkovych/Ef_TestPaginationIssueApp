using Ef_TestPaginationIssueApp.Types;
using Microsoft.EntityFrameworkCore;

namespace Ef_TestPaginationIssueApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Child> Child { get; set; }
        public DbSet<Parent> Parent { get; set; }

        public DbSet<Phone> Phone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EfConsoleAppDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Child>().ToTable(nameof(Child)).OwnsOne
            (
                child => child.InfoData, builder =>
                {
                    builder.ToJson();

                    builder.OwnsMany(x => x.Fields);
                }
            );
        }

        public void EnsureSeedData()
        {
            if (!Parent.Any())
            {
                var parents = new List<Parent>();

                for (long i = 1; i <= 100; i++)
                {
                    var parent = new Parent();

                    var child = new Child
                    {
                        InfoData = new InfoData
                        {
                            Fields = new List<Field>()
                        }
                    };

                    if (i % 2 == 0)
                    {
                        var total = new Field { Code = "Total", Value = (int)i };
                        child.InfoData.Fields.Add(total);

                        var total2 = new Field { Code = "Total2", Value = (int)(i*2) };
                        child.InfoData.Fields.Add(total2);

                        var phone = new Phone { FullNumber = "34243565657"};

                        parent.Phone = phone;
                    }
                    else
                    {
                        var total2 = new Field { Code = "Total2", Value = (int)(i * 2) };
                        child.InfoData.Fields.Add(total2);
                    }

                    parent.Child = child;

                    parents.Add(parent);
                }

                Parent.AddRange(parents);

                SaveChanges();
            }
        }
    }
}
