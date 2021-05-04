using System;
using System.Collections.Generic;

namespace ControleFinanceiro.BLL.Models
{
    public class Tipo
    {
        public int TipoID { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Categoria> Categorias { get; set; }

    }
}
