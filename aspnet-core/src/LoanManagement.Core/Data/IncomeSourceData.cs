using LoanManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanManagement.Data
{
 public static class IncomeSourceData
    {
        public static List<IncomeSource> IncomeSourceList = new List<IncomeSource>
        {
           new IncomeSource  {Id = 1,Name = "Accessory Unit Income"},
           new IncomeSource {Id = 2, Name = "Alimony/Child Support" },
           new IncomeSource {Id = 3, Name = "Automobile/Expense Account"},
           new IncomeSource { Id = 4,Name = "Boarder Income"}
        };

        public static string GetIncomeSourceById(int incomeSourceId) =>
                IncomeSourceList
               .Where(i => i.Id == incomeSourceId)
               .Select(i => i.Name)
               .Single();
    }
}
