using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    class Exemplar
    {
        public int Tombo { get; set; }
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

        public bool Emprestar()
        {
            if (Disponivel())
            {
                Emprestimos.Add(new Emprestimo());
                return true;
            }
            return false;
        }

        public bool Devolver()
        {
            var emprestimo = Emprestimos.LastOrDefault(e => e.EstaAtivo());
            if (emprestimo != null)
            {
                emprestimo.Devolver();
                return true;
            }
            return false;
        }

        public bool Disponivel()
        {
            return !Emprestimos.Any(e => e.EstaAtivo());
        }

        public int QtdeEmprestimos()
        {
            return Emprestimos.Count;
        }
    }
}
