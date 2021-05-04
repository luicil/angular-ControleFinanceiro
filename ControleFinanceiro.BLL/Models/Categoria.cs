using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.BLL.Models
{
    public class Categoria
    {

        public int CategoriaID { get; set; }

        public string Nome { get; set; }

        public string Icone { get; set; }

        public int TipoID { get; set; }

        public Tipo Tipo { get; set; }

        public virtual ICollection<Despesa> Despesas { get; set; }

        public virtual ICollection<Ganho> Ganhos { get; set; }

    }
}
