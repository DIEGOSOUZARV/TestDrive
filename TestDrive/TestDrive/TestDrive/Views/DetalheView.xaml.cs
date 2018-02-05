using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheView : ContentPage
	{
        public DetalheViewModel ViewModel { get; set; }
        public DetalheView ()
		{
			InitializeComponent ();
            this.ViewModel = new DetalheViewModel();
            this.BindingContext = ViewModel;
		}

        
    }
}