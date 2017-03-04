using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartitionEFCore.DataAccess;

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
        public void PartitionDbContaxtTest01()
        {
            using (var db = new MyDbContext(1))
            {
                
            }
        }

        [TestMethod]
        public void PartitionDbContaxtTest02()
        {
            using (var db = new MyDbContext(2))
            {

            }
        }
    }
}
