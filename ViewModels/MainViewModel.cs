using BucketList.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace BucketList.ViewModels
{
    public partial class MainViewModel : IQueryAttributable
    {
        public const string saveFilename = "app_data.json";

        public ObservableCollection<TaskModel> Tasks { get; set; } = new();
        public ObservableCollection<TaskModel> CompletedTasks { get; set; } = new();

        public MainViewModel() => Task.Run(LoadData);

        public async Task LoadData()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, saveFilename);

            try
            {
                using var file = new StreamReader(path);
                var data = await JsonSerializer.DeserializeAsync<SaveModel>(file.BaseStream);
                foreach (var task in data.Tasks) Tasks.Add(task);
                foreach (var completedTask in data.CompletedTasks) CompletedTasks.Add(completedTask);
            } catch { }
        }

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