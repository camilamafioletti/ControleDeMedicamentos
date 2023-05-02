using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario : Tela
    {
        private RepositorioFuncionario repositorioFuncionario = null;

        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            repositorio = repositorioFuncionario;
            this.repositorioFuncionario = repositorioFuncionario;
        }

        protected override void MostrarTabela(ArrayList listaFuncionarios)
        {

            Console.Clear();
            Console.WriteLine("Funcionarios registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Nome       |CPF          |Telefone   |Endereço      |");
            Console.WriteLine("----------------------------------------------------------");
            Console.ResetColor();

            foreach (Funcionario funcionario in listaFuncionarios)
            {
                Console.WriteLine("|{0,-3}|{1,-11}|{2,-13}|{3,-11}|{4,-14}|", funcionario.id, funcionario.nome, funcionario.cpf, funcionario.telefone, funcionario.endereco);
            }

            Console.ReadKey();
        }

        protected override Entidade ObterRegistro()
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
