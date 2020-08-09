namespace Models
{
    public class Student
    {
        public Student(int studentNumber, string firstName, string lastName)
        {
            StudentNumber = studentNumber;
            FirstName = firstName;
            LastName = lastName;
        }

        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float AverageScore { get; set; }

        public override string ToString()
        {
            return string.Format("Student({0}: {1} {2})", StudentNumber, FirstName, LastName);
        }
    }
}