using BucketList.ViewModels;

namespace BucketList;

public partial class TaskAddingPage : ContentPage
{
	private const string homePage = "//MainPage";

	public TaskAddingPage()
	{
		BindingContext = new TaskAddingViewModel();
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
		Shell.Current.GoToAsync(homePage);
        return true;
    }
}