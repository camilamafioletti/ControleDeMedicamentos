using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : Tela
    {
        public RepositorioPaciente repositorioPaciente = null;

        public string ApresentarMenuPaciente()
        {
            Console.Clear();

            Console.WriteLine("(1) Adicionar paciente");
            Console.WriteLine("(2) Editar paciente");
            Console.WriteLine("(3) Visualizar pacientes");
            Console.WriteLine("(4) Excluir paciente");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public void InserirNovoPaciente()
        {
            Paciente novoPaciente = ObterPaciente();

            repositorioPaciente.Criar(novoPaciente);

            Mensagem("Paciente criado com sucesso!", ConsoleColor.Green);
        }

        public void EditarPaciente()
        {
            ListarPaciente();
            int idSelecionado = ReceberIdPaciente();
            Paciente pacienteAtualizado = ObterPaciente();

            repositorioPaciente.Editar(idSelecionado, pacienteAtualizado);
            Mensagem("Sucesso!", ConsoleColor.Green);

        }

        public void ListarPaciente()
        {
            ArrayList listaPacientes = repositorioPaciente.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("Paciente registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Nome       |CPF          |Telefone   |Endereço      |");
            Console.WriteLine("----------------------------------------------------------");
            Console.ResetColor();

            if (listaPacientes.Count == 0)
            {
                Mensagem("Nenhum paciente registrado!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Paciente paciente in listaPacientes)
            {
                Console.WriteLine("|{0,-3}|{1,-11}|{2,-13}|{3,-11}|{4,-14}|", paciente.id, paciente.nome, paciente.cpf, paciente.telefone, paciente.endereco);
            }

            Console.ReadKey();
        }

        public void DeletarPaciente()
        {
            ListarPaciente();
            int idSelecionado = ReceberIdPaciente();
            repositorioPaciente.Deletar(idSelecionado);
            Mensagem("Paciente excluída com sucesso!", ConsoleColor.Green);
        }

        public int ReceberIdPaciente()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.Write("Digite o id do paciente: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioPaciente.SelecionarId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Paciente ObterPaciente()
        {
            Console.Write("Informe o nome do paciente: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o cpf do paciente: ");
            int cpf = int.Parse (Console.ReadLine());

            Console.Write("Informe o telefone do paciente: ");
            int telefone = int.Parse(Console.ReadLine());

            Console.Write("Informe o endereço do paciente: ");
            string endereco = Console.ReadLine();

            Paciente paciente = new Paciente(repositorioPaciente.contadorId, nome, cpf, telefone, endereco);

            return paciente;
        }
    }
}
