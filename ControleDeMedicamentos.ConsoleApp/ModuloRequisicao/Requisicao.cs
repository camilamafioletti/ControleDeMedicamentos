using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao : Entidade
    {
        public Paciente paciente;
        public Medicamento medicamento;
        public Funcionario funcionario;
        public int data;
        public int qntdMedicamento;

        public Requisicao(int id, Paciente paciente, Medicamento medicamento, Funcionario funcionario, int data, int qntdMedicamento)
        {
            this.id = id;   
            this.paciente = paciente;
            this.funcionario = funcionario;
            this.medicamento = medicamento;
            this.data = data;
            this.qntdMedicamento = qntdMedicamento;
        }
    }
}
