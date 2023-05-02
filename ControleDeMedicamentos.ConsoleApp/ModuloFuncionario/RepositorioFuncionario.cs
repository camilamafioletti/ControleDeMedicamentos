using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class RepositorioFuncionario : Repositorio
    {
        public RepositorioFuncionario(ArrayList listaFuncionario)
        {
            this.listaRegistros = listaFuncionario;
        }

        public override Funcionario SelecionarId(int id)
        {
            return (Funcionario)base.SelecionarId(id);
        }
    }
}
