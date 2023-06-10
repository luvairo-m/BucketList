using BucketList.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BucketList.ViewModels
{
    internal partial class TaskAddingViewModel : ObservableObject
    {
        public bool CanTaskCreate => TaskTitle != null && TaskDescription != null &&
            TaskTitle.Length != 0 && TaskDescription.Length != 0;

        public bool CanSubTaskAdd => SubTaskTitle != null && SubTaskTitle.Length != 0;

        public ObservableCollection<SubTaskModel> SubTasks { get; } = new();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CreateTaskCommand))]
        private string taskTitle;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CreateTaskCommand))]
        private string taskDescription;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddSubTaskCommand))]
        private string subTaskTitle;

        [RelayCommand]
        private async void CancelCreation()
        {
            ClearInputFields();
            await Shell.Current.GoToAsync("//" + nameof(MainPage));
        }

        [RelayCommand(CanExecute = nameof(CanTaskCreate))]  
        private async void CreateTask()
        {
            var task = new TaskModel(TaskTitle, TaskDescription);
            task.SubTasks.AddRange(SubTasks);
            var arguments = new Dictionary<string, object>()
            {
                ["TaskObject"] = task
            };

            await Shell.Current.GoToAsync("//" + nameof(MainPage), arguments);
            ClearInputFields();
        }

        [RelayCommand(CanExecute = nameof(CanSubTaskAdd))]
        private void AddSubTask()
        {
            SubTasks.Add(new(SubTaskTitle));
            SubTaskTitle = null;
        }

        [RelayCommand]
        private void RemoveSubTask(object param) => SubTasks.Remove(param as SubTaskModel);

        private void ClearInputFields()
        {
            TaskTitle = null;
            TaskDescription = null;
            SubTaskTitle = null;
            SubTasks.Clear();
        }
    }
}