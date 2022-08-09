﻿namespace MIAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(MainLoginPage), typeof(MainLoginPage));
        Routing.RegisterRoute(nameof(SubtasksPage), typeof(SubtasksPage));
		Routing.RegisterRoute(nameof(NewTaskPage), typeof(NewTaskPage));
		Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
	}
}
