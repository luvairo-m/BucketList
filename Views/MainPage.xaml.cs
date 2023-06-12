using BucketList.Models;
using BucketList.ViewModels;
using BucketList.Views;
using CommunityToolkit.Maui.Views;

namespace BucketList;

public partial class MainPage : ContentPage
{
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
}