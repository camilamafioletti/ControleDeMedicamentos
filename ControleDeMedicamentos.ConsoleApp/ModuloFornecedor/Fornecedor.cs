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

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (nome.Length <= 3)
                erros.Add("O campo \"nome\" precisa ter mais que 3 letras");


            return erros;
        }

    }
}
