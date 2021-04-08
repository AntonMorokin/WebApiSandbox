using Core.DataAccess.Cars;
using Core.Model;
using System.Collections.Generic;

namespace Core.Logic.Cars
{
    internal sealed class CarService : ICarService
    {
        private readonly ICarDataProvider _dataProvider;

        public CarService(ICarDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public IEnumerable<Car> GetAvailableCars()
        {
            // There is no "real" logic. But only for now...
            return _dataProvider.GetAvailableCars();
        }

        public IEnumerable<Car> GetCarsUsedByClientWithDrives(int clientId)
        {
            return _dataProvider.GetCarsUsedByClientWithDrives(clientId);
        }
    }
}
