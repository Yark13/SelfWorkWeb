using WebUniversity.DataLayer.Entity;

namespace WebUniversity.DataLayer
{
    public class FillerDBData
    {
        private Course[] DBCourses = new Course[]
        {
            new Course{
                        Id = 1,
                        Name = "Mathematics",
                        Description = "Basic mathematics course"},
            new Course{
                        Id = 2,
                        Name = "English",
                        Description = "Basic English course"},
            new Course{
                        Id = 3,
                        Name = "History of world",
                        Description = "Basic history course"},
            new Course{
                        Id = 24,
                        Name = "The Geografy",
                        Description = "Some about world"},
            new Course{
                        Id = 25,
                        Name = "Astronomy",
                        Description = "About stars"}
        };

        private Group[] DBGroups = new Group[]
        {
            new Group{
                        Id = 1,
                        Name = "MA-01",
                        CourseID = 1},
            new Group{
                        Id = 2,
                        Name = "MA-02",
                        CourseID = 1},
            new Group{
                        Id = 3,
                        Name = "EN-01",
                        CourseID = 2},
            new Group{
                        Id = 4,
                        Name = "EN-02",
                        CourseID = 2},
            new Group{
                        Id = 5,
                        Name = "HI-01(modified)",
                        CourseID = 3},
            new Group{
                        Id = 6,
                        Name = "HI-02",
                        CourseID = 3},
            new Group{
                        Id = 12,
                        Name = "SR-01",
                        CourseID = 24},
            new Group{
                        Id = 35,
                        Name = "HI-03",
                        CourseID = 3},
            new Group{
                        Id = 39,
                        Name = "Fi-01",
                        CourseID = 2},
            new Group{
                        Id = 46,
                        Name = "ZI-1",
                        CourseID = 25},
            new Group{
                        Id = 54,
                        Name = "HI-04",
                        CourseID = 3},
            new Group{
                        Id = 56,
                        Name = "SR-02",
                        CourseID = 24},
            new Group{
                        Id = 58,
                        Name = "HI-04",
                        CourseID = 24},
            new Group{
                        Id = 59,
                        Name = "HI-04",
                        CourseID = 3}
        };

