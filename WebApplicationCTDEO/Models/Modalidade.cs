using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCTDEO.Models
{
    public class Modalidade
    {
        public int ModalidadeId { get; set; }
        public string Nome { get; set; }
        public NivelModalidade Nivel { get; set; }
        public GruposAtletismo GrupoAtl { get; set; }
    }
    
    
    public enum NivelModalidade
    {
        T1Adaptacao, T1Adequacao, T2Desenvolvimento, T3Aperfeicoamento
    }

    public enum GruposAtletismo
    {
        VelocidadeeSaltos, ArremessoeLançamento, FundoMeiofundo 
    }
}