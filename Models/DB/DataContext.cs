using EUCTask.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EUCTask.Models.DB
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<RegistrationData> Registration { get; set; }

        public async Task<RegistrationData> CreateRegistrationAsync(Registration registration)
        {
            var newRegistration = new RegistrationData
            {
                Id = Guid.NewGuid(),
                FullName = registration.FullName,
                BirthNumber = registration.BirthNumber,
                Birthday = ((DateTime)registration.Birthday!),
                Gender = registration.Gender,
                Nationality = registration.Nationality,
                Email = registration.Email
            };

            await this.Registration.AddAsync(newRegistration);
            this.SaveChanges();

            return newRegistration;
        }

        public async Task<IEnumerable<RegistrationData>> GetAllRegistrationsAsync()
        {
            return await this.Registration.OrderBy(x => x.FullName).ToListAsync();
        }
    }
}
