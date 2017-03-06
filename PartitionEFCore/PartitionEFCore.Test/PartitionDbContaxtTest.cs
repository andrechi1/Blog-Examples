using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartitionEFCore.DataAccess;
using PartitionEFCore.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PartitionEFCore.Test
{
    [TestClass]
    public class PartitionDbContaxtTest
    {
        [ClassInitialize()]
        public static async Task InitDataBase(TestContext context)
        {
            using (var db = new MyDbContext(0))
            {
                await db.Database.EnsureCreatedAsync();
            }
        }

        [ClassCleanup]
        public static async Task DeleteDataBase()
        {
            using (var db = new MyDbContext(0))
            {
                await db.Database.EnsureDeletedAsync();
            }
        }

        [TestMethod]
        public async Task PartitionDbContaxtTest01()
        {
            using (var db = new MyDbContext(1))
            {
                Person person = new Person()
                {
                    Name = "Name 1",
                    Description = "Description 1"
                };

                db.Persons.Add(person);

                await db.SaveChangesAsync();
            }

            using (var db = new MyDbContext(1))
            {
                var person = await db.Persons.Where(p => p.Name.StartsWith("Name")).ToListAsync();

                Assert.IsTrue(person.Count() > 0);
            }
        }

        [TestMethod]
        public async Task PartitionDbContaxtTest02()
        {
            using (var db = new MyDbContext(2))
            {
                Person person = new Person()
                {
                    Name = "Name 2",
                    Description = "Description 2"
                };

                db.Persons.Add(person);

                await db.SaveChangesAsync();
            }
        }
    }
}
