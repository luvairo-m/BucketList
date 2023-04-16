using CommunityToolkit.Maui.Views;

namespace BucketList.Views;

public partial class DeletionConfirmationPopup : Popup
{
	public DeletionConfirmationPopup() => InitializeComponent();

    private void DeleteButtonClicked(object sender, EventArgs e) => Close(true);
	private void CancelButtonClicked(object sender, EventArgs e) => Close(false);
}