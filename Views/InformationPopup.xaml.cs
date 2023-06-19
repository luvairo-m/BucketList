using BucketList.Models;
using BucketList.ViewModels;
using CommunityToolkit.Maui.Views;

namespace BucketList.Views;

public partial class InformationPopup : Popup
{
    private TaskModel currentTask;

	public InformationPopup() => InitializeComponent();

    public InformationPopup(TaskModel task) : this()
    {
        currentTask = task;
        BindingContext = new InformationPopupViewModel(task);

        if (currentTask.SubTasks.Count == 0)
            finishButton.IsEnabled = true;
    }

    private void SaveButtonClicked(object sender, EventArgs e) => Close(false);

    private void FinishButtonClicked(object sender, EventArgs e) => Close(true);

    private void OnCheck(object sender, CheckedChangedEventArgs e)
    {
        var completedCount = currentTask.SubTasks.Where(task => task.IsCompleted).Count();
        currentTask.CompletedTaskCount = completedCount;

        if (completedCount == currentTask.SubTasks.Count) finishButton.IsEnabled = true;
        else finishButton.IsEnabled = false;    
    }
}