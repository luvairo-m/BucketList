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
}