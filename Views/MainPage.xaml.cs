using BucketList.ViewModels;

namespace BucketList;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		BindingContext = new MainViewModel();
		InitializeComponent();
	}
}