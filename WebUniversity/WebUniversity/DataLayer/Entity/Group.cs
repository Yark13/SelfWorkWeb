namespace WebUniversity.DataLayer.Entity
{
    public class Group : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CourseID { get; set; }

        public Course Course { get; set; }

        public List<Student> Students { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}\tName: {Name}\tCourseID: {CourseID}";
        }

    }
}
