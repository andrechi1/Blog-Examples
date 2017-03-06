using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace PartitionEFCore.DataAccess
{
    public class PartitionValueGenerator : ValueGenerator<int>
    {
        public override int Next(EntityEntry entry)
        {
            return ((MyDbContext)(entry.Context)).IdPartition;
        }

        public override bool GeneratesTemporaryValues => false;
    }
}
