using Scheduler.Core.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Scheduler.Core.Interfaces
{
    public interface IDataService
    {
        DataTable GetAllUsers();
        void CreateUser(User user);
        User GetUserByUsername(string username);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        void CreateCustomer(Customer customer);
        DataTable GetAllCustomers();
        void UpdateCustomer(Customer updatedCustomer);
        void DeleteCustomer(int customerId);
        void CreateCountry(Country country);
        DataTable GetAllCountries();
        void UpdateCountry(Country updatedCountry);
        void DeleteCountry(int countryId);
        void CreateCity(City city);
        DataTable GetAllCities();
        void UpdateCity(City updatedCity);
        void DeleteCity(int cityId);
        void CreateAddress(Address address);
        DataTable GetAllAddresses();
        void UpdateAddress(Address updatedAddress);
        void DeleteAddress(int addressId);
        BindingList<SelectListItem> LoadItems(string tableName);
    }
}
