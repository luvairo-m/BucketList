using BucketList.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BucketList.ViewModels
{
    internal class ShowTaskViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        public ICommand ReturnCommand { get; }
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

        public event PropertyChangedEventHandler PropertyChanged;

        private string taskTitle, taskDescription;
        
        internal ShowTaskViewModel()
        {
            ReturnCommand = new Command(async () => await Shell.Current.GoToAsync("//MainPage"));
        }

        public void OnPropertyChanged([CallerMemberName] string property = "") 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (!query.ContainsKey("TaskObject"))
                return;

            var task = query["TaskObject"] as TaskModel;
            (TaskTitle, TaskDescription) = (task.Title, task.Description);
        }
    }
}