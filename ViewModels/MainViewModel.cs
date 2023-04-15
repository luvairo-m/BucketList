using BucketList.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BucketList.ViewModels
{
    public partial class MainViewModel : IQueryAttributable
    {
        public ObservableCollection<TaskModel> Tasks { get; } = new();

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (!query.ContainsKey("TaskObject"))
                return;

            var task = query["TaskObject"] as TaskModel;
            Tasks.Add(task);
        }

        [RelayCommand]
        private void RemoveTask(object param) => Tasks.Remove((TaskModel)param);

        [RelayCommand]
        private async void AddTask() => await Shell.Current.GoToAsync("//" + nameof(TaskAddingPage));
    }
}