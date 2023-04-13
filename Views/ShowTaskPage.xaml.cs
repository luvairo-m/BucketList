using BucketList.ViewModels;

namespace BucketList.Views;

public partial class ShowTaskPage : ContentPage
{
    private const string homePage = "//MainPage";

	public ShowTaskPage()
	{
		BindingContext = new ShowTaskViewModel();
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync(homePage);
        return true;
    }
}