using JovemProgramadorMVC.Models;
using JovemProgramadorMVC.Controllers;

namespace JovemProgramadorMVC.Data.Repositorio.Interface
{
    public interface IProfessorRepositorio
    {
        void InserirProfessor(ProfessorModel professor);

        List<ProfessorModel> BuscarProfessores();

        ProfessorModel BuscarId(int id);

        void Atualizar(ProfessorModel professor);

        void ExcluirProfessor(ProfessorModel professor);


    }
}
