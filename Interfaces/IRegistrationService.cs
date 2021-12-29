using EUCTask.Models;
using EUCTask.Models.DB;
using System.Threading.Tasks;

namespace EUCTask.Interfaces
{
    public interface IRegistrationService
    {
        Task<RegistrationData?> CreateRegistrationAsync(Registration registration);
        Task SaveToFile(RegistrationData registrationData);
    }
}
