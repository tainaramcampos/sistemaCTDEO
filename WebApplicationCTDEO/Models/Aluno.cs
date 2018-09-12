using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCTDEO.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public Sexo? Genero { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DatadeNascimento { get; set; }

        [Display(Name = "Procedência")]
        public string Procedencia { get; set; }

        public Aluno()
        {
            this.Turmas = new HashSet<Turma>();
            this.Familiar = new HashSet<Familiar>();
        }

        public virtual ICollection<Turma> Turmas { get; set; }


        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        [NotMapped]
        public string IdsdeTurmas { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        [Display(Name = "Órgão Expedidor")]
        public string OrgaoExp { get; set; }

        [Display(Name = "Data da Expedição")]
        [DataType(DataType.Date)]
        public DateTime? DatadeExp { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Endereco { get; set; }

        [Display(Name = "Número")]
        public int? Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Bairro { get; set; }

        [Display(Name = "Município")]
        public string Municipio { get; set; }

        public string Comunidade { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string CEP { get; set; }

        [Display(Name = "Telefone Residencial")]
        [DataType(DataType.PhoneNumber)]
        public string TelefoneResidencial { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Celular { get; set; }

        public virtual ICollection<Familiar> Familiar { get; set; }

        [Display(Name = "Instituição de Ensino")]
        public string InstituicaodeEnsino { get; set; }

        [Display(Name = "Rede de Ensino")]
        public Instituicao? RededeEnsino { get; set; }

        [Display(Name = "Região Administrativa")]
        public string RegiaoAdministrativa { get; set; }

        [Display(Name = "Bolsa de Estudos")]
        public bool BolsadeEstudos { get; set; }

        [Display(Name = "Sistema de Ensino")]
        public TipodeInst? SistemadeEnsino { get; set; }

        [Display(Name = "Sério")]
        public Nivel? Serie { get; set; }

        public HorariodeEstudo? Turno { get; set; }

        public TipodeTransporte? Transporte { get; set; }

        [Display(Name = "Registro da Federação")]
        public string RegistroFed { get; set; }

        [Display(Name = "Tipo de Bolsa")]
        public TipodeBolsa? TipodeBolsaAtleta { get; set; }
    }

    public enum Sexo
    {
        Masculino, Feminino
    }

    public enum Nivel
    {
        [Display(Name = "Ensino Infantil")] EnsinoInfantil,
        [Display(Name = "1º ano")] primeiro, [Display(Name = "2º ano")] segundo, [Display(Name = "3º ano")] terceiro,
        [Display(Name = "4º ano")] quarto, [Display(Name = "5º ano")] quinto, [Display(Name = "6º ano")] sexto, [Display(Name = "7º ano")] setimo,
        [Display(Name = "8º ano")] oitavo, [Display(Name = "9º ano")] nono, [Display(Name = "1º ano do ensino médio")] primeiroEM,
        [Display(Name = "2º ano do ensino médio")] segundoEm, [Display(Name = "3º ano do ensino médio")] terceiroEm,
        [Display(Name = "Ensino superior")] ensinoSuperior
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
        [Display(Name = "Manhã")] Manha, Tarde, Noite, Integral
    }
    public enum TipodeInst
    {
        Municipal, Estadual, Federal
    }
    public enum Instituicao
    {
        [Display(Name = "Pública")] Publica, Privada
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

    public RespSustento? Sustento { get; set; }

    public int TrabalhadoresNaFamilia { get; set; }

    public Renda? RendaMensal { get; set; }

    public string TipodeBeneficio { get; set; }

    public TipoResidencia? Residencia { get; set; }

    public int QtasCriancasEstudando { get; set; }

    public string EnfermidadesnaFamilia { get; set; }

    public string Fumantes { get; set; }

    public string Alcoolismo { get; set; }

    public string EnvolvidocomDrogas { get; set; }

    public ComoSoube? ComoConheceu { get; set; }

    public string OutroProjetoqParticipa { get; set; }
    }

    public enum RespSustento //checkbox
    {
        Pai, [Display(Name = "Mãe")] Mae, [Display(Name = "Pai e Mãe")] PaieMae, Padrasto, [Display(Name = "Irmão")] Irmao,
        [Display(Name = "Avós")] Avos, Outros
    }

    public enum ComoSoube
    {
        Aluno, Parceiros, Escola, Panfleto, Internet, Outros
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