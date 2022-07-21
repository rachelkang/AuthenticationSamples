using AzureADSample.ViewModel;

namespace AzureADSample.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	async void LogOutBtn(object sender, EventArgs e)
    {
		// Gal -> add code here .. 
    }
}