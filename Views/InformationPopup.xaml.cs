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
    }

    private void CloseButtonClicked(object sender, EventArgs e)
    {
        currentTask.CompletedTaskCount = currentTask.SubTasks.Where(task => task.IsCompleted).Count();
        Close();
    }
}