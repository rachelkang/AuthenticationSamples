using Microsoft.Toolkit.Mvvm.Input;

namespace AuthenticationSimpleSample;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private void Back(object sender, EventArgs e) => Shell.Current.GoToAsync("..");
}