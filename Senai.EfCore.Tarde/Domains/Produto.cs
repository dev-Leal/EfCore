﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Tarde.Domains
{

    /// <summary>
    /// Define a classe produto
    /// </summary>
    public class Produto : BaseDomain
    {
     
        public string Nome { get; set; }
        public float Preco { get; set; }
        public object UrlImagem { get; internal set; }
        public object Imagem { get; internal set; }
    } 
}
