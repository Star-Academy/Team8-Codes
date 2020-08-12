namespace Models
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format($"Student({StudentNumber}: {FirstName} {LastName})");
        }
    }
}