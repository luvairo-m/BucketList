﻿namespace BucketList;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(TaskAddingPage), typeof(TaskAddingPage));
	}
}