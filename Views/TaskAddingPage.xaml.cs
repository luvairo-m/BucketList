using BucketList.ViewModels;

namespace BucketList;

public partial class TaskAddingPage : ContentPage
{
	public TaskAddingPage()
	{
		BindingContext = new TaskAddingViewModel();
		InitializeComponent();
	}

	protected override bool OnBackButtonPressed() => true;
}