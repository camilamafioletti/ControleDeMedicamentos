using ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloAquisicao
{
    public class RepositorioAquisicao : Repositorio
    {
        public RepositorioAquisicao(ArrayList listaRequisicaoEntrada)
        {
            this.listaRegistros = listaRequisicaoEntrada;
        }

        public override Aquisicao SelecionarId(int id)
        {
            return (Aquisicao)base.SelecionarId(id);
        }
    }
}
