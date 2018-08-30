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
       

        [NotMapped]
        public List<string> ListadeDias { get; set; } //lista de dias a serem escolhidos (para montar a string de dias)
        [NotMapped]
        public List<string> DiasdaSemana { get; set; }

        public string Dias { get; set; }

        public int TurmaId { get; set; }

        public string Nome { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int ModalidadeId { get; set; }

        [ForeignKey("ModalidadeId")]
        public Modalidade Modalidade { get; set; }
        
        public virtual ICollection<Aluno> Alunos { get; set; }
        

        public string Horario { get; set; }
        public TurnoTurma Turno { get; set; }
        
        public Turma()
        {
            this.Alunos = new HashSet<Aluno>();
            this.ListadeDias = new List<string>();
            // DiasdaSemana = new List<string>();
            this.DiasdaSemana = new List<string> { "segunda", "terça", "quarta", "quinta","sexta","sábado","domingo"};

        }

    }



    public enum TurnoTurma
    {
        Manhã, Tarde
    }

    }