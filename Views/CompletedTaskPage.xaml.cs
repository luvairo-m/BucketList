using BucketList.ViewModels;

namespace BucketList.Views;

public partial class CompletedTaskPage : ContentPage
{
	public CompletedTaskPage()
	{
		BindingContext = new CompletedTaskViewModel((MainPage.Context as MainViewModel).CompletedTasks);
		InitializeComponent();
	}

	protected override bool OnBackButtonPressed() => true;
}