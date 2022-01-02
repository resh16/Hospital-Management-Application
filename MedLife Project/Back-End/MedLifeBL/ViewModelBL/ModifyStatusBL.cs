using System;


namespace MedLifeBL.ViewModelBL
{
   public class ModifyStatusBL
    {

        public int AppointmentId { get; set; }
        public Guid PatientId { get; set; }

        public string Priscription { get; set; }
        public int StatusId { get; set; }

    }
}
