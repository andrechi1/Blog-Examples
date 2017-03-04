using System;
using System.Collections.Generic;
using System.Text;

namespace PartitionEFCore.Model
{
    public class Person
    {
        public Guid IdPerson { get; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
