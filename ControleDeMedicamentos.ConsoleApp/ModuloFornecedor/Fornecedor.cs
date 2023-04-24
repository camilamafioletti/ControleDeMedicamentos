using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class Fornecedor : Entidade
    {
        public string nome; 
        public int cnpj;
        public int telefone;
        public string endereco;

        public Fornecedor(int id, string nome, int cnpj, int telefone, string endereco)
        {
            this.id = id;
            this.nome = nome;
            this.cnpj = cnpj;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Fornecedor fornecedor = (Fornecedor)registroAtualizado;

            nome = fornecedor.nome;
            cnpj = fornecedor.cnpj;
            telefone = fornecedor.telefone;
            endereco = fornecedor.endereco;
        }
    }
}
