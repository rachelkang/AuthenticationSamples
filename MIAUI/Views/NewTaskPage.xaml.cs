using MIAUI.ViewModels;

namespace MIAUI.View
{
    public partial class NewTaskPage : ContentPage
    {
        public Model.Task Task { get; set; }

        public NewTaskPage(NewItemViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

    }
}