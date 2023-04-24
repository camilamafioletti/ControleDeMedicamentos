using ControleDeMedicamentos.ConsoleApp;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : Tela
    {
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFornecedor repositorioFornecedor = null;

        public string ApresentarMenuMedicamento()
        {

            Console.Clear();

            Console.WriteLine("(1) Adicionar medicamento");
            Console.WriteLine("(2) Visualizar medicamentos");
            Console.WriteLine("(3) Visualizar relatorio de medicamentos");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public void InserirNovoMedicamento()
        {
            Medicamento novoMedicamento = ObterMedicamento();

            repositorioMedicamento.Criar(novoMedicamento);

            Mensagem("Medicamento criado com sucesso!", ConsoleColor.Green);
        }

        public void ListarMedicamento()
        {
            ArrayList listaMedicamentos = repositorioMedicamento.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("Medicamentos registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Nome       |Fornecedor          |Quantidade         |");
            Console.WriteLine("----------------------------------------------------------");
            Console.ResetColor();

            if (listaMedicamentos.Count == 0)
            {
                Mensagem("Nenhum medicamento registrado!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Medicamento medicamento in listaMedicamentos)
            {
                Console.WriteLine("|{0,-3}|{1,-11}|{2,-13}|{3,-11}|", medicamento.id, medicamento.nomeMedicamento, medicamento.fornecedor.nome, medicamento.qntdDisponivel);
            }

            Console.ReadKey();
        }

        public void ListarRelatorioMedicamento()
        {
            ArrayList listaMedicamentos = repositorioMedicamento.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("Relatório de medicamentos:");
            Console.WriteLine();

            if (listaMedicamentos.Count == 0)
            {
                Mensagem("Nenhum medicamento registrado!", ConsoleColor.DarkRed);
                return;
            }
            Console.WriteLine("Medicamentos em falta: \n");
            foreach (Medicamento medicamento in listaMedicamentos)
            {
                if (medicamento.qntdDisponivel < 10)
                {
                    Console.WriteLine(medicamento.nomeMedicamento);
                }
            }

            Console.ReadKey();
        }

        public int ReceberIdMedicamento()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.Write("Digite o id do medicamento: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioMedicamento.SelecionarId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Medicamento ObterMedicamento()
        {
            Console.Write("Informe o nome do medicamento: ");
            string nomeMedicamento = Console.ReadLine();

            Console.Write("Informe a descricao do medicamento: ");
            string descricao = Console.ReadLine();

            Console.Write("Informe a quantidade do medicamento: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Informe a quantidade limite do medicamento: ");
            int qntdLimite = int.Parse(Console.ReadLine());

            Console.Write("Informe o id do fornecedor do medicamento: ");
            int fornecedorId = int.Parse(Console.ReadLine());

            Fornecedor fornecedor = (Fornecedor)repositorioFornecedor.SelecionarId(fornecedorId);

            Medicamento medicamento = new Medicamento(repositorioMedicamento.contadorId, nomeMedicamento, descricao, quantidade, qntdLimite, fornecedor);

            medicamento.SomarQntd(quantidade);
            medicamento.ValidarQuantidade();

            return medicamento;
        }
    }
}
