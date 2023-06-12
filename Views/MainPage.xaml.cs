using BucketList.Models;
using BucketList.ViewModels;

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

    private void OnInfoButtonClicked(object sender, TappedEventArgs e)
    {

    }
}