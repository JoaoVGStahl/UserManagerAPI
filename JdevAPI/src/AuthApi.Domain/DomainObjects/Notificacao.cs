﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApi.Domain.DomainObjects
{
    public class Notificacao
    {
        public string Mensagem { get; set; }

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
