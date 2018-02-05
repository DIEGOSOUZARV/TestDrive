using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.ViewModels
{
    public class DetalheViewModel
    {
        public string TextoFreioABS { get; set; }
        public string TextoArCondicionado { get; set; }
        public string TextoMP3Player { get; set; }
        public string ValorTotal { get; set; }
        public DetalheViewModel()
        {
            TextoFreioABS = "Freio ABS - R$ 800,00";
            TextoArCondicionado = "Ar Condicionado - R$ 1000,00";
            TextoMP3Player = "MP3 Player - R$ 500,00";
            ValorTotal = "Total do valor é: R$ 100000,00";
        }
    }
}
