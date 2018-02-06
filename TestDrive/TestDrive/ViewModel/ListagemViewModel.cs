using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Mode;
using Xamarin.Forms;

namespace TestDrive.ViewModel
{
    public class ListagemViewModel:BaseViewModel
    {
        public ObservableCollection<Veiculo> Veiculos { get; set; }
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";



        bool _aguarde;
        Veiculo _veiculoSelecionando;

        public Veiculo VeiculoSelecionado {
            get {
                return _veiculoSelecionando;
            }
            set
            {
                _veiculoSelecionando = value;
                if (value != null)
                    MessagingCenter.Send(_veiculoSelecionando, "VeiculoSelecionando");
            }
        }

        public async Task GetVeiculos()
        {
            Aguarde = true;
            try
            {
                HttpClient cliente = new HttpClient();
                var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);
                var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

                Veiculos.Clear();
                foreach (var veiculos in veiculosJson)
                {
                    Veiculos.Add(new Veiculo
                    {
                        Nome = veiculos.nome,
                        Preco = veiculos.preco
                    });
                }
            }
            catch (Exception ex)
            {
                MessagingCenter.Send<Exception>(ex, "FalhaListagem");
            }
            Aguarde = false;

        }

        public bool Aguarde {
            get { return _aguarde; }
            set {
                _aguarde = value;
                OnPropertyChanged();
            }
        }
        public ListagemViewModel()
        {
            Veiculos = new ObservableCollection<Veiculo>();
        }

    }

    class VeiculoJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
