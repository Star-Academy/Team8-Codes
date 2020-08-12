using System;
using System.Collections.Generic;
using System.Linq;

using Models;

namespace Core
{
    public class ReportManager
    {
        List<Student> students;
        List<Record> records;

        public ReportManager(List<Student> students, List<Record> records)
        {
            this.students = students;
            this.records = records;
        }

        public IEnumerable<StudentReport> GetTopStudentReports(int count)
        {
            var studentReports = GetAllStudentReports();
            var sortedReports = studentReports.OrderByDescending(studentReport => studentReport.Average);
            return sortedReports.Take(count);
        }

        public void PrintTopStudentReports(int count)
        {
            var topStudentReports = GetTopStudentReports(count);
            Console.WriteLine(String.Join("\n", topStudentReports));
        }

        private IEnumerable<StudentReport> GetAllStudentReports()
        {
            return students.GroupJoin(records,
                                      student => student.StudentNumber,
                                      records => records.StudentNumber,
                                      (student, records) => new StudentReport()
                                      {
                                          FirstName = student.FirstName,
                                          LastName = student.LastName,
                                          Average = records.Average(record => record.Score)
                                      });
        }
    }
}