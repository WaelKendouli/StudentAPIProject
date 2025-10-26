using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPIProject.DataSimulation;
using StudentAPIProject.Modles;

namespace StudentAPIProject.Controllers
{
    [Route("api/StudentsAPI")]
    [ApiController]
    public class StudentsAPIController : ControllerBase
    {
        [HttpGet("All" , Name = "GetAllStudents")]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return Ok(StudentsDataSimulation.Students);
        }
        [HttpGet("Passed" , Name ="PassedStudents")]

        public ActionResult<IEnumerable<Student>> GetPassedStudents()
        {
            var PassedStudents = StudentsDataSimulation.Students.Where(student => student.Grade > 15);
            return Ok(PassedStudents);
        }
        [HttpGet("AverageGrades", Name = "AVG Grades")]
        public ActionResult<double> GetAverageGrades()
        {
            if (StudentsDataSimulation.Students.Count==0)
            {
                return NotFound("No students data are available");
            }
            else
            {
                var AvgGrades = StudentsDataSimulation.Students.Average(student => student.Grade);
                return Ok(AvgGrades);
            }
        }

    }
}
