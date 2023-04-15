using BucketList.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BucketList.ViewModels
{
    internal partial class TaskAddingViewModel : ObservableObject
    {
        public bool CanTaskCreate => TaskTitle != null && TaskDescription != null &&
            TaskTitle.Length != 0 && TaskDescription.Length != 0;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CreateTaskCommand))]
        private string taskTitle;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CreateTaskCommand))]
        private string taskDescription;

        [RelayCommand]
        private async void CancelCreation()
        {
            ClearInputFields();
            await Shell.Current.GoToAsync("//" + nameof(MainPage));
        }

        [RelayCommand(CanExecute = nameof(CanTaskCreate))]  
        private async void CreateTask()
        {
            var arguments = new Dictionary<string, object>()
            {
                ["TaskObject"] = new TaskModel(TaskTitle, TaskDescription)
            };

            await Shell.Current.GoToAsync("//" + nameof(MainPage), arguments);
            ClearInputFields();
        }

        private void ClearInputFields() => (TaskTitle, TaskDescription) = (null, null);
    }
}