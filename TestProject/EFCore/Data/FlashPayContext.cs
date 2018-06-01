using EFCore.Models2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Data
{
    public class FlashPayContext : DbContext
    {
        public FlashPayContext(DbContextOptions<FlashPayContext> options) : base(options)
        {
        }

        public DbSet<AdjustBalance> AdjustBalance { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //设置生成对应数据库表的名称
            modelBuilder.Entity<AdjustBalance>().ToTable("AdjustBalance");
        }




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            //optionsBuilder.UseSqlServer(@"Data Source=ITDEVPH\\SQLEXPRESS;Initial Catalog=flashpay;Persist Security Info=True;User ID=user;Password=1qaz2wsx");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=flashpay;Trusted_Connection=True;");
        //}



    }
}
