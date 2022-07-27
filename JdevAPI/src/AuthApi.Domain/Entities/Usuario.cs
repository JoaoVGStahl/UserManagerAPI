using System;
using System.Collections.Generic;
using System.Linq;
namespace AuthApi.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool Apagado { get; set; }
        public DateTime DataCadastro { get; set; }
        public Usuario()
        {
            Id = Guid.NewGuid();
        }
    }
}
