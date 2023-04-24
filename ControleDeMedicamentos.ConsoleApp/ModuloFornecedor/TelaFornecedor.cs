using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : Tela
    {
        public RepositorioFornecedor repositorioFornecedor = null;

        public string ApresentarMenuFornecedor()
        {
            Console.Clear();

            Console.WriteLine("(1) Adicionar fornecedor");
            Console.WriteLine("(2) Editar fornecedor");
            Console.WriteLine("(3) Visualizar fornecedor");
            Console.WriteLine("(4) Excluir fornecedor");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public void InserirNovoFornecedor()
        {
            Fornecedor novoFornecedor = ObterFornecedor();

            repositorioFornecedor.Criar(novoFornecedor);

            Mensagem("Fornecedor criado com sucesso!", ConsoleColor.Green);
        }

        public void EditarFornecedor()
        {
            ListarFornecedor();
            int idSelecionado = ReceberIdFornecedor();
            Fornecedor fornecedorAtualizado = ObterFornecedor();

            repositorioFornecedor.Editar(idSelecionado, fornecedorAtualizado);
            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public void ListarFornecedor()
        {
            ArrayList listaFornecedores = repositorioFornecedor.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("Funcionario registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Nome       |CNPJ         |Telefone   |Endereço      |");
            Console.WriteLine("----------------------------------------------------------");
            Console.ResetColor();

            if (listaFornecedores.Count == 0)
            {
                Mensagem("Nenhum fornecedor registrado!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Fornecedor fornecedor in listaFornecedores)
            {
                Console.WriteLine("|{0,-3}|{1,-11}|{2,-13}|{3,-11}|{4,-14}|", fornecedor.id, fornecedor.nome, fornecedor.cnpj, fornecedor.telefone, fornecedor.endereco);
            }

            Console.ReadKey();
        }

        public void DeletarFornecedor()
        {
            ListarFornecedor();
            int idSelecionado = ReceberIdFornecedor();
            repositorioFornecedor.Deletar(idSelecionado);
            Mensagem("Fornecedor excluído com sucesso!", ConsoleColor.Green);
        }

        public int ReceberIdFornecedor()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.Write("Digite o id do fornecedor: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioFornecedor.SelecionarId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Fornecedor ObterFornecedor()
        {
            Console.Write("Informe o nome do fornecedor: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o CNPJ do fornecedor: ");
            int cnpj = int.Parse(Console.ReadLine());

            Console.Write("Informe o telefone do fornecedor: ");
            int telefone = int.Parse(Console.ReadLine());

            Console.Write("Informe o endereço do fornecedor: ");
            string endereco = Console.ReadLine();

            Fornecedor fornecedor = new Fornecedor(repositorioFornecedor.contadorId, nome, cnpj, telefone, endereco);

            return fornecedor;
        }
    }
}