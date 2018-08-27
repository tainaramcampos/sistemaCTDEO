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
        public List<DiadaSemana> Dias { get; set; }
        public DateTime Horario { get; set; }
        public TurnoTurma Turno { get; set; }
    }

    public class DiadaSemana
    {
        public int Id { get; set; }
        public string Nomes { get; set; }
    }

    public enum TurnoTurma
    {
        Manhã, Tarde
    }

    }