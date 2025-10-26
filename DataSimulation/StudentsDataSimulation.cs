
using StudentAPIProject.Modles;

namespace StudentAPIProject.DataSimulation
{
    public class StudentsDataSimulation
    {
        public static readonly List<Student> Students = new List<Student>
            {
            new Student{ Name = "Wael" , Age = 21 , Grade =15 , ID = 35 } ,
            new Student{ Name = "Oumaima" , Age = 15 , Grade = 20 , ID =14 } ,
            new Student{ Name = "Khalid" , Age = 19 , Grade = 20 , ID =16 },
            new Student{ Name = "Faisal" , Age = 17 , Grade = 14 , ID =18 },
            new Student{ Name = "Salim" , Age = 35 , Grade = 20 , ID =14 }
            };

    }
}
