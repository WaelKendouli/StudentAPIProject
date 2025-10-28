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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
           // StudentsDataSimulation.Students.Clear();
            if (StudentsDataSimulation.Students.Count==0)
            {
                return NotFound("No students are found");
            }
            return Ok(StudentsDataSimulation.Students);
        }


        [HttpGet("Passed" , Name ="PassedStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Student>> GetPassedStudents()
        {
            //StudentsDataSimulation.Students.Clear();
            if (StudentsDataSimulation.Students.Count==0)
            {
              return NotFound("No Students are passed");
            }
            else
            {
            var PassedStudents = StudentsDataSimulation.Students.Where(student => student.Grade > 15);
                return Ok(PassedStudents);
            }
        }
        [HttpGet("AverageGrades", Name = "AVG Grades")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<double> GetAverageGrades()
        {
            //StudentsDataSimulation.Students.Clear();
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
        [HttpGet("{id}", Name = "GetStudentByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Student> GetStudentByID(int id)
        {
            if (id<1)
            {
                return BadRequest("Invalid Request");
            }
            else
            {
                var StudentID = StudentsDataSimulation.Students.FirstOrDefault(s => s.ID == id);
                if (StudentID==null)
                {
                    return NotFound($"{id} was not found");
                }
                else
                {
                    return Ok(StudentID);
                }


            }

        }
        [HttpPost(Name = "AddNewStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<Student> AddNewStudent(Student NewStudent)
        {
            if (string.IsNullOrEmpty(NewStudent.Name)|| NewStudent.ID <= 0 || NewStudent.Age < 0 || NewStudent.Grade <0)
            {
                return BadRequest("Invalid input");

            }
            if (StudentsDataSimulation.Students.Count > 0)
            {
             NewStudent.ID = Convert.ToInt16(StudentsDataSimulation.Students.Max(s => s.ID) + 1);
  
            }
            else
            {
                NewStudent.ID = 1;
            }
            StudentsDataSimulation.Students.Add(NewStudent);
            return CreatedAtRoute("GetStudentByID", new { id = NewStudent.ID }, NewStudent);
        }

        [HttpDelete("{id}", Name = "Delete Student by ID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Student>DeleteStudentByID(int id)
        {
            if (id<1)
            {
                return BadRequest("Bad request");
            }
            else
            {
                var StudentID = StudentsDataSimulation.Students.FirstOrDefault(s => s.ID == id);
                if (StudentID==null)
                {
                    return NotFound("Not found");
                }
                else
                {
                    return Ok(StudentID);
                }

            }

        }

    }
}
