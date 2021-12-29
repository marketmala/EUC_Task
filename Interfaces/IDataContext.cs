using EUCTask.Models;
using EUCTask.Models.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EUCTask.Interfaces
{
    public interface IDataContext
    {
        Task<IEnumerable<RegistrationData>> GetAllRegistrationsAsync();
        Task<RegistrationData> CreateRegistrationAsync(Registration registration);
    }
}
