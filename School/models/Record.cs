namespace Models
{
    public class Record
    {
        public int StudentNumber { get; set; }
        public string Lesson { get; set; }
        public float Score { get; set; }

        public override string ToString()
        {
            return string.Format("ScoreRecord({0}: {1} {2})", Lesson, StudentNumber, Score);
        }
    }
}