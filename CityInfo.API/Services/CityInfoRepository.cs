using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<City?> GetCityAsync(int CityId, bool includePOI)
        {
            if (includePOI)
            {
                return await _context.Cities.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == CityId).FirstOrDefaultAsync();
            }
            return await _context.Cities.FirstOrDefaultAsync(c => c.Id == CityId);
        }

        public async Task<IEnumerable<PointOfInterest>> GetPOISAsync(int CityId)
        {
            return await _context.PointsOfInterest.Where(c => c.Id == CityId).ToListAsync();
        }

        public async Task<PointOfInterest?> GetPOIAsync(int CityId, int POIId)
        {
            return await _context.PointsOfInterest.Where(c => c.CityId == CityId).FirstOrDefaultAsync(c => c.Id == POIId);
        }
    }
}
