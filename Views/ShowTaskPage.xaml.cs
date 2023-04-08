using BucketList.ViewModels;

namespace BucketList.Views;

public partial class ShowTaskPage : ContentPage
{
	public ShowTaskPage()
	{
		BindingContext = new ShowTaskViewModel();
		InitializeComponent();
	}
}