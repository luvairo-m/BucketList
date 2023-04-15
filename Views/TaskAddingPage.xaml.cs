using BucketList.ViewModels;

namespace BucketList;

public partial class TaskAddingPage : ContentPage
{
	public TaskAddingPage()
	{
		BindingContext = new TaskAddingViewModel();
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        base.OnBackButtonPressed();

		Shell.Current.GoToAsync("//" + nameof(MainPage));
		return true;
    }
}