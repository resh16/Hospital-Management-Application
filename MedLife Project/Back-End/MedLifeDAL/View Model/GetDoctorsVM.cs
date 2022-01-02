using Microsoft.AspNetCore.Http;

namespace MedLifeDAL.View_Model
{
    public class GetDoctorsVM
    {

        public string DoctorName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public string UniqueImageName { get; set; }




    }
}
