using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp
{
    public abstract class Entidade
    {
        public int id;

        public virtual void Atualizar(Entidade registroAtualizado)
        {
            id = registroAtualizado.id;
        }

        public abstract ArrayList Validar();
    }
}
