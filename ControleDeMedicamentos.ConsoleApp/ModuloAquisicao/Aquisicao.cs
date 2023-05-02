using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloAquisicao
{
    public class Aquisicao : Entidade
    {
        public Fornecedor fornecedor;
        public Medicamento medicamento; 
        public Funcionario funcionario;
        public DateTime data;
        public int qntdMedicamento;

        public Aquisicao(int id, Fornecedor fornecedor, Medicamento medicamento, Funcionario funcionario, DateTime data, int qntdMedicamento)
        {
            this.id = id;
            this.fornecedor = fornecedor;
            this.medicamento = medicamento;
            this.funcionario = funcionario;
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

            if (data < DateTime.Now.Date)
                erros.Add("O campo \"data\" deve ser maior que a data atual");

            if (qntdMedicamento < 0)
                erros.Add("O campo \"quantidade\" deve ser maior que 0");

            return erros;
        }
    }
}
