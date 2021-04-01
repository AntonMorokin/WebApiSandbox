using Core.Model;
using System.Collections.Generic;

namespace Core.Logic.Cars
{
    public interface ICarService
    {
        IEnumerable<Car> GetAvailableCars();
    }
}
