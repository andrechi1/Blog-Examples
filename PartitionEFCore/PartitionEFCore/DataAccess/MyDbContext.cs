using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PartitionEFCore.Model;

namespace PartitionEFCore.DataAccess
{
    public class MyDbContext : DbContext
    {
        private int mIdPartition;

        /// <summary>Partition identify.</summary>
        public int IdPartition
        {
            get { return mIdPartition; }
        }

        public MyDbContext(int idPartition)
        {
            mIdPartition = idPartition;
        }

        private DbSet<Person> mPersons;

        public DbSet<Person> Persons
        {
            get
            {
                if (mPersons == null)
                {
                    mPersons = new PartitionalDbSet<Person, int>(base.Set<Person>(), mIdPartition);
                }

                return mPersons;
            }
        }

        private DbSet<Order> mOrders;

        public DbSet<Order> Orders
        {
            get
            {
                if (mOrders == null)
                {
                    mOrders = new PartitionalDbSet<Order, int>(base.Set<Order>(), mIdPartition);
                }

                return mOrders;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PartitionEFCoreTest;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property<int>("IdPartition")
                    .HasValueGenerator((p, e) => new PartitionValueGenerator());

                entity.Property(p => p.IdPerson);

                entity.HasIndex(new string[] { "IdPartition", "IdPerson" });

                entity.HasKey(p => p.IdPerson);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property<int>("IdPartition")
                    .HasValueGenerator((p, e) =>
                    {
                        return new PartitionValueGenerator();
                    });


                entity.Property(o => o.IdOrder);

                entity.HasKey(p => p.IdOrder);
            });
        }
    }
}
