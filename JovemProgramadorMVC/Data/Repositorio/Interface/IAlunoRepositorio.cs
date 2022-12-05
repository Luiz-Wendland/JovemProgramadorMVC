using JovemProgramadorMVC.Models;
using JovemProgramadorMVC.Controllers;

namespace JovemProgramadorMVC.Data.Repositorio.Interface
{
    public interface IAlunoRepositorio
    {
        void InserirAluno(AlunoModel aluno);

        List<AlunoModel> BuscarAlunos();

        AlunoModel BuscarId(int id);

        void Atualizar(AlunoModel aluno);

        void ExcluirAluno(AlunoModel aluno);


    }
}
