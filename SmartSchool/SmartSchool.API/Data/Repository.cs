using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public class Repository : IRepository
    {
        public readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<PageList<Aluno>> GetAllAlunos(
            PageParams pageParams,
            bool includeProfessores = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessores){
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            if (!string.IsNullOrEmpty(pageParams.Nome))
                query = query.Where(aluno => aluno.Nome
                                                .ToUpper()
                                                .Contains(pageParams.Nome.ToUpper()) || 
                                            aluno.Sobrenome
                                                .ToUpper()
                                                .Contains(pageParams.Nome.ToUpper()));

            if (pageParams.Matricula > 0)
                query = query.Where(aluno => aluno.Matricula == pageParams.Matricula);

            if (pageParams.Ativo != null)
                query = query.Where(aluno => aluno.Ativo == pageParams.Ativo);

            //return await query.ToListAsync();
            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<Aluno[]> GetAllAlunosByDisciplinaIdAsync(int disciplinaId, bool includeProfessores = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessores){
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(a => a.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return await query.ToArrayAsync();
        }

        public Aluno GetAlunoById(int alunoId, bool includeProfessores = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessores){
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(a => a.Id == alunoId);

            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAlunos){
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAlunos){
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                    .OrderBy(p => p.Id)
                    .Where(p => p.Disciplinas.Any(
                        d => d.Id == disciplinaId
                    ));

            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAlunos){
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                    .OrderBy(p => p.Id)
                    .Where(p => p.Id == professorId);

            return query.FirstOrDefault();
        }

        public Professor[] GetProfessoresByAlunoId(int alunoId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAlunos){
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                    .OrderBy(p => p.Id)
                    .Where(aluno => aluno.Disciplinas.Any(
                        d => d.AlunosDisciplinas.Any(ad => ad.AlunoId == alunoId)
                    ));

            return query.ToArray();
        }
    }
}