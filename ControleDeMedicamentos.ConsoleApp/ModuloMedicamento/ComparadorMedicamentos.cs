using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class ComparadorMedicamentos : IComparer
    {
        public int Compare(object x, object y)
        {
            Medicamento mX = (Medicamento)x;

            Medicamento mY = (Medicamento)y;

            if (mX.quantidadeRequisicoesSaida < mY.quantidadeRequisicoesSaida)
                return 1;

            else if (mX.quantidadeRequisicoesSaida > mY.quantidadeRequisicoesSaida)
                return -1;

            else
                return 0;
        }
    }
}

