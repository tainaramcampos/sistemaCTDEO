using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationCTDEO.Models
{
    public class Modalidade
    {
        public int ModalidadeId { get; set; }

        [Display(Name = "Modalidade")]
        public string Nome { get; set; }

        [Display(Name = "Nível")]
        public NivelModalidade? Nivel { get; set; }

        [Display(Name = "Grupo")]
        public GruposAtletismo? GrupoAtl { get; set; }
    }
    
    
    public enum NivelModalidade
    {
        [Display(Name = "T1 - Adaptação")] T1Adaptacao,
        [Display(Name = "T1 - Adequação")]
        T1Adequacao,
        [Display(Name = "T2 - Adequação")]
        T2Adequacao,
        [Display(Name = "T2 - Desenvolvimento")]
        T2Desenvolvimento,
        [Display(Name = "T3 - Aperfeiçoamento")]
        T3Aperfeicoamento
    }

    public enum GruposAtletismo
    {
        [Display(Name = "Velocidade e Saltos")]
        VelocidadeeSaltos,
        [Display(Name = "Arremesso e Lançamento")]
        ArremessoeLançamento,
        [Display(Name = "Meio-Fundo e Fundo")]
        FundoMeiofundo 
    }
}