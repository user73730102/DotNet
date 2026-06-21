namespace Ex10_MVC
{
    // The Model Class
    public class Student
    {
        public string RollNo { get; set; }
        public string Name { get; set; }
        
        public Student(string rollNo, string name)
        {
            RollNo = rollNo;
            Name = name;
        }
    }
}
