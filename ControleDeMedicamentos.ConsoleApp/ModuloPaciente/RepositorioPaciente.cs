using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class RepositorioPaciente : Repositorio
    {
        public RepositorioPaciente(ArrayList listaPaciente)
        {
            this.listaRegistros = listaPaciente;
        }

        public override Paciente SelecionarId(int id)
        {
            return (Paciente)base.SelecionarId(id);
        }
    }
}
