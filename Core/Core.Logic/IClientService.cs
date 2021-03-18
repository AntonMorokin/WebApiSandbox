using Core.Model.Persons;
using System;
using System.Threading.Tasks;

namespace Core.Logic
{
    public interface IClientService
    {
        Task<Client> CreateNewClientAsync(string firstName, string lastName, DateTime birthDate, string phoneNumber = null);
    }
}