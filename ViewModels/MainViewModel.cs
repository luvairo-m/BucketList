using BucketList.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BucketList.ViewModels
{
    public partial class MainViewModel : IQueryAttributable
    {
        public ObservableCollection<TaskModel> Tasks { get; } = new();
        public ObservableCollection<TaskModel> CompletedTasks { get; } = new();

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (!query.ContainsKey("TaskObject"))
                return;

            var task = query["TaskObject"] as TaskModel;
            Tasks.Add(task);

            query.Clear();
        }

        [RelayCommand]
        private async void AddTask() => await Shell.Current.GoToAsync(nameof(TaskAddingPage));
    }
}