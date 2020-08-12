namespace Models
{
    public class Record
    {
        public int StudentNumber { get; set; }
        public string Lesson { get; set; }
        public float Score { get; set; }

        public override string ToString()
        {
            return $"ScoreRecord({Lesson}: {StudentNumber} {Score})";
        }
    }
}