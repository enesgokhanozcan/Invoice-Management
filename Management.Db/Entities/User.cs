using System;
using System.Collections.Generic;

#nullable disable

namespace Management.DB.Entities
{
    public partial class User
    {
        public User()
        {
            Apartment = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tcno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PlateCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Idatetime { get; set; }
        public DateTime? Udatetime { get; set; }
        public int Iuser { get; set; }
        public int? Uuser { get; set; }

        public virtual ICollection<Apartment> Apartment { get; set; }
    }
}
