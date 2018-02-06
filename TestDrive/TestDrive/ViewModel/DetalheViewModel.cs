using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Mode;
using Xamarin.Forms;

namespace TestDrive.ViewModel
{
    public class DetalheViewModel:BaseViewModel
    {
        public Veiculo Veiculo { get; set; }
        public string TextoFreioABS
        {
            get { return string.Format("Freio ABS - R$ {0}", Veiculo.FREIO_ABS); }

        }
        public string TextoArCondicionado
        {
            get { return string.Format("Ar Condicionado - R$ {0}", Veiculo.AR_CONDICIONADO); }

        }
        public string TextoMP3Player
        {
            get { return string.Format("MP3 Player - R$ {0}", Veiculo.FREIO_ABS); }

        }
        public bool TemFreioABS
        {
            get { return Veiculo.TemFreioABS; }
            set {
                Veiculo.TemFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public bool TemArCondicionado {
            get { return Veiculo.TemArCondicionado; }
                set { Veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

            }
        }
        public bool TemMP3Player {
            get { return Veiculo.TemMP3Player; }

            set { Veiculo.TemMP3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

            }
        }
        public string ValorTotal {
            get {
                return Veiculo.PrecoTotalFormatado;

            }  }
        public DetalheViewModel(Veiculo veiculo)
        {
            
            Veiculo = veiculo;
            
            ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send(veiculo, "Proximo");
            });

        }
        public ICommand ProximoCommand { get; set; }
        
    }

}
