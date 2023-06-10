namespace BucketList.Models
{
    public class TaskModel
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationTime { get; private set; }

        public List<SubTaskModel> SubTasks { get; private set; } = new();

        public int UncompletedSubTasks { get { return SubTasks.Count - SubTasks.Where(x => x.IsCompleted).Count(); } }
        public string UncompletedTasksLine => $"{UncompletedSubTasks} / {SubTasks.Count}";

        public TaskModel(string title, string description)
        {
            Title = title;
            Description = description;
            CreationTime = DateTime.Now;
        }   
    }

    public class SubTaskModel
    {
        public string Title { get; private set; }
        public bool IsCompleted { get; private set; } = false;

        public SubTaskModel(string title) => Title = title;
    }
}