        private Student[] DBstudents = new Student[]
        {
            new Student { Id = 63, GroupId = 1, LastName = "Doe", FirstName = "John" },
            new Student { Id = 64, GroupId = 1, LastName = "Doe", FirstName = "Jane" },
            new Student { Id = 65, GroupId = 2, LastName = "Smith", FirstName = "Bob" },
            new Student { Id = 66, GroupId = 2, LastName = "Smith", FirstName = "Alice" },
            new Student { Id = 67, GroupId = 3, LastName = "Johnson", FirstName = "David" },
            new Student { Id = 68, GroupId = 4, LastName = "Johnson", FirstName = "Sarah" },
            new Student { Id = 69, GroupId = 4, LastName = "Brown", FirstName = "Mike" },
            new Student { Id = 70, GroupId = 4, LastName = "Brown", FirstName = "Lisa" },
            new Student { Id = 71, GroupId = 5, LastName = "Wilson", FirstName = "Tom" },
            new Student { Id = 72, GroupId = 5, LastName = "Wilson", FirstName = "Mary" },
            new Student { Id = 73, GroupId = 6, LastName = "Lee", FirstName = "Chris" },
            new Student { Id = 74, GroupId = 6, LastName = "Lee", FirstName = "Kim" },
            new Student { Id = 75, GroupId = 1, LastName = "Jones", FirstName = "Mark" },
            new Student { Id = 76, GroupId = 1, LastName = "Jones", FirstName = "Emily" },
            new Student { Id = 77, GroupId = 2, LastName = "Smith", FirstName = "Eric" },
            new Student { Id = 78, GroupId = 2, LastName = "Johnson", FirstName = "Grace" },
            new Student { Id = 79, GroupId = 3, LastName = "Brown", FirstName = "Alex" },
            new Student { Id = 80, GroupId = 3, LastName = "Wilson", FirstName = "Olivia" },
            new Student { Id = 81, GroupId = 4, LastName = "Lee", FirstName = "Ryan" },
            new Student { Id = 82, GroupId = 4, LastName = "Lee", FirstName = "Rachel" },
            new Student { Id = 83, GroupId = 5, LastName = "Davis", FirstName = "Daniel" },
            new Student { Id = 84, GroupId = 5, LastName = "Davis", FirstName = "Maggie" },
            new Student { Id = 85, GroupId = 6, LastName = "Wang", FirstName = "Ben" },
            new Student { Id = 86, GroupId = 6, LastName = "Wang", FirstName = "Sophie" },
            new Student { Id = 87, GroupId = 1, LastName = "Gonzalez", FirstName = "Peter" },
            new Student { Id = 88, GroupId = 1, LastName = "Gonzalez", FirstName = "Cindy" },
            new Student { Id = 89, GroupId = 2, LastName = "Allen", FirstName = "Adam" },
            new Student { Id = 90, GroupId = 2, LastName = "Allen", FirstName = "Eva" },
            new Student { Id = 91, GroupId = 3, LastName = "Nguyen", FirstName = "Frankov" },
            new Student { Id = 92, GroupId = 3, LastName = "Nguyen", FirstName = "Amy" },
            new Student { Id = 93, GroupId = 1, LastName = "Doe", FirstName = "John" },
            new Student { Id = 94, GroupId = 1, LastName = "Doe", FirstName = "Jane" },
            new Student { Id = 95, GroupId = 2, LastName = "Smith", FirstName = "Bob" },
            new Student { Id = 96, GroupId = 2, LastName = "Smith", FirstName = "Alice" },
            new Student { Id = 97, GroupId = 3, LastName = "Johnson", FirstName = "David" },
            new Student { Id = 98, GroupId = 3, LastName = "Johnson", FirstName = "Sarah" },
            new Student { Id = 99, GroupId = 4, LastName = "Brown", FirstName = "Mike" },
            new Student { Id = 100, GroupId = 4, LastName = "Brown", FirstName = "Lisa" },
            new Student { Id = 101, GroupId = 5, LastName = "Wilson", FirstName = "Tom" },
            new Student { Id = 102, GroupId = 5, LastName = "Wilson", FirstName = "Mary" },
            new Student { Id = 103, GroupId = 6, LastName = "Lee", FirstName = "Chris" },
            new Student { Id = 104, GroupId = 6, LastName = "Lee", FirstName = "Kim" },
            new Student { Id = 105, GroupId = 1, LastName = "Jones", FirstName = "Mark" },
            new Student { Id = 106, GroupId = 1, LastName = "Jones", FirstName = "Emily" },
            new Student { Id = 107, GroupId = 2, LastName = "Smith", FirstName = "Eric" },
            new Student { Id = 108, GroupId = 2, LastName = "Johnson", FirstName = "Grace" },
            new Student { Id = 109, GroupId = 35, LastName = "Brown", FirstName = "Alex" },
            new Student { Id = 110, GroupId = 39, LastName = "Wilson", FirstName = "Olivia" },
            new Student { Id = 111, GroupId = 4, LastName = "Lee", FirstName = "Ryan" },
            new Student { Id = 112, GroupId = 46, LastName = "Lee", FirstName = "Rachel" },
            new Student { Id = 113, GroupId = 5, LastName = "Davis", FirstName = "Daniel" },
            new Student { Id = 114, GroupId = 5, LastName = "Davis", FirstName = "Maggie" },
            new Student { Id = 115, GroupId = 6, LastName = "Wang", FirstName = "Ben" },
            new Student { Id = 116, GroupId = 6, LastName = "Wang", FirstName = "Sophie" },
            new Student { Id = 117, GroupId = 1, LastName = "Gonzalez", FirstName = "Peter" },
            new Student { Id = 118, GroupId = 1, LastName = "Gonzalez", FirstName = "Cindy" },
            new Student { Id = 119, GroupId = 2, LastName = "Allen", FirstName = "Adam" },
            new Student { Id = 120, GroupId = 2, LastName = "Allen", FirstName = "Eva" },
            new Student { Id = 121, GroupId = 3, LastName = "Nguyen", FirstName = "Frank" },
            new Student { Id = 122, GroupId = 3, LastName = "Nguyen", FirstName = "Amy" },
            new Student { Id = 125, GroupId = 4, LastName = "Lozynskyi", FirstName = "Oleg" },
            new Student { Id = 129, GroupId = 2, LastName = "Ivasuk", FirstName = "Dmytro" },
            new Student { Id = 131, GroupId = 12, LastName = "Savchyn", FirstName = "Dmytro" },
            new Student { Id = 136, GroupId = 54, LastName = "Vasylyshyn", FirstName = "Oleg" }
        };

        public Course[] Courses
        {
            get { return DBCourses; }
        }

        public Group[] Groups
        {
            get { return DBGroups; }
        }

        public Student[] Students
        {
            get { return DBstudents; }
        }
    }
}
