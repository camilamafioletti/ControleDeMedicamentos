using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaRequisicao : Tela
    {

        private RepositorioRequisicao repositorioRequisicao = null;
        private RepositorioPaciente repositorioPaciente = null;
        private RepositorioMedicamento repositorioMedicamento = null;
        private RepositorioFuncionario repositorioFuncionario = null;

        public TelaRequisicao(RepositorioRequisicao repositorioRequisicao, RepositorioPaciente repositorioPaciente, RepositorioMedicamento repositorioMedicamento, RepositorioFuncionario repositorioFuncionario)
        {
            repositorio = repositorioRequisicao;
            this.repositorioRequisicao = repositorioRequisicao;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public override void InserirNovoRegistro()
        {
            bool temFuncionarios = repositorioFuncionario.TemRegistros();

            if (temFuncionarios == false)
            {
                Mensagem("Cadastre ao menos um funcionário para cadastrar requisições de saída", ConsoleColor.DarkYellow);
                return;
            }

            bool temMedicamentos = repositorioMedicamento.TemRegistros();

            if (temMedicamentos == false)
            {
                Mensagem("Cadastre ao menos um medicamento para cadastrar requisições de saída", ConsoleColor.DarkYellow);
                return;
            }

            bool temPacientes = repositorioPaciente.TemRegistros();

            if (temPacientes == false)
            {
                Mensagem("Cadastre ao menos um paciente para cadastrar requisições de saída", ConsoleColor.DarkYellow);
                return;
            }

            Requisicao registro = (Requisicao)ObterRegistro();

            if (ValidarErrosDeValidacao(registro))
            {
                return;
            }

            repositorio.Criar(registro);

            Mensagem("Registro inserido com sucesso!", ConsoleColor.Green);
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("(1) Adicionar requisição");
            Console.WriteLine("(2) Visualizar requisição");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        protected override void MostrarTabela(ArrayList listaRequisicao)
        {

            Console.Clear();
            Console.WriteLine("Histórico de requisições:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Paciente         |Medicamento          |Funcionário   |Data      |Quantidade |");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.ResetColor();


            foreach (Requisicao reposicao in listaRequisicao)
            {
                Console.WriteLine("|{0,-3}|{1,-17}|{2,-21}|{3,-14}|{4,-10}|{5,-11}|", reposicao.id, reposicao.paciente.nome, reposicao.medicamento.nomeMedicamento, reposicao.funcionario.nome, reposicao.data, reposicao.qntdMedicamento);
            }

            Console.ReadKey();
        }

        protected override Entidade ObterRegistro()
        {
            Console.Write("Informe o id do paciente: ");
            int idPaciente = int.Parse(Console.ReadLine());

            Console.Write("Informe o id do medicamento: ");
            int idMedicamento = int.Parse(Console.ReadLine());

            Console.Write("Informe o id do funcionário: ");
            int idFuncionario = int.Parse(Console.ReadLine());

            Console.Write("Informe a data da requisição: ");
            DateTime dataRequisicao = DateTime.Parse(Console.ReadLine());

            Console.Write("Informe a quantidade de medicamento: ");
            int qntdMedicamento = int.Parse(Console.ReadLine());

            Paciente paciente = (Paciente)repositorioPaciente.SelecionarId(idPaciente);
            Medicamento medicamento = (Medicamento)repositorioMedicamento.SelecionarId(idMedicamento);
            Funcionario funcionario = (Funcionario)repositorioFuncionario.SelecionarId(idFuncionario);

            Requisicao requisicao = new Requisicao(repositorioRequisicao.contadorId, paciente, medicamento, funcionario, dataRequisicao, qntdMedicamento);

            medicamento.DiminuirQntd(qntdMedicamento);

            return requisicao;
        }
    }
}
