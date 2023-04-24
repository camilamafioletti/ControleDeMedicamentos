using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario : Tela
    {
        public RepositorioFuncionario repositorioFuncionario = null;

        public string ApresentarMenuFuncionario()
        {
            Console.Clear();

            Console.WriteLine("(1) Adicionar funcionario");
            Console.WriteLine("(2) Editar funcionario");
            Console.WriteLine("(3) Visualizar funcionario");
            Console.WriteLine("(4) Excluir funcionario");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public void InserirNovoFuncionario()
        {
            Funcionario novoFuncionario = ObterFuncionario();

            repositorioFuncionario.Criar(novoFuncionario);

            Mensagem("Funcionario criado com sucesso!", ConsoleColor.Green);
        }

        public void EditarFuncionario()
        {
            ListarFuncionario();
            int idSelecionado = ReceberIdFuncionario();
            Funcionario funcionarioAtualizado = ObterFuncionario();

            repositorioFuncionario.Editar(idSelecionado, funcionarioAtualizado);
            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public void ListarFuncionario()
        {
            ArrayList listaFuncionarios = repositorioFuncionario.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("Funcionarios registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Nome       |CPF          |Telefone   |Endereço      |");
            Console.WriteLine("----------------------------------------------------------");
            Console.ResetColor();

            if (listaFuncionarios.Count == 0)
            {
                Mensagem("Nenhum funcionario registrado!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Funcionario funcionario in listaFuncionarios)
            {
                Console.WriteLine("|{0,-3}|{1,-11}|{2,-13}|{3,-11}|{4,-14}|", funcionario.id, funcionario.nome, funcionario.cpf, funcionario.telefone, funcionario.endereco);
            }

            Console.ReadKey();
        }

        public void DeletarFuncionario()
        {
            ListarFuncionario();
            int idSelecionado = ReceberIdFuncionario();
            repositorioFuncionario.Deletar(idSelecionado);
            Mensagem("Funcionario excluído com sucesso!", ConsoleColor.Green);
        }

        public int ReceberIdFuncionario()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.Write("Digite o id do funcionario: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioFuncionario.SelecionarId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Funcionario ObterFuncionario()
        {
            Console.Write("Informe o nome do funcionario: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o CPF do funcionario: ");
            int cpf = int.Parse(Console.ReadLine());

            Console.Write("Informe o telefone do funcionario: ");
            int telefone = int.Parse(Console.ReadLine());

            Console.Write("Informe o endereço do funcionario: ");
            string endereco = Console.ReadLine();

            Funcionario funcionario = new Funcionario(repositorioFuncionario.contadorId, nome, cpf, telefone, endereco);

            return funcionario;
        }
    }
}
