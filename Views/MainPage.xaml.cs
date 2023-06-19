using BucketList.Models;
using BucketList.ViewModels;
using BucketList.Views;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace BucketList;

public partial class MainPage : ContentPage
{
	private int clickCount = 0;

	public MainPage()
	{
		BindingContext = new MainViewModel();
		InitializeComponent();
	}

    private async void OnDeleteButtonClicked(object sender, TappedEventArgs e)
    {
		var task = e.Parameter as TaskModel;
		var status = await Application.Current.MainPage.DisplayAlert("Удаление цели",
			"Вы действительно хотите удалить цель?", "Да", "Нет");

		if (status) 
			(BindingContext as MainViewModel).Tasks.Remove(task);
    }

    private async void OnInfoButtonClicked(object sender, TappedEventArgs e) =>
		await this.ShowPopupAsync(new InformationPopup(e.Parameter as TaskModel));

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