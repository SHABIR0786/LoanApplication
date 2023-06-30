using LoanManagement.codeFirstEntities;
using LoanManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Data
{
    public static class StateData
    {
        public static List<State> StateList = new List<State>
            {
                new State { Id = 1, Name = "AL" },
                new State { Id = 2, Name = "AK" },
                new State { Id = 3, Name = "AS" },
                new State { Id = 4, Name = "AZ" },
                new State { Id = 5, Name = "AR" },
                new State { Id = 6, Name = "CA" },
                new State { Id = 7, Name = "CO" },
                new State { Id = 8, Name = "CT" },
                new State { Id = 9, Name = "DE" },
                new State { Id = 10, Name = "DC" },
                new State { Id = 11, Name = "FM" },
                new State { Id = 12, Name = "FL" },
                new State { Id = 13, Name = "GA" },
                new State { Id = 14, Name = "GU" },
                new State { Id = 15, Name = "HI" },
                new State { Id = 16, Name = "ID" },
                new State { Id = 17, Name = "IL" },
                new State { Id = 18, Name = "IN" },
                new State { Id = 19, Name = "IA" },
                new State { Id = 20, Name = "KS" },
                new State { Id = 21, Name = "KY" },
                new State { Id = 22, Name = "LA" },
                new State { Id = 23, Name = "ME" },
                new State { Id = 24, Name = "MH" },
                new State { Id = 25, Name = "MD" },
                new State { Id = 26, Name = "MA" },
                new State { Id = 27, Name = "MI" },
                new State { Id = 28, Name = "MN" },
                new State { Id = 29, Name = "MS" },
                new State { Id = 30, Name = "MO" },
                new State { Id = 31, Name = "MT" },
                new State { Id = 32, Name = "NE" },
                new State { Id = 33, Name = "NV" },
                new State { Id = 34, Name = "NH" },
                new State { Id = 35, Name = "NJ" },
                new State { Id = 36, Name = "NM" },
                new State { Id = 37, Name = "NY" },
                new State { Id = 38, Name = "NC" },
                new State { Id = 39, Name = "ND" },
                new State { Id = 40, Name = "MP" },
                new State { Id = 41, Name = "OH" },
                new State { Id = 42, Name = "OK" },
                new State { Id = 43, Name = "OR" },
                new State { Id = 44, Name = "PW" },
                new State { Id = 45, Name = "PA" },
                new State { Id = 46, Name = "PR" },
                new State { Id = 47, Name = "RI" },
                new State { Id = 48, Name = "SC" },
                new State { Id = 49, Name = "SD" },
                new State { Id = 50, Name = "TN" },
                new State { Id = 51, Name = "TX" },
                new State { Id = 52, Name = "UT" },
                new State { Id = 53, Name = "VT" },
                new State { Id = 54, Name = "VI" },
                new State { Id = 55, Name = "VA" },
                new State { Id = 56, Name = "WA" },
                new State { Id = 57, Name = "WV" },
                new State { Id = 58, Name = "WI" },
                new State { Id = 59, Name = "WY" }
            };

        public static string GetStateById(int stateId) =>
            StateList
                .Where(i => i.Id == stateId)
                .Select(i => i.Name)
                .Single();
    }
}
