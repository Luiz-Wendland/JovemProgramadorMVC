using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;


namespace JovemProgramadorMVC.Data.Repositorio
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly JovemProgramadorContexto _jovemProgramadorContexto;

        public ProfessorRepositorio(JovemProgramadorContexto jovemProgramadorContexto)
        {
            _jovemProgramadorContexto = jovemProgramadorContexto;
        }

        public void InserirProfessor(ProfessorModel professor)
        {
            _jovemProgramadorContexto.Professor.Add(professor);
            _jovemProgramadorContexto.SaveChanges();
        }

        public List<ProfessorModel> BuscarProfessores()
        {
            return _jovemProgramadorContexto.Professor.ToList();
        }

        public ProfessorModel BuscarId(int id)
        {
            return _jovemProgramadorContexto.Professor.FirstOrDefault(x => x.Id == id);
        }

        public void Atualizar(ProfessorModel professor)
        {

            _jovemProgramadorContexto.Professor.Update(professor);
            _jovemProgramadorContexto.SaveChanges();

        }

        public void ExcluirProfessor(ProfessorModel professor)
        {
            _jovemProgramadorContexto.Professor.Remove(professor);
            _jovemProgramadorContexto.SaveChanges();
        }

    }
}
