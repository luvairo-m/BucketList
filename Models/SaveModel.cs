using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace BucketList.Models
{
    public class SaveModel
    {
        [JsonPropertyName("active")]
        public ObservableCollection<TaskModel> Tasks { get; set; }

        [JsonPropertyName("completed")]
        public ObservableCollection<TaskModel> CompletedTasks { get; set; }
    }
}