using Core.Model.Domain;
using System.Collections.Generic;

namespace Core.Logic.Cars
{
    public interface ICarService
    {
        IEnumerable<Car> GetAvailableCars();

        IEnumerable<Car> GetCarsUsedByClientWithDrives(int clientId);
    }
}
