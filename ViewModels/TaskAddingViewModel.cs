using BucketList.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Toast = CommunityToolkit.Maui.Alerts.Toast;
using CommunityToolkit.Maui.Core;

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
        private bool isKeyboardEnabled = true;

        [ObservableProperty]
        private DateTime deadLine;

        [ObservableProperty]
        private SubTaskModel selectedSubTask;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CreateTaskCommand))]
        private string taskDescription;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddSubTaskCommand))]
        private string subTaskTitle;    

        [RelayCommand]
        private async void CancelCreation()
        {
            if (await Application.Current.MainPage.DisplayAlert("Предупреждение",
                "Вы действительно желаете выйти из создания цели?", "Да", "Нет"))
                await Shell.Current.GoToAsync("//" + nameof(MainPage));
        }

        [RelayCommand]
        private async void EditSubTask(object param)
        {
            if (SelectedSubTask == null)
                return;

            var action = await Application.Current.MainPage.DisplayActionSheet("Выберите действие",
                "Отменить", null, "Редактировать подзадачу", "Изменить порядок подзадач", "Удалить подзадачу");

            if (action == "Редактировать подзадачу")
            {
                var newTitle = await Application.Current.MainPage.DisplayPromptAsync("Редактирование",
                    "Введите новый заголовок подзадачи:", "Принять", null, initialValue: SelectedSubTask.Title);

                if (newTitle != null && newTitle != string.Empty)
                {
                    var index = SubTasks.IndexOf(SelectedSubTask);
                    SubTasks.Remove(SelectedSubTask);
                    SubTasks.Insert(index, new(newTitle));
                }
            }

            else if (action == "Изменить порядок подзадач")
            {
                var movement = await Application.Current.MainPage.DisplayPromptAsync("Изменение порядка следования",
                    $"Укажите новую позицию (от 1 до {SubTasks.Count}):", "Принять", null);

                if (movement != null)
                    if (int.TryParse(movement, out int index))
                        if (index > 0 && index <= SubTasks.Count)
                        {
                            var currentPosition = SubTasks.IndexOf(SelectedSubTask);
                            (SubTasks[currentPosition], SubTasks[index - 1]) = (SubTasks[index - 1], SubTasks[currentPosition]);
                        }
                        else
                            await Toast.Make("Некорректная позиция", ToastDuration.Long).Show();
                    else
                        await Toast.Make("Некорректное число", ToastDuration.Long).Show();
            }

            else if (action == "Удалить подзадачу")
                SubTasks.Remove(SelectedSubTask);

            SelectedSubTask = null;
        }

        [RelayCommand(CanExecute = nameof(CanTaskCreate))]
        private async void CreateTask()
        {
            if (DeadLine < DateTime.Now.AddDays(-1))
            {
                await Application.Current.MainPage.DisplayAlert("Предупреждение", "Выбрана некорректная дата", "Принять");
                return;
            }

            var task = new TaskModel(TaskTitle, TaskDescription, DeadLine);

            foreach (var subTask in SubTasks)
                task.SubTasks.Add(subTask);

            var arguments = new Dictionary<string, object>()
            {
                ["TaskObject"] = task
            };

            await Shell.Current.GoToAsync("//" + nameof(MainPage), arguments);
        }

        [RelayCommand(CanExecute = nameof(CanSubTaskAdd))]
        private void AddSubTask()
        {
            SubTasks.Add(new(SubTaskTitle));
            SubTaskTitle = null;
            IsKeyboardEnabled = false;
            IsKeyboardEnabled = true;
        }

        [RelayCommand]
        private void RemoveSubTask(object param) => SubTasks.Remove(param as SubTaskModel);
    }
}