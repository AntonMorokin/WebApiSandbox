using Core.Model;
using System;
using System.Threading.Tasks;

namespace Core.Logic.Clients
{
    public interface IClientService
    {
        Task<Client> CreateNewClientAsync(string firstName, string lastName, DateTime birthDate, string phoneNumber);
    }
}