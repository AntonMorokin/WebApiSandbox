using Core.Common;
using Core.DataAccess.Persons;
using Core.Model.Persons;
using System;
using System.Threading.Tasks;

namespace Core.Logic
{
    internal class ClientService : IClientService
    {
        // To config/settings
        private const int MAX_CLIENT_AGE_IN_YEARS = 150;

        private readonly ITimeManager _timeManager;
        private readonly IClientDataProvider _clientDataProvider;

        public ClientService(ITimeManager timeManager, IClientDataProvider clientDataProvider)
        {
            _timeManager = timeManager;
            _clientDataProvider = clientDataProvider;
        }

        public Task<Client> CreateNewClientAsync(string firstName, string lastName, DateTime birthDate, string phoneNumber = null)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            birthDate = birthDate.Date;
            if (GetAgeInYears(birthDate) > MAX_CLIENT_AGE_IN_YEARS)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(birthDate),
                    $"Client age cannot be greather than {MAX_CLIENT_AGE_IN_YEARS} years.");
            }

            return _clientDataProvider.CreateNewClientAsync(firstName, lastName, birthDate, phoneNumber);
        }

        private int GetAgeInYears(DateTime birthDate)
        {
            DateTime now = _timeManager.LocalDateTime.Date;
            int years = now.Year - birthDate.Year;

            if (birthDate.Month != now.Month)
            {
                return now.Month < birthDate.Month
                    ? years - 1
                    : years;
            }

            return now.Day < birthDate.Day
                ? years - 1
                : years;
        }
    }
}
