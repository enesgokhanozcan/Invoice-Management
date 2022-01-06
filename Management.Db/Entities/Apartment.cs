using System;
using System.Collections.Generic;

#nullable disable

namespace Management.DB.Entities
{
    public partial class Apartment
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public string Astatus { get; set; }
        public string Atype { get; set; }
        public int AfloorNumber { get; set; }
        public int Anumber { get; set; }
        public bool CondominiumStatus { get; set; }
        public int AelectricityBill { get; set; }
        public int AwaterBill { get; set; }
        public int AgasBill { get; set; }
        public int Adues { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Idatetime { get; set; }
        public DateTime? Udatetime { get; set; }
        public int Iuser { get; set; }
        public int? Uuser { get; set; }

        public virtual User IuserNavigation { get; set; }
    }
}
