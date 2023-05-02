using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : Tela
    {
        private RepositorioPaciente repositorioPaciente = null;

        public TelaPaciente(RepositorioPaciente repositorioPaciente)
        {
            repositorio = repositorioPaciente;
            this.repositorioPaciente = repositorioPaciente;
        }

        protected override void MostrarTabela(ArrayList listaPacientes)
        {

            Console.Clear();
            Console.WriteLine("Paciente registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Nome       |CPF          |Telefone   |Endereço      |");
            Console.WriteLine("----------------------------------------------------------");
            Console.ResetColor();

            foreach (Paciente paciente in listaPacientes)
            {
                Console.WriteLine("|{0,-3}|{1,-11}|{2,-13}|{3,-11}|{4,-14}|", paciente.id, paciente.nome, paciente.cpf, paciente.telefone, paciente.endereco);
            }

            Console.ReadKey();
        }

        protected override Entidade ObterRegistro()
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
