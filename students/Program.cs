using System;
using Utils;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    class Program
    {
        static void PrintTopStudentRanks(List<ScoreRecord> scores, List<Student> students, int count)
        {
            var list = scores.GroupJoin(
                students,
                scoreRecord => scoreRecord.StudentNumber,
                student => student.StudentNumber,
                (scoreRecord, student) =>
                new
                {
                    StudentNumber = scoreRecord.StudentNumber,
                    FirstName = student.ElementAt(0).FirstName,
                    LastName = student.ElementAt(0).LastName,
                    Score = scoreRecord.Score
                })
                .GroupBy(scoreRecord => new { ID = scoreRecord.StudentNumber })
                .Select(
                    studentReport => new
                    {
                        FirstName = studentReport.ElementAt(0).FirstName,
                        LastName = studentReport.ElementAt(0).LastName,
                        Average = studentReport.Average(studentScore => studentScore.Score)
                    }
                )
                .OrderByDescending(studentReport => studentReport.Average)
                .Take(count);

            Console.WriteLine(String.Join("\n", list));
        }

        static void Main(string[] args)
        {
            var studentsList = JsonHandler<Student>.retrieveModels("./resources/input/Students.json");
            var scoreRecordsList = JsonHandler<ScoreRecord>.retrieveModels("./resources/input/Scores.json");
            PrintTopStudentRanks(scoreRecordsList, studentsList, 3);
        }
    }
}
