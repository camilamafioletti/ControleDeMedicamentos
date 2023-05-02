using ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamento : Repositorio
    {
        public RepositorioMedicamento(ArrayList listaMedicamento)
        {
            this.listaRegistros = listaMedicamento;
        }

        public override Medicamento SelecionarId(int id)
        {
            return (Medicamento)base.SelecionarId(id);
        }
        public ArrayList SelecionarMedicamentosMaisRetirados()
        {
            Medicamento[] medicamentos = new Medicamento[listaRegistros.Count];

            int posicao = 0;
            foreach (Medicamento m in listaRegistros)
            {
                medicamentos[posicao++] = m;
            }

            Array.Sort(medicamentos, new ComparadorMedicamentos());

            return new ArrayList(medicamentos);
        }
    }
}
