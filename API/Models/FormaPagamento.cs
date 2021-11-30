using System;

namespace API.Models
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public FormaPagamento() => CriadoEm = DateTime.Now;
        public DateTime CriadoEm { get; set; }
        public string Numero { get; set; }
        public string Nome { get; set; }
        public string Vencimento {get;set;}
        public string Cvv { get; set; }

    }


}