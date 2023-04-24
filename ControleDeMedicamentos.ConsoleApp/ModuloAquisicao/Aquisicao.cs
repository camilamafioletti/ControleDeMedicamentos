using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloAquisicao
{
    public class Aquisicao : Entidade
    {
        public Fornecedor fornecedor;
        public Medicamento medicamento; 
        public Funcionario funcionario;
        public int data;
        public int qntdMedicamento;

        public Aquisicao(int id, Fornecedor fornecedor, Medicamento medicamento, Funcionario funcionario, int data, int qntdMedicamento)
        {
            this.id = id;
            this.fornecedor = fornecedor;
            this.medicamento = medicamento;
            this.funcionario = funcionario;
            this.data = data;
            this.qntdMedicamento = qntdMedicamento;
        }
    }
}
