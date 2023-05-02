using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class RepositorioFornecedor : Repositorio
    {
        public RepositorioFornecedor(ArrayList listaForcedor)
        {
            this.listaRegistros = listaForcedor;
        }

        public override Fornecedor SelecionarId(int id)
        {
            return (Fornecedor)base.SelecionarId(id);
        }
    }
}
