using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : Tela
    {
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFornecedor repositorioFornecedor = null;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor)
        {
            repositorio = repositorioMedicamento;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
        }

        public override void InserirNovoRegistro()
        {
            bool temRegistros = repositorioFornecedor.TemRegistros();

            if (temRegistros == false)
            {
                Mensagem("Cadastre ao menos um fornecedor para cadastrar medicamentos", ConsoleColor.DarkYellow);
                return;
            }

            base.InserirNovoRegistro();
        }

        public override string ApresentarMenu()
        {

            Console.Clear();

            Console.WriteLine("(1) Adicionar medicamento");
            Console.WriteLine("(2) Visualizar medicamentos");
            Console.WriteLine("(3) Visualizar medicamentos em falta");
            Console.WriteLine("(4) Visualizar medicamentos mais retirados");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        protected override void MostrarTabela(ArrayList listaMedicamentos)
        {

            Console.Clear();
            Console.WriteLine("Medicamentos registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Nome       |Fornecedor          |Quantidade         |");
            Console.WriteLine("----------------------------------------------------------");
            Console.ResetColor();

            foreach (Medicamento medicamento in listaMedicamentos)
            {
                Console.WriteLine("|{0,-3}|{1,-11}|{2,-13}|{3,-11}|", medicamento.id, medicamento.nomeMedicamento, medicamento.fornecedor.nome, medicamento.qntdDisponivel);
            }

            Console.ReadKey();
        }

        public void ListarRelatorioMedicamentoEmFalta()
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

        public void VisualizarMedicamentosMaisRetirados()
        {

            ArrayList medicamentosMaisRetirados = repositorioMedicamento.SelecionarMedicamentosMaisRetirados();

            if (medicamentosMaisRetirados.Count == 0)
            {
                Mensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow);
                return;
            }
            Console.WriteLine("Medicamentos mais retirados: \n");

            foreach (Medicamento medicamento in medicamentosMaisRetirados)
            {
                Console.WriteLine(medicamento.nomeMedicamento);
            }
            Console.ReadKey();
        }

        protected override Entidade ObterRegistro()
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
