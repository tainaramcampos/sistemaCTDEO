using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationCTDEO.Models
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public string Nome { get; set; }
        public int ModalidadeId { get; set; }
        [ForeignKey("ModalidadeId")]
        public Modalidade Modalidade { get; set; }

        public Turma()
        {
            this.Alunos = new HashSet<Aluno>();
        }

        public virtual ICollection<Aluno> Alunos { get; set; }
        public DiadaSemana Dias { get; set; }
        public DateTime Horario { get; set; }
    }

    public enum DiadaSemana
    {
        Segunda = 0,
        Terca = 1,
        Quarta = 2,
        Quinta = 3,
        Sexta = 4,
        Sabado = 5,
        Domingo = 6
    }
    
    public class Modalidade
    {
        public int ModalidadeId { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
    }
}