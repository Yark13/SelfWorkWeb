namespace WebUniversity.DataLayer.Entity
{
    public class Student : IEntity
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Name => LastName + " " + FirstName;

        public override string ToString()
        {
            return $"ID: {Id}\tGroupID: {GroupId}\tLast name: {LastName}\tFirst name: {FirstName}";
        }
    }
}