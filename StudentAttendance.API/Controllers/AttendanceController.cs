using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAttendance.API.Models;
using StudentAttendance.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendance.API.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;
        public AttendanceController(IAttendanceRepository attendanceRepository, IMapper mapper)
        {

            _attendanceRepository = attendanceRepository ??
                throw new ArgumentNullException(nameof(attendanceRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<AttendanceDto>> GetStudents()
        {
            var studentFromRepo = _attendanceRepository.GetStudents();
            return Ok(_mapper.Map<IEnumerable<AttendanceDto>>(studentFromRepo));
        }
        [HttpGet("{studentId}", Name = "GetStudent")]
        public IActionResult GetStudent(Guid studentId)
        {
            var studentFromRepo = _attendanceRepository.GetStudentById(studentId);

            if (studentFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AttendanceDto>(studentFromRepo));
        }
        [HttpPost]
        public ActionResult<AttendanceDto> CreateStudent(AttendanceCreationDto student)
        {

            var studentEntity = _mapper.Map<Entities.Attendance>(student);
            _attendanceRepository.AddStudent(studentEntity);
            _attendanceRepository.Commit();

            var studentToReturn = _mapper.Map<AttendanceDto>(studentEntity);
            return CreatedAtRoute("GetStudent",
                new
                {
                 studentId = studentToReturn.Id
                }, studentToReturn

                );
        }
        [HttpDelete("{studentId}")]
        public ActionResult DeleteAuthor(Guid studentId)
        {
            var studentFromRepo = _attendanceRepository.GetStudentById(studentId);

            if (studentFromRepo == null)
            {
                return NotFound();
            }

            _attendanceRepository.DeleteStudent(studentFromRepo);

            _attendanceRepository.Commit();

            return NoContent();
        }

        [HttpPut("{studentId}")]
        public ActionResult UpdateAuthor(Guid studentId, AttendanceCreationDto updatedStudent)
        {
            var studentFromRepo = _attendanceRepository.GetStudentById(studentId);

            if (studentFromRepo == null)
            {
                return NotFound();
            }
            studentFromRepo.FirstName = updatedStudent.FirstName;
            studentFromRepo.LastName = updatedStudent.LastName;
            studentFromRepo.EntryYear = updatedStudent.EntryYear;
            studentFromRepo.Department = updatedStudent.Department;

            _attendanceRepository.UpdateStudent(studentFromRepo);

            _attendanceRepository.Commit();
            return NoContent();
        }
        [HttpOptions]
        public IActionResult GetAttendanceptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

    }
}

  