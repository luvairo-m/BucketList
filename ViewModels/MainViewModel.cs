using BucketList.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BucketList.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        public ICommand AddTaskCommand { get; }
        public ICommand RemoveTaskCommand { get; }
        public ICommand ShowTaskCommand { get; }

        public ObservableCollection<TaskModel> Tasks { get; } = new();
        public event PropertyChangedEventHandler PropertyChanged;

        internal MainViewModel()
        {
            ShowTaskCommand = new Command(async (param) =>
            {
                await Shell.Current.GoToAsync("//ShowTaskPage", new Dictionary<string, object>()
                {
                    { "TaskObject", (TaskModel)param }
                });
            });

            AddTaskCommand = new Command(async () => await Shell.Current.GoToAsync("//TaskAddingPage"));
            RemoveTaskCommand = new Command((param) => Tasks.Remove((TaskModel)param));
        }

        public void OnPropertyChanged([CallerMemberName] string property = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (!query.ContainsKey("TaskObject"))
                return;

            var task = query["TaskObject"] as TaskModel;
            Tasks.Add(task);
        }
    }
}