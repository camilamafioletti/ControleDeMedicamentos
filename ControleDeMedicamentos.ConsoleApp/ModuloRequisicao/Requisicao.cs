using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao : Entidade
    {
        public Paciente paciente;
        public Medicamento medicamento;
        public Funcionario funcionario;
        public DateTime data;
        public int qntdMedicamento;

        public Requisicao(int id, Paciente paciente, Medicamento medicamento, Funcionario funcionario, DateTime data, int qntdMedicamento)
        {
            this.id = id;   
            this.paciente = paciente;
            this.funcionario = funcionario;
            this.medicamento = medicamento;
            this.data = data;
            this.qntdMedicamento = qntdMedicamento;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (medicamento == null)
                erros.Add("O campo \"medicamento\" é obrigatório");

            if (funcionario == null)
                erros.Add("O campo \"funcionário\" é obrigatório");

            if (paciente == null)
                erros.Add("O campo \"paciente\" é obrigatório");

            if (data < DateTime.Now.Date)
                erros.Add("O campo \"data\" deve ser maior que a data atual");

            if (qntdMedicamento < 0)
                erros.Add("O campo \"quantidade\" deve ser maior que 0");

            if (medicamento != null && qntdMedicamento > medicamento.qntdLimite)
                erros.Add("O campo \"quantidade requisitada\" excedeu a quantidade em estoque deste medicamento");

            return erros;
        }
    }
}
