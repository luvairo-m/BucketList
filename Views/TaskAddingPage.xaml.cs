using BucketList.ViewModels;

namespace BucketList;

public partial class TaskAddingPage : ContentPage
{
    private const string mainPageRoute = "//" + nameof(MainPage);

	public TaskAddingPage()
	{
		BindingContext = new TaskAddingViewModel();
		InitializeComponent();
	}

    /// <summary>
    /// ����� �������������� ����������� ��������� ��� ������� ������ "�����"
    /// �� ���������, ����������� ��������� � MainPage.
    /// </summary>
    protected override bool OnBackButtonPressed()
    {
		Shell.Current.GoToAsync(mainPageRoute);
        return true;
    }
}