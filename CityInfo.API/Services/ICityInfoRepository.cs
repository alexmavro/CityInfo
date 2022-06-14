using CityInfo.API.Entities;
using Microsoft.AspNetCore.SignalR;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCityAsync(int CityId, bool includePOI);
        Task<IEnumerable<PointOfInterest>> GetPOISAsync(int CityId);
        Task<PointOfInterest?> GetPOIAsync(int CityId, int POIId);
    }
}
