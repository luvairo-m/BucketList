namespace BucketList.Models
{
    public class TaskModel
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationTime { get; private set; }  

        public TaskModel(string title, string description)
        {
            Title = title;
            Description = description;
            CreationTime = DateTime.Now;
        }   
    }
}