﻿using System;
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
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public Sexo Genero { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DatadeNascimento { get; set; }
        public Projetos? Procedencia { get; set; }

        public Aluno()
        {
            this.Turmas = new HashSet<Turma>();
            this.Familiar = new HashSet<Familiar>();
        }

        public virtual ICollection<Turma> Turmas { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string OrgaoExp { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DatadeExp { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Numero { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Comunidade { get; set; }
        public string CEP { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string TelefoneResidencial { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }
        public virtual ICollection<Familiar> Familiar { get; set; }
        public string InstituicaodeEnsino { get; set; }
        public Instituicao RededeEnsino { get; set; }
        public string CRE { get; set; }
        public bool BolsadeEstudos { get; set; }
        public TipodeInst TipodeInstituicao { get; set; }
        public string Serie { get; set; }
        public HorariodeEstudo Turno { get; set; }
        public TipodeTransporte Transporte { get; set; }
        public string RegistroFed { get; set; }
        public TipodeBolsa? TipodeBolsaAtleta { get; set; }
    }
    public enum Sexo
    {
        Masculino, Feminino
    }
    
    public enum TipodeBolsa
    {
        Futuro, Regional, Nacional, Internacional
    }

    public enum TipodeTransporte
    {
       [Display(Name = "A pé")] Ape, Bicicleta, [Display(Name = "Ônibus")] Onibus,
        [Display(Name = "Ônibus e Trem")] OnibuseTrem, Trem, [Display(Name = "Carro Particular")] Particular
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
        [Display(Name = "Pública")] Publica, Privada
    }
    public enum Projetos
    {
        BonsFrutos, PRCC, CRAS, CRE
    }
    public enum TipoResponsavel
    {
        [Display(Name = "Mãe")] Mae, Pai, Outro
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
    public virtual List<Moradores> Familiares { get; set; }
    public RespSustento Sustento { get; set; }
    public int TrabalhadoresNaFamilia { get; set; }
    public Renda RendaMensal { get; set; }
    public string TipodeBeneficio { get; set; }
    public TipoResidencia Residencia { get; set; }
    public int QtasCriancasEstudando { get; set; }
    public string EnfermidadesnaFamilia { get; set; }
    public string Fumantes { get; set; }
    public string Alcoolismo { get; set; }
    public string EnvolvidocomDrogas { get; set; }
    public ComoSoube ComoConheceu { get; set; }
    public string OutroProjetoqParticipa { get; set; }
    }

    public enum RespSustento //checkbox
    {
        Pai, [Display(Name = "Mãe")] Mae, [Display(Name = "Pai e Mãe")] PaieMae, Padrasto, [Display(Name = "Irmão")] Irmao,
        [Display(Name = "Avós")] Avos, Outros
    }

    public enum ComoSoube
    {
        Aluno, Rede, Escola, Panfleto, Outros
    }

    public enum Renda
    {
        [Display(Name = "Até 1 salário mínimo")] Ate1Sal, [Display(Name = "Até 3 salários mínimos")] Ate3Sal,
        [Display(Name = "Acima de 3 salários mínimos")] Acima3Sal,
        [Display(Name = "Vive de ajuda de terceiros")] SemRenda
    }

    public enum TipoResidencia
    {
        [Display(Name = "Própria")] Propria, Cedida, Alugada
    }

    public class Moradores
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