using System;

namespace Biblioteca
{
    class Emprestimo
    {
        public DateTime dtEmprestimo { get; set; }
        public DateTime? dtDevolucao { get; set; }

        public Emprestimo()
        {
            dtEmprestimo = DateTime.Now;
            dtDevolucao = null;
        }

        public void Devolver()
        {
            dtDevolucao = DateTime.Now;
        }

        public bool EstaAtivo()
        {
            return dtDevolucao == null;
        }
    }
}
