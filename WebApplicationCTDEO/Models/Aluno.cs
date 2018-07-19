using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationCTDEO.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public Sexo Genero { get; set; }
        public DateTime DatadeNascimento { get; set; }
        public Projetos Procedencia { get; set; }
        public ICollection<Turma> Turmas { get; set; }
        public int TurmaId { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string OrgaoExp { get; set; }
        public DateTime DatadeExp { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Comunidade { get; set; }
        public string CEP { get; set; }
        public string TelefoneResidencial { get; set; }
        public string Celular { get; set; }
        public string MaeCPF { get; set; }
        [ForeignKey("MaeCPF")]
        public virtual Responsavel Mae { get; set; }
        public string PaiCPF { get; set; }
        [ForeignKey("PaiCPF")]
        public Responsavel Pai { get; set; }
        public TipoResponsavel EscolhaResponsavel { get; set; }
        public string NomeResponsavel { get; set; }
        public string GraudeParentesco { get; set; }
        public string TelefonesResponsavel { get; set; }
        public string InstituicaodeEnsino { get; set; }
        public Instituicao RededeEnsino { get; set; }
        public string CRE { get; set; }
        public bool BolsadeEstudos { get; set; }
        public TipodeInst TipodeInstituicao { get; set; }
        public string Serie { get; set; }
        public HorariodeEstudo Turno { get; set; }
        public TipodeTransporte Transporte { get; set; }
        public string RegistroFed { get; set; }
        public TipodeBolsa TipodeBolsaAtleta { get; set; }
    }
    public enum Sexo
    {
        Feminino, Masculino
    }
    
    public enum TipodeBolsa
    {
        Futuro, Regional, Nacional, Internacional
    }

    public enum TipodeTransporte
    {
        Ape, Bicicleta, Onibus, OnibuseTrem, Trem, Particular
    }

    public enum HorariodeEstudo
    {
        Manha, Tarde, Noite, Integral
    }
    public enum TipodeInst
    {
        Metropolitana, Federal
    }
    public enum Instituicao
    {
        Publica, Privada
    }
    public enum Projetos
    {
        BonsFrutos, PRCC, CRAS, CRE
    }
    public enum TipoResponsavel
    {
        Mae, Pai, Outro
    }
    
    public class AlunoSocial
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int AlunoId { get; set; }
    [ForeignKey("AlunoId")]
    public virtual Aluno Aluno { get; set; }
    public bool PaisSeparados { get; set; }
    public bool NMoraComPais { get; set; }
    public string JustificativaNMoraCPais { get; set; }
    public virtual List<Familiares> Familiares { get; set; }
    public RespSustento Sustento { get; set; }
    public int TrabalhadoresNaFamilia { get; set; }
    public Renda RendaMensal { get; set; }
    public string TipodeBeneficio { get; set; }
    public TipoResidencia Residencia { get; set; }
    public int QtasCriancasEstudando { get; set; }
    public List<string> EnfermidadesnaFamilia { get; set; }
    public string Fumantes { get; set; }
    public string Alcoolismo { get; set; }
    public string EnvolvidocomDrogas { get; set; }
    public ComoSoube ComoConheceu { get; set; }
    public string OutroProjetoqParticipa { get; set; }
    }

    public enum RespSustento //checkbox
    {
        Pai, Mae, PaieMae, Padrasto, Irmao, Avos, Outros
    }

    public enum ComoSoube
    {
        Aluno, Rede, Escola, Panfleto, Outros
    }

    public enum Renda
    {
        Ate1Sal, Ate3Sal, Acima3Sal, SemRenda
    }

    public enum TipoResidencia
    {
        Propria, Cedida, Alugada
    }

    public class Familiares
    {
        [Key]
        public int FamiliarId { get; set; }
        public int AlunoSocialId { get; set; }
        [ForeignKey("AlunoSocialId")]
        public virtual AlunoSocial Aluno { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Vinculo { get; set; }
        public string Escolaridade { get; set; }
        public string Ocupacao { get; set; }
    }

}