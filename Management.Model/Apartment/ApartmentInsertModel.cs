using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Model.Apartment
{
    public class ApartmentInsertModel
    {
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
        public DateTime Idatetime { get; set; }
    }
}
