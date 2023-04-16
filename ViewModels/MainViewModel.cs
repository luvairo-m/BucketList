using BucketList.Models;
using BucketList.Views;
using CommunityToolkit.Maui.Views;
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
        private async void RemoveTask(object param)
        {
            var status = await App.Current.MainPage.ShowPopupAsync(new DeletionConfirmationPopup());

            if ((bool)status)
                Tasks.Remove((TaskModel)param);
        }

        [RelayCommand]
        private async void AddTask() => await Shell.Current.GoToAsync("//" + nameof(TaskAddingPage));
    }
}