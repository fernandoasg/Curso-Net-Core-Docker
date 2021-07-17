using System.Threading.Tasks;
using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // Alunos
        Task<Aluno[]> GetAllAlunos(bool includeProfessores = false);
        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessores = false);
        Aluno GetAlunoById(int alunoId, bool includeProfessores = false);

        // Professores
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
        Professor GetProfessorById(int professorId, bool includeAlunos = false); 
    }
}