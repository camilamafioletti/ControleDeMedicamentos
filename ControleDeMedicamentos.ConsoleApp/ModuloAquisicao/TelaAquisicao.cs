
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloAquisicao
{
    public class TelaAquisicao : Tela
    {

        public RepositorioAquisicao repositorioAquisicao = null;
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFornecedor repositorioFornecedor = null;
        public RepositorioFuncionario repositorioFuncionario = null;

        public string ApresentarMenuAquisicao()
        {
            Console.Clear();

            Console.WriteLine("(1) Fazer reposicao de medicamentos");
            Console.WriteLine("(2) Visualizar historico de aquisição");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public void InserirNovaAquisicao()
        {
            Aquisicao novaAquisicao = ObterAquisicao();

            repositorioAquisicao.Criar(novaAquisicao);

            Mensagem("Medicamento criado com sucesso!", ConsoleColor.Green);
        }

        public void ListarAquisicao()
        {
            ArrayList listaAquisicao = repositorioAquisicao.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("Histórico de aquisições:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Fornecedor       |Medicamento          |Funcionário   |Data      |Quantidade |");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.ResetColor();

            if (listaAquisicao.Count == 0)
            {
                Mensagem("Nenhuma aquisição registrada!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Aquisicao aquisicao in listaAquisicao)
            {
                Console.WriteLine("|{0,-3}|{1,-17}|{2,-21}|{3,-14}|{4,-10}|{5,-11}|", aquisicao.id, aquisicao.fornecedor.nome, aquisicao.medicamento.nomeMedicamento, aquisicao.funcionario.nome, aquisicao.data, aquisicao.qntdMedicamento);
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

                idInvalido = repositorioAquisicao.SelecionarId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Aquisicao ObterAquisicao()
        {
            Console.Write("Informe o id do fornecedor: ");
            int idFornecedor = int.Parse(Console.ReadLine());

            Console.Write("Informe o id do medicamento: ");
            int idMedicamento = int.Parse(Console.ReadLine());

            Console.Write("Informe o id do funcionário: ");
            int idFuncionario = int.Parse(Console.ReadLine());

            Console.Write("Informe a data da aquisição: ");
            int dataAquisicao = int.Parse(Console.ReadLine());

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
