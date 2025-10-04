using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    class Livro
    {
        public int ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public List<Exemplar> Exemplares { get; set; } = new List<Exemplar>();

        public void AdicionarExemplar(Exemplar ex)
        {
            Exemplares.Add(ex);
        }

        public int QtdeExemplares()
        {
            return Exemplares.Count;
        }

        public int QtdeDisponiveis()
        {
            return Exemplares.Count(e => e.Disponivel());
        }

        public int QtdeEmprestimos()
        {
            return Exemplares.Sum(e => e.QtdeEmprestimos());
        }

        public double PercDisponibilidade()
        {
            if (QtdeExemplares() == 0) return 0;
            return (double)QtdeDisponiveis() / QtdeExemplares() * 100;
        }
    }
}
