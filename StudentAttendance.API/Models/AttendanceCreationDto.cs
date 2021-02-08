using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendance.API.Models
{
    public class AttendanceCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EntryYear { get; set; }
        public string Department { get; set; }
    }
}
