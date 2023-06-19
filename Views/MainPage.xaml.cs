using BucketList.Models;
using BucketList.ViewModels;
using BucketList.Views;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace BucketList;

public partial class MainPage : ContentPage
{
	public static object Context;

	private int clickCount = 0;

	public MainPage()
	{
		BindingContext = new MainViewModel();
		Context = BindingContext;
		InitializeComponent();
	}

    private async void OnDeleteButtonClicked(object sender, TappedEventArgs e)
    {
		var task = e.Parameter as TaskModel;
		var status = await Application.Current.MainPage.DisplayAlert("Удаление цели",
			"Вы действительно хотите удалить цель? Она не будет считаться выполненной.", "Да", "Нет");

		if (status)
			DeleteTask(task);
    }

    private async void OnInfoButtonClicked(object sender, TappedEventArgs e)
	{
		var taskModel = e.Parameter as TaskModel;

		if ((bool)await this.ShowPopupAsync(new InformationPopup(taskModel)))
			DeleteTask(taskModel, true);
	}

	private void DeleteTask(TaskModel task, bool addToCompleted = false)
	{
        var viewModel = BindingContext as MainViewModel;

		if (addToCompleted)
			viewModel.CompletedTasks.Add(task);

        viewModel.Tasks.Remove(task);

		if (addToCompleted)
			Toast.Make("Цель отмечена, как выполненная!", ToastDuration.Long).Show();
		else
            Toast.Make("Цель удалена!", ToastDuration.Long).Show();
    }

    protected override bool OnBackButtonPressed()
    {
		if (++clickCount == 2)
		{
			clickCount = 0;
			return base.OnBackButtonPressed();
		}
		else
            Toast.Make("Нажмите ещё раз для выхода из приложения", ToastDuration.Long).Show();

		return true;
    }
}