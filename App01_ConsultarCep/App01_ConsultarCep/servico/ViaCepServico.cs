using App01_ConsultarCep.servico.modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App01_ConsultarCep.servico
{
    public class ViaCepServico
    {
        private static string EnderecoUrl = "http://viacep.com.br/ws/{0}/json/";

        public Endereco BuscarEnderecoViaCep(string cep)
        {
            var novaUrl = String.Format(EnderecoUrl,cep);

            var ws = new WebClient();
            var json = ws.DownloadString(novaUrl);

            var obj = JsonConvert.DeserializeObject<Endereco>(json);

            return obj;
        }

    }
}
