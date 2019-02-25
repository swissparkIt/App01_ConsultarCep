using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCep.servico.modelo;
using App01_ConsultarCep.servico;

namespace App01_ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //btnBuscar

        }

        private void BuscarCep(object sender, EventArgs args)
        {
            var cep = EntCep.Text.Trim();

            if (IsValidCep(cep))
            {
                try
                {
                    var end = ViaCepServico.BuscarEnderecoViaCep(cep);

                    if (end != null)
                    {
                        lblResultado.Text = string.Format("Endereço: {2} de {3} {0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO","O enderço não foi encontrado para o CEP informado " + cep, "OK");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO EXCEPTION", ex.Message,"OK");
                }
            }
        }

        private bool IsValidCep(string cep)
        {
            var value = true;
            int novoCep = 0;

            if (cep.Length != 8)
            {
                value = false;
                DisplayAlert("ERRO", "CEP inválido. O CEP deve conter 8 caracteres.", "OK");
            }

            if (!int.TryParse(cep, out novoCep))
            {
                value = false;
                DisplayAlert("ERRO", "O CEP deve ser composto apenas por números.", "OK");
            }


            return value;
        }


    }
}
