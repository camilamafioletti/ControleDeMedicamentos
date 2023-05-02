
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloAquisicao
{
    public class TelaAquisicao : Tela
    {

        private RepositorioAquisicao repositorioAquisicao = null;
        private RepositorioMedicamento repositorioMedicamento = null;
        private RepositorioFornecedor repositorioFornecedor = null;
        private RepositorioFuncionario repositorioFuncionario = null;

        public TelaAquisicao(RepositorioAquisicao repositorioAquisicao, RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor, RepositorioFuncionario repositorioFuncionario)
        {
            repositorio = repositorioAquisicao;
            this.repositorioAquisicao = repositorioAquisicao;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioFuncionario = repositorioFuncionario;

        }

        public override void InserirNovoRegistro()
        {
            bool temFuncionarios = repositorioFuncionario.TemRegistros();

            if (temFuncionarios == false)
            {
                Mensagem("Cadastre ao menos um funcionário para cadastrar requisições de entrada", ConsoleColor.DarkYellow);
                return;
            }

            bool temMedicamentos = repositorioMedicamento.TemRegistros();

            if (temMedicamentos == false)
            {
                Mensagem("Cadastre ao menos um medicamento para cadastrar requisições de entrada", ConsoleColor.DarkYellow);
                return;
            }

            base.InserirNovoRegistro();
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("(1) Fazer reposicao de medicamentos");
            Console.WriteLine("(2) Visualizar historico de aquisição");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        protected override void MostrarTabela(ArrayList listaAquisicao)
        {


            Console.Clear();
            Console.WriteLine("Histórico de aquisições:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Fornecedor       |Medicamento          |Funcionário   |Data      |Quantidade |");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.ResetColor();



            foreach (Aquisicao aquisicao in listaAquisicao)
            {
                Console.WriteLine("|{0,-3}|{1,-17}|{2,-21}|{3,-14}|{4,-10}|{5,-11}|", aquisicao.id, aquisicao.fornecedor.nome, aquisicao.medicamento.nomeMedicamento, aquisicao.funcionario.nome, aquisicao.data, aquisicao.qntdMedicamento);
            }

            Console.ReadKey();
        }

        protected override Entidade ObterRegistro()
        {
            Console.Write("Informe o id do fornecedor: ");
            int idFornecedor = int.Parse(Console.ReadLine());

            Console.Write("Informe o id do medicamento: ");
            int idMedicamento = int.Parse(Console.ReadLine());

            Console.Write("Informe o id do funcionário: ");
            int idFuncionario = int.Parse(Console.ReadLine());

            Console.Write("Informe a data da aquisição: ");
            DateTime dataAquisicao = DateTime.Parse(Console.ReadLine());

            Console.Write("Informe a quantidade de medicamento: ");
            int qntdMedicamento= int.Parse(Console.ReadLine());

            Fornecedor fornecedor = (Fornecedor)repositorioFornecedor.SelecionarId(idFornecedor);
            Medicamento medicamento = (Medicamento)repositorioMedicamento.SelecionarId(idMedicamento);
            Funcionario funcionario = (Funcionario)repositorioFuncionario.SelecionarId(idFuncionario);
                 
            Aquisicao aquisicao = new Aquisicao(repositorioAquisicao.contadorId, fornecedor, medicamento, funcionario, dataAquisicao, qntdMedicamento);

            medicamento.SomarQntd(qntdMedicamento);
            medicamento.ValidarQuantidade();

            return aquisicao;
        }

    }
}
