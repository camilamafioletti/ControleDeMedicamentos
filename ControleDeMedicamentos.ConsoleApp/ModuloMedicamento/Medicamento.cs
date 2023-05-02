using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : Entidade
    {
        public string nomeMedicamento;
        public string descricao;
        public int qntdDisponivel;
        public int qntdLimite;
        public Fornecedor fornecedor;
        public ArrayList historicoRequisicoes;

        public int quantidadeRequisicoesSaida;

        public Medicamento(int id, string nomeMedicamento, string descricao, int qntdDisponivel, int qntdLimite, Fornecedor fornecedor)
        {
            this.id = id;
            this.nomeMedicamento = nomeMedicamento;
            this.descricao = descricao;
            this.qntdDisponivel = qntdDisponivel;
            this.qntdLimite = qntdLimite ;
            this.fornecedor = fornecedor;
        }

        public void ValidarQuantidade()
        {
            if(qntdDisponivel > qntdLimite)
            {
                qntdDisponivel = qntdLimite;
                Console.WriteLine("Essa quantidade excederá o limite de medicamentos. \n");
                Console.ReadLine();
            }
        }

        public void DiminuirQntd(int qntdMedicamento)
        {
            qntdDisponivel = qntdDisponivel - qntdMedicamento;
        }

        public void SomarQntd(int qntdMedicamento)
        {
            qntdDisponivel = qntdDisponivel + qntdMedicamento;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nomeMedicamento.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (fornecedor == null)
                erros.Add("O campo \"fornecedor\" é obrigatório");

            if (qntdDisponivel < 0)
                erros.Add("O campo \"quantidade\" não pode ser menor que 0");

            return erros;
        }
    }
}