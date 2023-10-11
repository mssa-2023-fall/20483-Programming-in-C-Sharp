namespace GradesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
            GradesPrototype.Data.DataSource.CreateData();
        }

        [TestMethod]
        public void TestValidGrade()
        {
            //Assign
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "01/01/2012", "Math", "A-", "Very good");

            //Assert
            Assert.AreEqual(grade.AssessmentDate, "1/1/2012");
            Assert.AreEqual(grade.SubjectName, "Math");
            Assert.AreEqual(grade.Assessment, "A-");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(1, "01/01/2212", "Math", "A-", "Very good")]

        [DataRow(1, "01/01/5512", "Math", "A-", "Very good")]

        [DataRow(1, "01/01/9999", "English", "A-", "Very good")]

        [DataRow(1, "01/01/2192", "Math", "D-", "Very good")]
        public void TestBadDate(int studentId, string assessmentDate, string subject, string assessment, string comments)
        {
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(
                                                        studentId,  
                                                        assessmentDate, 
                                                        subject, 
                                                        assessment, 
                                                        comments);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(1, "aa", "Math", "A-", "Very good")]

        [DataRow(1, "222", "Math", "A-", "Very good")]

        [DataRow(1, "Batman", "English", "A-", "Very good")]

        [DataRow(1, "01/01/20192", "Math", "D-", "Very good")]
        public void TestDateNotRecognized(int studentId, string assessmentDate, string subject, string assessment, string comments)
        {
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(
                                                        studentId,
                                                        assessmentDate,
                                                        subject,
                                                        assessment,
                                                        comments);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("F-")]
        [DataRow("AAAAAAA?2")]
        [DataRow("DEF")]
        public void TestBadAssessment(string assessment)
        {
            //Assign
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "01/01/2012", "Math", assessment, "Very good");

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("maths")]
        [DataRow("batman?2")]
        [DataRow("1482765")]
        public void TestBadSubject(string subject)
        {
            //Assign
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "01/01/2012", subject, "A-", "Very good");

        }
    }
}