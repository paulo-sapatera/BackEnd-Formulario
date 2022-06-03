using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastro.Models
{
    public class Cadastro
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime Data { get; set; }
        
        public string Endereco { get; set; }

        public string CEP { get; set; }

        public string Telefone { get; set; }

        public string Sexo { get; set; }

        public string Ensino { get; set; }

        public string Curso { get; set; }

    }
}
