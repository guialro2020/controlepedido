﻿using Newtonsoft.Json;
using Tcs.ControlePedido.Negocio.Core.Clientes.Commands.CadastrarClientes;

namespace Tcs.ControlePedido.Api.Models.Clientes
{
    public class AtualizarClientesInput : IAtualizarClienteInput
    {
        [JsonIgnore]
        public int ClienteId { get; set; }

        [JsonProperty("nomeCompleto")]
        public string NomeCompleto { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("endereco")]
        public string Endereco { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("telefone")]
        public string Telefone { get; set; }
    }
}