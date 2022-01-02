﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MedLifeDAL.Entities
{
    public partial class Doctors
    {
        public Guid Id { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public string Image { get; set; }
        public string UniqueImageName { get; set; }
        public int DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual AppUser CreatedByNavigation { get; set; }
        public virtual Departments Department { get; set; }
        public virtual AppUser IdNavigation { get; set; }
        public virtual AppUser ModifiedByNavigation { get; set; }
    }
}