using System.Collections.Generic;

namespace SmartSchool.API.Models
{
  public class Disciplina
  {
    public Disciplina() { }

    public Disciplina(int id, string nome, int propessorId)
    {
      this.Id = id;
      this.Nome = nome;
      this.PropessorId = propessorId;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public int PropessorId { get; set; }
    public Professor Professor { get; set; }
    public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
  }
}
