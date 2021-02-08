using StudentAttendance.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendance.API.Services
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetStudents();
        Attendance GetStudentById(Guid studentId);
        void AddStudent(Attendance student);
        void DeleteStudent(Attendance student);
        Attendance UpdateStudent(Attendance student);
        bool Commit();

    }
}
