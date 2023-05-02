using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class Funcionario : Entidade
    {
        public string nome;
        public int cpf;
        public int telefone;
        public string endereco;

        public Funcionario(int id, string nome, int cpf, int telefone, string endereco)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Funcionario funcionario = (Funcionario)registroAtualizado;

            nome = funcionario.nome;
            cpf = funcionario.cpf;
            telefone = funcionario.telefone;
            endereco = funcionario.endereco;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            return erros;
        }
    }
}
