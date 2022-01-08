using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Model.Apartment
{
    public class ApartmentUpdateModel
    {
        public int AelectricityBill { get; set; }
        public int AwaterBill { get; set; }
        public int AgasBill { get; set; }
        public int Adues { get; set; }
    }
}
