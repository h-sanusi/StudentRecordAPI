using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendance.API.Models
{
    public class AttendanceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int EntryYear { get; set; }
        public string Department { get; set; }
    }

}
