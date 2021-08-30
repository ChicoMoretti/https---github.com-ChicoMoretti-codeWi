using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Data
{
    public class CoinContext : DbContext
    {
        public CoinContext(DbContextOptions<CoinContext> options) : base(options)
        {

        }
        public CoinContext()
        {
        }
        public DbSet<Coins> Coins { get; set; }
    }
}
