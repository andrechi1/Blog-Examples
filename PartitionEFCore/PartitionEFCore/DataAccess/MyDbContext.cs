using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PartitionEFCore.DataAccess
{
    public class MyDbContext : DbContext
    {
        private int mIdPartition;

        public MyDbContext(int idPartition)
        {
            mIdPartition = idPartition;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PartitionEFCoreTest;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
