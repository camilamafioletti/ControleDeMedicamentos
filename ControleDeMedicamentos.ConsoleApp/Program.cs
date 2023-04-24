using ControleDeMedicamentos.ConsoleApp.ModuloAquisicao;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleDeMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menus menus = new Menus();

            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao();
            RepositorioAquisicao repositorioAquisicao = new RepositorioAquisicao();

            TelaPaciente telaPaciente = new TelaPaciente();
            TelaFuncionario telaFuncionario = new TelaFuncionario();
            TelaFornecedor telaFornecedor = new TelaFornecedor();
            TelaMedicamento telaMedicamento = new TelaMedicamento();
            TelaRequisicao telaRequisicao = new TelaRequisicao();
            TelaAquisicao telaAquisicao = new TelaAquisicao();

            telaPaciente.repositorioPaciente = repositorioPaciente;
            telaFuncionario.repositorioFuncionario = repositorioFuncionario;

            telaMedicamento.repositorioMedicamento = repositorioMedicamento;
            telaMedicamento.repositorioFornecedor = repositorioFornecedor;
            telaMedicamento.repositorioMedicamento = repositorioMedicamento;

            telaFornecedor.repositorioFornecedor = repositorioFornecedor;

            telaRequisicao.repositorioRequisicao = repositorioRequisicao;
            telaRequisicao.repositorioPaciente = repositorioPaciente;
            telaRequisicao.repositorioMedicamento = repositorioMedicamento;
            telaRequisicao.repositorioFuncionario = repositorioFuncionario;

            telaAquisicao.repositorioAquisicao = repositorioAquisicao;
            telaAquisicao.repositorioMedicamento = repositorioMedicamento;
            telaAquisicao.repositorioFornecedor = repositorioFornecedor;
            telaAquisicao.repositorioFuncionario = repositorioFuncionario;
            
            menus.telaFuncionario = telaFuncionario;
            menus.telaRequisicao = telaRequisicao;
            menus.telaPaciente = telaPaciente;
            menus.telaAquisicao = telaAquisicao;
            menus.telaMedicamento = telaMedicamento;
            menus.telaFornecedor = telaFornecedor;

            menus.MenuPrincipal();
        }
    }
}