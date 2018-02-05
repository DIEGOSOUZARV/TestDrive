using System;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListagemView : ContentPage
	{
        public ListagemViewModel ViewModel { get; set; }

		public ListagemView ()
		{
			InitializeComponent ();
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = ViewModel;
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", 
                (msg) =>
                {
                    Navigation.PushAsync(new DetalheView());
                }
            );

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
                (msg) =>
                {
                    DisplayAlert(
                        "Erro",
                        msg.Message,
                        "Ok"
                    );
                }
            );

            await ViewModel.GetVeiculos();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
        }

    }
}