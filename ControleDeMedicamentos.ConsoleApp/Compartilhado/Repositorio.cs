using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp
{
    public class Repositorio
    {
        public int contadorId = 0;
        public ArrayList listaRegistros = new ArrayList();

        public void IncrementarId()
        {
            contadorId++;
        }
        public void Cadastrar(Entidade entidade)
        {
            listaRegistros.Add(entidade);
        }
        public void Criar(Entidade entidade)
        {
            Cadastrar(entidade);
            IncrementarId();
        }

        public void Editar(int idEditar, Entidade entidadeEditada)
        {
            Entidade entidade = SelecionarId(idEditar);
            entidade.Atualizar(entidadeEditada);
        }

        public void Deletar(int id)
        {
            Entidade entidade = SelecionarId(id);
            listaRegistros.Remove(entidade);
        }

        public ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }

        public Entidade SelecionarId(int id)
        {
            Entidade entidade = null;

            foreach (Entidade a in listaRegistros)
            {
                if (a.id == id)
                {
                    entidade = a;
                    break;
                }
            }
            return entidade;
        }
    }
}
