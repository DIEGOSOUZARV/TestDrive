using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel:BaseViewModel
    {

        #region Atributos
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";

        bool _aguarde;
        Veiculo _veiculoSelecionado; 
        #endregion

        #region Propriedades
        public ObservableCollection<Veiculo> Veiculos { get; set; }
        public Veiculo VeiculoSelecionado
        {
            get
            {
                return _veiculoSelecionado;
            }
            set
            {
                _veiculoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(_veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        public bool Aguarde
        {
            get { return _aguarde; }
            set
            {
                _aguarde = value;
                OnPropertyChanged();
            }
        } 
        #endregion

        #region Construtor
        public ListagemViewModel()
        {
            //Veiculos = null;
            Veiculos = new ObservableCollection<Veiculo>();
        }
        #endregion

        #region Métodos
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
        #endregion

    }

    class VeiculoJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
