using BucketList.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BucketList.ViewModels
{
    public partial class InformationPopupViewModel : ObservableObject
    {
        [ObservableProperty]
        private TaskModel currentTask;

        [ObservableProperty]
        private bool isFinished;

        public InformationPopupViewModel(TaskModel task)
            => CurrentTask = task;
    }
}