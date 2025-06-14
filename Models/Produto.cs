﻿using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        // propriedades da classe Produto
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
    }
}
