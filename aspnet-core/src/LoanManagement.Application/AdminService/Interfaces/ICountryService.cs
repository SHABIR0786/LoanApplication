using LoanManagement.Features.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ICountryService
    {
        string AddCountry(AddCountryRequest request);
        string UpdateCountry(UpdateCountryRequest request);
        string DeleteCountry(int id);
        List<UpdateCountryRequest> GetCountries();
        UpdateCountryRequest GetCountryById(int id);
    }
}
