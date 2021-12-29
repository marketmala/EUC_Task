using EUCTask.Interfaces;
using EUCTask.Models;
using EUCTask.Models.DB;
using System;
using System.Threading.Tasks;

namespace EUCTask.Logic
{
    public class RegistrationService : IRegistrationService
    {
        readonly IDataContext context;

        public RegistrationService(IDataContext context)
        {
            this.context = context;
        }

        public async Task<RegistrationData?> CreateRegistrationAsync(Registration registration)
        {
            try
            {
                var result = await this.context.CreateRegistrationAsync(registration);
                return result;
            }
            catch (Exception e)
            {
                // logging
            }

            return null;
        }
    }
}
