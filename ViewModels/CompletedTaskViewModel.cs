using BucketList.Models;
using System.Collections.ObjectModel;

namespace BucketList.ViewModels
{
    public class CompletedTaskViewModel
    {
        public ObservableCollection<TaskModel> CompletedTasks { get; }

        public CompletedTaskViewModel(ObservableCollection<TaskModel> tasks)
            => CompletedTasks = tasks;
    }
}