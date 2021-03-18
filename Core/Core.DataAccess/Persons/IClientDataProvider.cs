using Core.Model.Persons;
using System;
using System.Threading.Tasks;

namespace Core.DataAccess.Persons
{
    public interface IClientDataProvider
    {
        Task<Client> CreateNewClientAsync(string firstName, string lastName, DateTime birthDate, string phoneNumber = null);
    }
}