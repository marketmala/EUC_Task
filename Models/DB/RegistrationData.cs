using System;

namespace EUCTask.Models.DB
{
    public class RegistrationData 
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string BirthNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
    }
}
