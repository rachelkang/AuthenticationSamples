namespace MIAUI.Views;

public partial class NewTaskPage : ContentPage
{
	public NewTaskPage()
	{
		InitializeComponent();
		BindingContext = new TasksViewModel();
	}
}
