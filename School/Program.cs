using Core;
using Models;
using Utils;

namespace School
{
    class Program
    {
        const string STUDENTS_FILE_PATH = "./resources/input/Students.json";
        const string RECORDS_FILE_PATH = "./resources/input/Records.json";

        static void Main(string[] args)
        {
            var students = JsonHandler<Student>.RetrieveModels(STUDENTS_FILE_PATH);
            var records = JsonHandler<Record>.RetrieveModels(RECORDS_FILE_PATH);

            var reportManager = new ReportManager(students, records);
            reportManager.PrintTopStudentReports(3);
        }
    }
}
