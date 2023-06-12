using BucketList.Models;
using BucketList.ViewModels;
using CommunityToolkit.Maui.Views;

namespace BucketList.Views;

public partial class InformationPopup : Popup
{
	public InformationPopup() => InitializeComponent();

	public InformationPopup(TaskModel task) : this()
		=> BindingContext = new InformationPopupViewModel(task);
}