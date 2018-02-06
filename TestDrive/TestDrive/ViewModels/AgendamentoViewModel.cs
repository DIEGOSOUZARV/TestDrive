using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel
    {
        public Veiculo Veiculo { get { return Agendamento.Veiculo; } 
            set { Agendamento.Veiculo = value; } }
        public Agendamento Agendamento { get; set; }
        public string Nome
        {
            get { return Agendamento.Nome; }
            set { Agendamento.Nome = value; }
        }
        public string Fone
        {
            get { return Agendamento.Fone; }
            set { Agendamento.Fone = value; }
        }
        public string Email
        {
            get { return Agendamento.Email; }
            set { Agendamento.Email = value; }
        }
        public DateTime DataAgendamento
        {
            get { return Agendamento.DataAgendamento; }
            set { Agendamento.DataAgendamento = value; }
        }
        public TimeSpan HoraAgendamento
        {
            get { return Agendamento.HoraAgendamento; }
            set { Agendamento.HoraAgendamento = value; }
        }

        // construtor
        public AgendamentoViewModel(Veiculo veiculo)
        {
            Agendamento = new Agendamento();
            Veiculo = veiculo;
            {
                Veiculo = veiculo;



                AgendarCommand = new Command(() =>
                {

                    MessagingCenter.Send(veiculo, "Agendar");
                });
            }
        }

        public ICommand AgendarCommand { get; set; }

    }
        
        

    }

