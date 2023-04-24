namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : Entidade
    {
        public string nome;
        public int cpf;
        public int telefone;
        public string endereco;

        public Paciente(int id, string nome, int cpf, int telefone, string endereco)
        {
            this.id = id;   
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {

            Paciente paciente = (Paciente)registroAtualizado;

            nome = paciente.nome;
            cpf = paciente.cpf;
            telefone = paciente.telefone;
            endereco = paciente.endereco;

        }
    }
}
