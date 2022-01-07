using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Model
{
    public class General<T>
    {
        public bool IsSucces { get; set;}
        public T Entity { get; set;}
        public List<T> List { get; set; }
        public List<string> ValidationErrorList { get; set;}
        public string SuccesMessage { get; set; }
        public string BadMessage { get; set; }


    }
}
