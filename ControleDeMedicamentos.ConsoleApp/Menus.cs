
using ControleDeMedicamentos.ConsoleApp.ModuloAquisicao;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleDeMedicamentos.ConsoleApp
{
    public class Menus : Tela
    {
        public TelaPaciente telaPaciente = null;
        public TelaMedicamento telaMedicamento = null;
        public TelaFornecedor telaFornecedor = null;
        public TelaFuncionario telaFuncionario = null;
        public TelaRequisicao telaRequisicao = null;
        public TelaAquisicao telaAquisicao = null;
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

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuPaciente()
        {
            while (true)
            {
                string opcaoMenu = telaPaciente.ApresentarMenuPaciente();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaPaciente.InserirNovoPaciente(); break;
                    case "2": telaPaciente.EditarPaciente(); break;
                    case "3": telaPaciente.ListarPaciente(); break;
                    case "4": telaPaciente.DeletarPaciente(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuMedicamento()
        {
            while (true)
            {
                string opcaoMenu = telaMedicamento.ApresentarMenuMedicamento();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaMedicamento.InserirNovoMedicamento(); break;
                    case "2": telaMedicamento.ListarMedicamento(); break;
                    case "3": telaMedicamento.ListarRelatorioMedicamento(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuFuncionario()
        {
            while (true)
            {
                string opcaoMenu = telaFuncionario.ApresentarMenuFuncionario();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaFuncionario.InserirNovoFuncionario(); break;
                    case "2": telaFuncionario.EditarFuncionario(); break;
                    case "3": telaFuncionario.ListarFuncionario(); break;
                    case "4": telaFuncionario.DeletarFuncionario(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuFornecedor()
        {
            while (true)
            {
                string opcaoMenu = telaFornecedor.ApresentarMenuFornecedor();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaFornecedor.InserirNovoFornecedor(); break;
                    case "2": telaFornecedor.EditarFornecedor(); break;
                    case "3": telaFornecedor.ListarFornecedor(); break;
                    case "4": telaFornecedor.DeletarFornecedor(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuRequisicao()
        {
            while (true)
            {
                string opcaoMenu = telaRequisicao.ApresentarMenuRequisicao();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaRequisicao.ObterRequisicao(); break;
                    case "2": telaRequisicao.ListarRequisicao(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuAquisicao()
        {
            while (true)
            {
                string opcaoMenu = telaAquisicao.ApresentarMenuAquisicao();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaAquisicao.ObterAquisicao(); break;
                    case "2": telaAquisicao.ListarAquisicao(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }
    }
}


