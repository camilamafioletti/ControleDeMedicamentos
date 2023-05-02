using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class RepositorioRequisicao : Repositorio
    {
        public RepositorioRequisicao(ArrayList listaRequisicao)
        {
            this.listaRegistros = listaRequisicao;
        }

        public override Requisicao SelecionarId(int id)
        {
            return (Requisicao)base.SelecionarId(id);
        }


    }
}
