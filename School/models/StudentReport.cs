namespace Models
{
    public class StudentReport
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Average { get; set; }

        public override string ToString()
        {
            return string.Format("StudentReport({0} {1}: {2})", FirstName, LastName, Average);
        }
    }
}