using ControleDeMedicamentos.ConsoleApp;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaRequisicao : Tela
    {

        public RepositorioRequisicao repositorioRequisicao = null;
        public RepositorioPaciente repositorioPaciente = null;
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFuncionario repositorioFuncionario = null;

        public string ApresentarMenuRequisicao()
        {
            Console.Clear();

            Console.WriteLine("(1) Adicionar requisição");
            Console.WriteLine("(2) Visualizar requisição");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public void InserirNovaRequisicao()
        {
            Requisicao novaRequisicao = ObterRequisicao();

            repositorioRequisicao.Criar(novaRequisicao);

            Mensagem("Medicamento criado com sucesso!", ConsoleColor.Green);
        }
        public void ListarRequisicao()
        {
            ArrayList listaRequisicao = repositorioRequisicao.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("Histórico de requisições:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Paciente         |Medicamento          |Funcionário   |Data      |Quantidade |");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.ResetColor();

            if (listaRequisicao.Count == 0)
            {
                Mensagem("Nenhuma requisição registrada!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Requisicao reposicao in listaRequisicao)
            {
                Console.WriteLine("|{0,-3}|{1,-17}|{2,-21}|{3,-14}|{4,-10}|{5,-11}|", reposicao.id, reposicao.paciente.nome, reposicao.medicamento.nomeMedicamento, reposicao.funcionario.nome, reposicao.data, reposicao.qntdMedicamento);
            }

            Console.ReadKey();
        }

        public int ReceberIdAquisicao()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.Write("Digite o id da aquisicao: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioRequisicao.SelecionarId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Requisicao ObterRequisicao()
        {
            Console.Write("Informe o id do paciente: ");
            int idPaciente = int.Parse(Console.ReadLine());

            Console.Write("Informe o id do medicamento: ");
            int idMedicamento = int.Parse(Console.ReadLine());

            Console.Write("Informe o id do funcionário: ");
            int idFuncionario = int.Parse(Console.ReadLine());

            Console.Write("Informe a data da requisição: ");
            int dataRequisicao = int.Parse(Console.ReadLine());

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
