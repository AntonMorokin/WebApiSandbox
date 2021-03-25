using Core.Database;
using Core.Model;
using System;
using System.Threading.Tasks;

namespace Core.DataAccess.Clients
{
    internal class ClientDataProvider : IClientDataProvider
    {
        private readonly DataContext _dataContext;

        public ClientDataProvider(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Client> CreateNewClientAsync(string firstName, string lastName, DateTime birthDate, string phoneNumber)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            var client = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                PhoneNumber = phoneNumber
            };

            var newEntity = await _dataContext.Clients.AddAsync(client);
            return newEntity.Entity;
        }
    }
}
