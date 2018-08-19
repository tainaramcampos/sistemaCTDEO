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
    }
    
    public class Futebol : Modalidade
    {
        private NivelModalidade _nivel;
        public NivelModalidade NivelFutebol //o futebol apenas possui o nível T1 -adequação
        {
            get { return _nivel; }
                
            set{ _nivel = NivelModalidade.T1Adequacao; }
        }
    }

    public class Atletismo : Modalidade
    {
        public NivelModalidade NivelAtletismo { get; set; }
        public GruposAtletismo Grupo { get; set; }
    }

    public class AtletismoIntegrado : Modalidade
    {
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