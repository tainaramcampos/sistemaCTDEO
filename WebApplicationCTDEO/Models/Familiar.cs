using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationCTDEO.Models
{
    public class Familiar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CPF { get; set; }

        public Familiar()
        {
            this.Alunos = new HashSet<Aluno>();
        }

        public virtual ICollection<Aluno> Alunos { get; set; }
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public List<string> Telefones { get; set; }
        public string GraudeParentesco { get; set; }
        public bool IsResponsavel { get; set; }
    }
}