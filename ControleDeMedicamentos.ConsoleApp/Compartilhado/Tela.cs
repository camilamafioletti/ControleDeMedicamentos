using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp
{
    public abstract class Tela
    {
        public string nomeEntidade;
        public Repositorio repositorio = null;

        public static void Mensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        public virtual string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"(1) Adicionar {nomeEntidade}");
            Console.WriteLine($"(2) Editar {nomeEntidade}");
            Console.WriteLine($"(3) Visualizar {nomeEntidade}");
            Console.WriteLine($"(4) Excluir {nomeEntidade}");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public virtual void DeletarRegistro()
        {
            VisualizarRegistros();
            int idSelecionado = ReceberId();
            repositorio.Deletar(idSelecionado);
            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public virtual void InserirNovoRegistro()
        {
            Entidade novoRegistro = ObterRegistro();

            if (ValidarErrosDeValidacao(novoRegistro))
            {
                InserirNovoRegistro();

                return;
            }

            repositorio.Criar(novoRegistro);

            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public void VisualizarRegistros()
        {
            ArrayList registros = repositorio.SelecionarTodos();

            if (registros.Count == 0)
            {
                Mensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(registros);
        }

        public virtual void EditarRegistro()
        {
            VisualizarRegistros();

            int idSelecionado = ReceberId();
            Entidade registroAtualizado = ObterRegistro();

            if (ValidarErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();

                return;
            }

            repositorio.Editar(idSelecionado, registroAtualizado);
            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public virtual int ReceberId()
        {
            int id = 0;
            bool idInvalido;

            do
            {
                Console.Write("Digite o id do registro: ");
                try
                {
                    id = int.Parse(Console.ReadLine());
                    idInvalido = repositorio.SelecionarId(id) == null;
                }
                catch (FormatException)
                {
                    idInvalido = true;
                }
                if (idInvalido)
                {
                    Mensagem("id inválido, tente novamente", ConsoleColor.Red);
                }

            } while (idInvalido);

            return id;
        }

        protected abstract Entidade ObterRegistro();

        protected abstract void MostrarTabela(ArrayList registros);

        protected bool ValidarErrosDeValidacao(Entidade registro)
        {
            bool temErros = false;

            ArrayList erros = registro.Validar();

            if (erros.Count > 0)
            {
                temErros = true;
                Console.ForegroundColor = ConsoleColor.Red;

                foreach (string erro in erros)
                {
                    Console.WriteLine(erro);
                }

                Console.ResetColor();

                Console.ReadLine();
            }

            return temErros;
        }

    }
}
