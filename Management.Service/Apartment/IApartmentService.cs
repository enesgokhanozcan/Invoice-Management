using Management.Model;
using Management.Model.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Service.Apartment
{
    public interface IApartmentService
    {
        public General<ApartmentViewModel> Insert(ApartmentViewModel newApartment);
        public General<ApartmentViewModel> Update(int id, ApartmentUpdateModel apartmentUpdate);
        public General<ApartmentViewModel> Delete(int id);
        public General<ApartmentViewModel> ListApartment();
    }
}
