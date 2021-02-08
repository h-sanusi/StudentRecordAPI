using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendance.API.Entities
{
    public class Attendance
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(100)]
        public string Department { get; set; }
        [Required]
        public int EntryYear{ get; set; }
    }
}
