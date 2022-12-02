using JovemProgramadorMVC.Models;

namespace JovemProgramadorMVC.Data.Mapeamento.Repositório.Interface
{
    public class AlunoRepositorio: IAlunoRepositorio
    {
        private readonly JovemProgramadorContexto _jovemProgramadorContexto;

        public AlunoRepositorio(JovemProgramadorContexto jovemProgramadorContexto)
        {
            _jovemProgramadorContexto = jovemProgramadorContexto;
        }
        public void InserirAluno(AlunoModel alunos)
        {
            _jovemProgramadorContexto.Aluno.Add(alunos);
            _jovemProgramadorContexto.SaveChanges();
        }
        
        public List<AlunoModel> BuscarAlunos()
        {
            return _jovemProgramadorContexto.Aluno.ToList();
        }

        public AlunoModel BuscarId(int id)
        {
            return _jovemProgramadorContexto.Aluno.FirstOrDefault(X => X.Id ==id);
        }

        public void EditarAluno(AlunoModel alunos)
        {
            _jovemProgramadorContexto.Aluno.Update(alunos);
            _jovemProgramadorContexto.SaveChanges();
        }

        public void ExcluirAluno(AlunoModel alunos)
        {
            _jovemProgramadorContexto.Aluno.Remove(alunos);
            _jovemProgramadorContexto.SaveChanges();
        }
    }
}
