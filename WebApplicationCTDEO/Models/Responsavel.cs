using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationCTDEO.Models
{
    public class Responsavel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public List<string> Telefones { get; set; }
    }
}