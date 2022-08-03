using FireBaseAuthSample.ViewModel;

namespace FireBaseAuthSample.View;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm; 
	}
}