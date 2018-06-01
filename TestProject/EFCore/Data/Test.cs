using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Data
{
    public static class Test
    {
        public  static string Initialize(FlashPayContext context)
        {
            //context.Database.EnsureCreated();
            string str= context.AdjustBalance.SingleOrDefault(m => m.RID == 1038).BeforeBalance.ToString();
            //string str = context.AdjustBalance.FirstOrDefault().BeforeBalance.ToString();
            return str;
        }
    }
}
