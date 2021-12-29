using EUCTask.Interfaces;
using EUCTask.Models;
using EUCTask.Models.DB;
using Newtonsoft.Json;
using System;
using System.IO;
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

        public async Task SaveToFile(RegistrationData registrationData)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(registrationData);
                using (TextWriter writer = new StreamWriter($"{Directory.GetParent(Environment.CurrentDirectory)}\\registrations.json", append: true))
                {
                    await writer.WriteLineAsync(jsonData);
                }
            }
            catch(Exception e)
            {
                // logging
            }
        }
    }
}
