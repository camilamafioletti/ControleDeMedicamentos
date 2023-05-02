using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : Tela
    {
        private RepositorioFornecedor repositorioFornecedor = null;

        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor)
        {
            repositorio = repositorioFornecedor;
            this.repositorioFornecedor = repositorioFornecedor;
        }

        protected override void MostrarTabela(ArrayList listaFornecedores)
        {

            Console.Clear();
            Console.WriteLine("Funcionario registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Nome       |CNPJ         |Telefone   |Endereço      |");
            Console.WriteLine("----------------------------------------------------------");
            Console.ResetColor();

            foreach (Fornecedor fornecedor in listaFornecedores)
            {
                Console.WriteLine("|{0,-3}|{1,-11}|{2,-13}|{3,-11}|{4,-14}|", fornecedor.id, fornecedor.nome, fornecedor.cnpj, fornecedor.telefone, fornecedor.endereco);
            }

            Console.ReadKey();
        }

        protected override Entidade ObterRegistro()
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