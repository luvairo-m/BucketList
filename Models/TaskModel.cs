using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace BucketList.Models
{
    public partial class TaskModel : ObservableObject
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime DeadLine { get; private set; }

        public ObservableCollection<SubTaskModel> SubTasks { get; set; } = new();
        public string TimeLine => $"{CreationTime:d} => {DeadLine:d}";

        [ObservableProperty]
        public int completedTaskCount;

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
        [JsonPropertyName("title")]
        [ObservableProperty]
        private string title;

        [JsonPropertyName("isCompleted")]
        [ObservableProperty]
        private bool isCompleted;

        public SubTaskModel(string title) => Title = title;
    }
}