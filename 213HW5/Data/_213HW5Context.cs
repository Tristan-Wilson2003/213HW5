using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _213HW5.Models;

namespace _213HW5.Data
{
    public class _213HW5Context : DbContext
    {
        public _213HW5Context (DbContextOptions<_213HW5Context> options)
            : base(options)
        {
        }

        public DbSet<_213HW5.Models.Music> Music { get; set; } = default!;
    }
}
