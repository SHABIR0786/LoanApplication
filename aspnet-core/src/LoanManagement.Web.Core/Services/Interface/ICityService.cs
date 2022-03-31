using LoanManagement.Features.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ICityService
    {
        string AddCity(AddCityRequest request);
        string UpdateCity(UpdateCountryRequest request);
        string DeleteCity(int id);
        List<UpdateCountryRequest> GetCities();
        UpdateCountryRequest GetCityById(int id);
    }
}
