using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLifeDAL.View_Model
{
   public class AddDoctor
    {
       public Guid Id { get; set; } 
       
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public IFormFile Image { get; set; }
       
        public int DepartmentId { get; set; }

       

    }
}
