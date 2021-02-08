using Microsoft.EntityFrameworkCore;
using StudentAttendance.API.DbContexts;
using StudentAttendance.API.Entities;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendance.API.Services
{
    public class SqlAttendanceRepository : IAttendanceRepository
    {
        private readonly AttendanceDbContext _dbContext;
        public SqlAttendanceRepository(AttendanceDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));

        }
        public void AddStudent(Attendance student)
        {

            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _dbContext.Add(student);

        }

        public bool Commit()
        {

            return (_dbContext.SaveChanges() >= 0);
        }

        public void DeleteStudent(Attendance student)
        {
            if (student == null) {
                throw new ArgumentNullException(nameof(student));
            }
            _dbContext.Remove(student);
        }

        public IEnumerable<Attendance> GetStudents()
        {
            var query = from a in _dbContext.Attendances
                        orderby a.EntryYear
                        select a;
            return query;
        }

        public Attendance GetStudentById(Guid studentId)
        {
            if (studentId == Guid.Empty) {
                throw new ArgumentNullException(nameof(studentId));
            }
            return _dbContext.Attendances.FirstOrDefault(a => a.Id == studentId);

        }

        public Attendance UpdateStudent(Attendance updatedStudent)
        {
            if (updatedStudent == null)
            {
                throw new ArgumentNullException(nameof(updatedStudent));
            }
            var entity = _dbContext.Attendances.Attach(updatedStudent);
            entity.State = EntityState.Modified;
            return updatedStudent;
        }
    }
}
