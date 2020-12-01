﻿using Microsoft.EntityFrameworkCore;
using Senai.EfCore.Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Tarde.Controllers.Contexts
{
    public class PedidoContext : DbContext 
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=.\SqlExpress3; Initial Catalog=Db_Senai_Pedidos_Tarde_Dev; user id=sa; password=sa132");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
