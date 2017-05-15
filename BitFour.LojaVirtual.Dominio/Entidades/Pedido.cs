

using System.ComponentModel.DataAnnotations;

namespace BitFour.LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {

        //data annotations para validaçao
        [Required(ErrorMessage = "Informe seu nome")]
        public string NomeCliente { get; set; }

        [Display(Name = "Cep:")]
        public string Cep { get; set; }

        [Display(Name = "Endereço:")]
        [Required(ErrorMessage = "Informe seu endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Complemento:")]
        public string Complememento { get; set; }

        [Display(Name = ("Estado"))]
        public string Estado { get; set; }


        [Required(ErrorMessage = "Informe sua cidade:")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Informe seu email:")]
        [EmailAddress(ErrorMessage = "E-mail Inválido")]
        public string Email { get; set; }

        [Display(Name = "Embrulha para presente!")]
        public bool EnbrulhaPresente { get; set; }

    }
}
