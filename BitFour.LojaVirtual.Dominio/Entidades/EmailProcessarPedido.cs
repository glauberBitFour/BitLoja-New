using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BitFour.LojaVirtual.Dominio.Entidades
{
   public class EmailProcessarPedido
   {
       private readonly EmailConfiguracoes _emailConfiguracoes;

       public EmailProcessarPedido(EmailConfiguracoes configuracoes)
       {
           this._emailConfiguracoes = configuracoes;
       }

       public void ProcessarPedido( Carrinho carrinho,Pedido pedido)
       {
           using (var smtpClient = new SmtpClient())
           {
               smtpClient.EnableSsl = _emailConfiguracoes.UsarSsl;
               smtpClient.Host = _emailConfiguracoes.ServidorSmtp;
               smtpClient.Port = _emailConfiguracoes.ServidorPorta;
               smtpClient.UseDefaultCredentials = false;
               smtpClient.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario,
                   _emailConfiguracoes.ServidorSmtp);

               if (_emailConfiguracoes.EscreverArquivo)
               {
                   smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                   smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaDoArquivo;
                   smtpClient.EnableSsl = false;
                   StringBuilder body = new StringBuilder()
                       .AppendLine("Novo Pedido")
                       .AppendLine("-----------")
                       .AppendLine("Itens")
                       ;
                   foreach (var item in carrinho.ItensCarrinho)
                   {
                       var total = item.Produto.Preco*item.Quantidade;
                       body.AppendFormat("{0} x {1} (subtotal:{2:c}",
                           item.Quantidade, item.Produto.Nome, total);

                   }
                   body.AppendFormat("Valor Total do Pedido:{0:c}", carrinho.ObterValorTotal())
                       .AppendLine("------------------------------")
                       .AppendLine("Enviar para:")
                       .AppendLine(pedido.NomeCliente)
                       .AppendLine(pedido.Endereco ?? "")
                       .AppendLine(pedido.Cidade ?? "")
                       .AppendLine(pedido.Complememento ?? "")
                       .AppendLine("-----------------------------")
                       .AppendFormat("Para presente?: {0}", pedido.EnbrulhaPresente ? "Sim" : "Nao");

                    MailMessage mailMessage = new MailMessage(
                        _emailConfiguracoes.De,
                        _emailConfiguracoes.Para,
                        "Novo Pedido",body.ToString());


                   if (_emailConfiguracoes.EscreverArquivo)
                   {
                       mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                        smtpClient.Send(mailMessage);
                   }



               }
           }
       }
   }
}
