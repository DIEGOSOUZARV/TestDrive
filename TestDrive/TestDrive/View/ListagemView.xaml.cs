using System;
using TestDrive.Mode;
using TestDrive.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.View
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

            await ViewModel.GetVeiculos();

            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionando", 
                (msg) =>
                {
                    Navigation.PushAsync(new DetalheView(msg));
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
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionando");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
               
        }

    }
}