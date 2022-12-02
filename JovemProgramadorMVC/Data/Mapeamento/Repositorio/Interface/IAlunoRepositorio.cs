using JovemProgramadorMVC.Models;

namespace JovemProgramadorMVC.Data.Mapeamento.Repositório.Interface
{
    public interface IAlunoRepositorio
    {
        void InserirAluno(AlunoModel alunos);

        List<AlunoModel> BuscarAlunos();
    }
}
