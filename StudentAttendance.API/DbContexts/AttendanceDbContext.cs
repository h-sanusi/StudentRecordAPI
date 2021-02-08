using Microsoft.EntityFrameworkCore;
using StudentAttendance.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendance.API.DbContexts
{
    public class AttendanceDbContext : DbContext
    {
        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) : base(options)
        {
        }
        public DbSet<Attendance> Attendances { get; set; }
    }
}

