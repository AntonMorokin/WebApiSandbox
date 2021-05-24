using Core.Database.Domain;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Core.DataAccess.Cars
{
    internal sealed class CarDataProvider : ICarDataProvider
    {
        private readonly DataContext _dataContext;

        public CarDataProvider(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Car> GetAvailableCars()
        {
            return _dataContext.Cars
                .Where(c => c.State == CarState.Active
                            && !c.Drives.Any(d => !d.FinishingDateTime.HasValue))
                .Include(c => c.Drives)
                .ToList();
        }

        public IEnumerable<Car> GetCarsUsedByClientWithDrives(int clientId)
        {
            CarState[] availableCarStates = { CarState.Active, CarState.Repairing, CarState.Crashed };

            return _dataContext.Cars
                .Where(c => availableCarStates.Contains(c.State)
                            && c.UsedByClients.Any(cl => cl.ClientId == clientId))
                .Include(c => c.Drives)
                .ToList();
        }
    }
}
