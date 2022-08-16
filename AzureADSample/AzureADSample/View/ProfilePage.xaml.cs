using AzureADSample.Service;
using AzureADSample.ViewModel;
using Microsoft.Identity.Client;

namespace AzureADSample.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage ()
	{
		InitializeComponent ();
		BindingContext = new ProfilePageViewModel ();
	}
}
