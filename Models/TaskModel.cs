using CommunityToolkit.Mvvm.ComponentModel;

namespace BucketList.Models
{
    public partial class TaskModel : ObservableObject
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime DeadLine { get; private set; }

        public List<SubTaskModel> SubTasks { get; private set; } = new();

        public int CompletedCount { get { return SubTasks.Where(x => x.IsCompleted).Count(); } }

        public string CompletedTaskLine => $"{CompletedCount} / {SubTasks.Count}";

        public string TimeLine => $"{CreationTime:d} => {DeadLine:d}";

        public TaskModel(string title, string description, DateTime deadLine)
        {
            Title = title;
            Description = description;
            CreationTime = DateTime.Now;
            DeadLine = deadLine;
        }   
    }

    public partial class SubTaskModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private bool isCompleted;

        public SubTaskModel(string title) => Title = title;
    }
}