using System;

namespace SmartSchool.API.DTOs
{
    public class AlunoDto
    {
        /// <summary>
        /// Identificador e chave do Banco
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Chave do Aluno, para outros neg�cios na Institui��o
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Nome � o Primeiro nome e o sobrenome do Aluno
        /// </summary>
        public string Nome { get; set; }
        public string Telefone { get; set; }
        /// <summary>
        /// Esta idade � o c�lculo relacionado a data de nascimento do Aluno
        /// </summary>
        public int Idade { get; set; }
        public DateTime DataIni { get; set; }
        public bool Ativo { get; set; }
    }
}