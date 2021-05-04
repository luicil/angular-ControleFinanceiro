using System;
namespace ControleFinanceiro.BLL.Models
{
    public class Ganho
    {
        public int GanhoID { get; set; }

        public string Descricao { get; set; }

        public int CategoriaID { get; set; }

        public Categoria Categoria { get; set; }

        public double Valor { get; set; }

        public int Dia { get; set; }

        public int MesID { get; set; }

        public Mes Mes { get; set; }

        public int Ano { get; set; }

        public string UsuarioID { get; set; }

        public Usuario Usuario { get; set; }

    }
}
