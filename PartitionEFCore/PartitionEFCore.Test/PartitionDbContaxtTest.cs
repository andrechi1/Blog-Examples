using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartitionEFCore.DataAccess;

namespace PartitionEFCore.Test
{
    [TestClass]
    public class PartitionDbContaxtTest
    {
        [TestInitialize]
        public void InitDataBase()
        {
            using (var db = new MyDbContext(0))
            {
                db.Database.EnsureCreated();
            }
        }

        [TestCleanup]
        public void DeleteDataBase()
        {
            using (var db = new MyDbContext(48))
            {
                db.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void PartitionDbContaxtTest01()
        {
        }
    }
}
