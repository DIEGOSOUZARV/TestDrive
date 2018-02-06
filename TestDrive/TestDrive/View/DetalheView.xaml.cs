using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Mode;
using TestDrive.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public DetalheViewModel ViewModel { get; set; }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            Veiculo = veiculo;
            this.ViewModel = new DetalheViewModel(veiculo);
            this.BindingContext = ViewModel;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo",
            (msg) =>
            {
                Navigation.PushAsync(new AgendamentoView(msg));
            });
        }
        protected override void OnDisappearing()
        {
            base.OnAppearing();
        }
    }
}