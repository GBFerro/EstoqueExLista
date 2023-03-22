using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueExLista
{
    internal class Produto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }

        public Produto(int id, string nome, int quantidade)
        {
            this.ID = id;
            this.Name = nome;
            this.Quantity = quantidade;
        }

        public override string ToString()
        {
            return $"\n>>>Dados do PRODUTO<<<\n\nID: {this.ID}\nNome: {this.Name}\nQuantidade: {this.Quantity}\n";
        }
    }
}
