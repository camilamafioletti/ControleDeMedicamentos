using ControleDeMedicamentos.ConsoleApp.ModuloAquisicao;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(new ArrayList());
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor(new ArrayList());
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente(new ArrayList());
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento(new ArrayList());
            RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao(new ArrayList());
            RepositorioAquisicao repositorioAquisicao = new RepositorioAquisicao(new ArrayList());

            TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);
            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
            TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioFornecedor);
            TelaMedicamento telaMedicamento = new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);
            TelaRequisicao telaRequisicao = new TelaRequisicao(repositorioRequisicao, repositorioPaciente, repositorioMedicamento, repositorioFuncionario);
            TelaAquisicao telaAquisicao = new TelaAquisicao(repositorioAquisicao, repositorioMedicamento, repositorioFornecedor, repositorioFuncionario);

            Menus menus = new Menus(telaPaciente, telaMedicamento, telaFornecedor, telaFuncionario, telaRequisicao, telaAquisicao);

            telaPaciente.nomeEntidade = "Paciente";
            telaFuncionario.nomeEntidade = "Funcionario";
            telaMedicamento.nomeEntidade = "Medicamento";
            telaFornecedor.nomeEntidade = "Fornecedor";
            telaRequisicao.nomeEntidade = "Requisição";
            telaAquisicao.nomeEntidade = "Aquisições";

            menus.MenuPrincipal();
        }
    }
}