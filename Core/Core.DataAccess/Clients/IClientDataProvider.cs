using Core.Model;
using System;
using System.Threading.Tasks;

namespace Core.DataAccess.Clients
{
    public interface IClientDataProvider
    {
        Task<Client> CreateNewClientAsync(string firstName, string lastName, DateTime birthDate, string phoneNumber);
    }
}