using Core.Model;
using System.Collections.Generic;

namespace Core.DataAccess.Cars
{
    public interface ICarDataProvider
    {
        IEnumerable<Car> GetAvailableCars();

        IEnumerable<Car> GetCarsUsedByClientWithDrives(int clientId);
    }
}
