
using ControleDeMedicamentos.ConsoleApp.ModuloAquisicao;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleDeMedicamentos.ConsoleApp
{
    public class Menus
    {
        private TelaPaciente telaPaciente = null;
        private TelaMedicamento telaMedicamento = null;
        private TelaFornecedor telaFornecedor = null;
        private TelaFuncionario telaFuncionario = null;
        private TelaRequisicao telaRequisicao = null;
        private TelaAquisicao telaAquisicao = null;

        public Menus(TelaPaciente telaPaciente, TelaMedicamento telaMedicamento, TelaFornecedor telaFornecedor, TelaFuncionario telaFuncionario, TelaRequisicao telaRequisicao, TelaAquisicao telaAquisicao)
        {
            this.telaPaciente = telaPaciente;
            this.telaMedicamento = telaMedicamento;
            this.telaFornecedor = telaFornecedor;
            this.telaFuncionario = telaFuncionario;
            this.telaRequisicao = telaRequisicao;
            this.telaAquisicao = telaAquisicao;
        }

        public void MenuPrincipal()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\n═══ GERENCIADOR DE FARMACIA ═══\n");
                Console.WriteLine("(1) Gerenciar paciente");
                Console.WriteLine("(2) Gerenciar medicamento");
                Console.WriteLine("(3) Gerenciar funcionario");
                Console.WriteLine("(4) Gerenciar fornecedor");
                Console.WriteLine("(5) Gerenciar requisição");
                Console.WriteLine("(6) Gerenciar aquisição");
                Console.WriteLine("(S) Sair ");
                Console.Write("\nOpção:  ");

                string opcaoMenu = Console.ReadLine();


                if (opcaoMenu.ToUpper() == "S")
                {
                    Console.WriteLine("Saindo...");
                    break;
                }
                switch (opcaoMenu.ToUpper())
                {
                    case "1": MenuPaciente(); break;
                    case "2": MenuMedicamento(); break;
                    case "3": MenuFuncionario(); break;
                    case "4": MenuFornecedor(); break;
                    case "5": MenuRequisicao(); break;
                    case "6": MenuAquisicao(); break;

                    default: Tela.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuPaciente()
        {
            while (true)
            {
                string opcaoMenu = telaPaciente.ApresentarMenu();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaPaciente.InserirNovoRegistro(); break;
                    case "2": telaPaciente.EditarRegistro(); break;
                    case "3": telaPaciente.VisualizarRegistros(); break;
                    case "4": telaPaciente.DeletarRegistro(); break;

                    default: Tela.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuMedicamento()
        {
            while (true)
            {
                string opcaoMenu = telaMedicamento.ApresentarMenu();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaMedicamento.InserirNovoRegistro(); break;
                    case "2": telaMedicamento.VisualizarRegistros(); break;
                    case "3": telaMedicamento.ListarRelatorioMedicamentoEmFalta(); break;
                    case "4": telaMedicamento.VisualizarMedicamentosMaisRetirados(); break;

                    default: Tela.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuFuncionario()
        {
            while (true)
            {
                string opcaoMenu = telaFuncionario.ApresentarMenu();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaFuncionario.InserirNovoRegistro(); break;
                    case "2": telaFuncionario.EditarRegistro(); break;
                    case "3": telaFuncionario.VisualizarRegistros(); break;
                    case "4": telaFuncionario.DeletarRegistro(); break;

                    default: Tela.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuFornecedor()
        {
            while (true)
            {
                string opcaoMenu = telaFornecedor.ApresentarMenu();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaFornecedor.InserirNovoRegistro(); break;
                    case "2": telaFornecedor.EditarRegistro(); break;
                    case "3": telaFornecedor.VisualizarRegistros(); break;
                    case "4": telaFornecedor.DeletarRegistro(); break;

                    default: Tela.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuRequisicao()
        {
            while (true)
            {
                string opcaoMenu = telaRequisicao.ApresentarMenu();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaRequisicao.InserirNovoRegistro(); break;
                    case "2": telaRequisicao.VisualizarRegistros(); break;

                    default: Tela.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuAquisicao()
        {
            while (true)
            {
                string opcaoMenu = telaAquisicao.ApresentarMenu();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaAquisicao.InserirNovoRegistro(); break;
                    case "2": telaAquisicao.VisualizarRegistros(); break;

                    default: Tela.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }
    }
}


