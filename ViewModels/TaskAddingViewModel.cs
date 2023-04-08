using BucketList.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BucketList.ViewModels
{
    internal class TaskAddingViewModel : INotifyPropertyChanged
    {
        public ICommand CancelCreationCommand { get; }
        public ICommand CreateTaskCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string TaskTitle
        {
            get => taskTitle;
            set
            {
                taskTitle = value;
                OnPropertyChanged(nameof(TaskTitle));   
            }
        }
        public string TaskDescription
        {
            get => taskDescription;
            set
            {
                taskDescription = value;    
                OnPropertyChanged(nameof(TaskDescription));
            }
        }

        private string taskTitle;
        private string taskDescription;  

        internal TaskAddingViewModel()
        {
            CancelCreationCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//MainPage");
                ClearFields();
            });

            CreateTaskCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//MainPage", new Dictionary<string, object>
                {
                    { "TaskObject", new TaskModel(TaskTitle, TaskDescription) }
                });

                ClearFields();
            }, () => taskTitle != null && taskDescription != null &&
            taskTitle.Length != 0 && taskDescription.Length != 0);
        }

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            ((Command)CreateTaskCommand).ChangeCanExecute();
        }

        private void ClearFields() => (TaskTitle, TaskDescription) = (null, null);
    }
}