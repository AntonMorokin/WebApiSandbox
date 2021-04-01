using Core.Database;
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
                .Include(c => c.Drives)
                .Where(c => c.State == CarState.Active
                            // Use two negation to optimize quiery.
                            && !c.Drives.Any(d => !d.FinishingDateTime.HasValue))
                .ToList();
        }
    }
}
