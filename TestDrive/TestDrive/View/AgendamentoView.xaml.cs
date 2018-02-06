using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Mode;
using TestDrive.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoView : ContentPage
	{
        public AgendamentoViewModel ViewModel { get; set; }

        public AgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();
            Veiculo = veiculo;
            this.BindingContext = new AgendamentoViewModel(veiculo);
        }
        public Veiculo Veiculo { get; set; }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo",
            (msg) =>
            {
                DisplayAlert("Agendamento", "Agendamento salvo com Sucesso!", "Ok");
            });
        }
    }
}