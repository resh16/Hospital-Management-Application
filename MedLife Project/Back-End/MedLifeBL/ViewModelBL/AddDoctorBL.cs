using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLifeBL.ViewModelBL
{
   public class AddDoctorBL
    {

        public Guid Id { get; set; }

        public string Qualification { get; set; }
        public int Experience { get; set; }
        public IFormFile Image { get; set; }
        public string UniqueImageName { get; set; }
        public int DepartmentId { get; set; }

    }
}
