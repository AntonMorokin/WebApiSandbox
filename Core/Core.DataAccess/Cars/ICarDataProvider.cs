using Core.Model.Domain;
using System.Collections.Generic;

namespace Core.DataAccess.Cars
{
    public interface ICarDataProvider
    {
        IEnumerable<Car> GetAvailableCars();

        IEnumerable<Car> GetCarsUsedByClientWithDrives(int clientId);
    }
}
