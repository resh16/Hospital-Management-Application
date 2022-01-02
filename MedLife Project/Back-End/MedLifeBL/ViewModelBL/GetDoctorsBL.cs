using Microsoft.AspNetCore.Http;

namespace MedLifeBL.ViewModelBL
{
    public class GetDoctorsBL
    {

        public string DoctorName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public IFormFile UniqueImageName { get; set; }




    }
}
