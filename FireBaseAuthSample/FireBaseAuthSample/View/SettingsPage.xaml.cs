using FireBaseAuthSample.ViewModel;

namespace FireBaseAuthSample.View;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm; 
	}
}