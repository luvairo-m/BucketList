using BucketList.Models;
using BucketList.ViewModels;
using System.Text.Json;
using Mainpage = BucketList.MainPage;

namespace BucketList;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

		window.Stopped += (s, e) =>
		{
            var viewModel = Mainpage.Context as MainViewModel;

            var data = new SaveModel
            {
                Tasks = viewModel.Tasks,
                CompletedTasks = viewModel.CompletedTasks
            };

            File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, MainViewModel.saveFilename),
                JsonSerializer.Serialize(data));
        };

		return window;
    }
}