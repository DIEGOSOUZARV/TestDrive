using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public object ViewModel { get;  set; }

        public AgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();
            Veiculo = veiculo;
            this.BindingContext = new AgendamentoViewModel(veiculo);
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();

            

            MessagingCenter.Subscribe<Veiculo>(this, "Agendar",
                (msg) =>
                {
                    DisplayAlert(
                        "Agendamento",
                        "Agendamento Salvo com sucesso",
                        "Ok"
                    );
                }
            );

            
        }

       
        

    }
}

       
 