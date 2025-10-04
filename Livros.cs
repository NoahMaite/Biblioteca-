using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    class Livros
    {
        private List<Livro> Acervo { get; set; } = new List<Livro>();

        public void Adicionar(Livro livro)
        {
            Acervo.Add(livro);
        }

        public Livro Pesquisar(int isbn)
        {
            return Acervo.FirstOrDefault(l => l.ISBN == isbn);
        }

        public List<Livro> Todos()
        {
            return Acervo;
        }
    }
}
