using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Application.ExternalServices.Email
{
    public static class Modelos
    {
        public static string AtivacaoConta()
        {
            return @"<table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%"">
    <tbody>
        <tr>
            <td align=""center"" bgcolor=""rgba(236, 239, 241, var(--bg-opacity))"" style=""background-color:#eceff1"">
                <table class=""x_sm-w-full"" width=""600"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""font-family:'Montserrat',Arial,sans-serif; width:600px"">
                    <tbody>
                        <tr>
                            <td align=""center"" class=""x_sm-px-24"" style=""font-family:'Montserrat',Arial,sans-serif"">
                                <table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""font-family:'Montserrat',Arial,sans-serif; width:100%"">
                                    <tbody>
                                        <tr>
                                            <td class=""x_sm-px-24"" bgcolor=""rgba(255, 255, 255, var(--bg-opacity))"" align=""left"" style=""background-color:#ffffff; border-radius:4px; font-size:14px; line-height:24px; padding:48px; text-align:left; color:#626262"">
                                                <a href=""https://multipropriedades.oskem.com.br/Home/Index"" target=""_blank"" rel=""noopener noreferrer"" data-auth=""NotApplicable"" data-linkindex=""0"">
                                                    <!-- <img data-imagetype=""External"" src=""https://i.ibb.co/7Gtd7ZG/Corretor-Ativa-o-de-Conta.png"" alt=""Ativacao0de-Conta"" border=""0""> -->
                                                    <img data-imagetype=""External"" src=""https://i.ibb.co/YQrMzGr/ativaconta.jpg"" alt=""ativaconta"" border=""0"">


                                                </a> <br aria-hidden=""true""><br aria-hidden=""true"">
                                                <p style=""font-weight:700; font-size:20px; margin-top:0"">
                                                    <span style=""color:#38be3b"">Bem vindo a Oskem!</span>
                                                </p>
                                                <br aria-hidden=""true"">
                                                Olá, @nome 
                                                    <br aria-hidden=""true"">
                                                    <br aria-hidden=""true"">
                                                    <br aria-hidden=""true"">
                                                Que bom ter você conosco! 
                                                    <br aria-hidden=""true"">
                                                Ative a sua conta no link abaixo para aproveitar as maravilhas do mundo dos investimentos imobiliários, de um jeito que só a <b>OSKEM</b> pode oferecer! 
                                                    <br aria-hidden=""true"">
                                                    <br aria-hidden=""true"">
                                                    <br aria-hidden=""true"">
                                                <a href=""https://multipropriedades.oskem.com.br/Login/ConfirmarEmail?c=@link"" target=""_blank"" rel=""noopener noreferrer"" data-auth=""NotApplicable"" data-linkindex=""1"">Ativar minha conta</a> 
                                                    <br aria-hidden=""true"">
                                                    <br aria-hidden=""true"">
                                                <div style=""background-color:#eceff1; height:1px; line-height:1px"">‌</div><table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""font-family:'Montserrat',Arial,sans-serif; width:100%"">
                                                <tbody>
                                                    <tr>
                                                    <td style=""font-family:'Montserrat',Arial,sans-serif; padding-top:32px; padding-bottom:32px"">
                                                    </td>
                                                    </tr>
                                                </tbody>
                                    </table>
                                Obrigado, 
                            <br aria-hidden=""true"">
                            <b>Oskem Engenharia & Consultoria!</b> 
                            </td>
                            </tr>
                            <tr>
                            <td height=""20"" style=""font-family:'Montserrat',Arial,sans-serif; height:20px"">
                            </td>
                            </tr>
                            <tr>
<td height=""16"" style=""font-family:'Montserrat',Arial,sans-serif; height:16px"">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>";
        }

        public static string ContatoEmail()
        {
            return @"<table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%"">
    <tbody>
        <tr>
            <td align=""center"" bgcolor=""rgba(236, 239, 241, var(--bg-opacity))"" style=""background-color:#eceff1"">
                <table class=""x_sm-w-full"" width=""600"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""font-family:'Montserrat',Arial,sans-serif; width:600px"">
                    <tbody>
                        <tr>
                            <td align=""center"" class=""x_sm-px-24"" style=""font-family:'Montserrat',Arial,sans-serif"">
                                <table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""font-family:'Montserrat',Arial,sans-serif; width:100%"">
                                    <tbody>
                                        <tr>
                                            <td class=""x_sm-px-24"" bgcolor=""rgba(255, 255, 255, var(--bg-opacity))"" align=""left"" style=""background-color:#ffffff; border-radius:4px; font-size:14px; line-height:24px; padding:48px; text-align:left; color:#626262"">
                                          
                                                <p style=""font-weight:700; font-size:20px; margin-top:0"">
                                                    <span style=""color:#38be3b"">Novo contato!</span>
                                                </p>
                                                <br aria-hidden=""true"">
                                                Nome: @nome 
                                                    <br aria-hidden=""true"">
                                                Email: @email
                                                    <br aria-hidden=""true"">
                                                Telefone: @telefone
                                                <br aria-hidden=""true"">
                                                Assunto: @assunto
                                                    <br aria-hidden=""true"">
                                                Mensagem: @mensagem
                                                
                                                    <br aria-hidden=""true"">
                                              
                                                <div style=""background-color:#eceff1; height:1px; line-height:1px"">‌</div><table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""font-family:'Montserrat',Arial,sans-serif; width:100%"">
                                                <tbody>
                                                    <tr>
                                                    <td style=""font-family:'Montserrat',Arial,sans-serif; padding-top:32px; padding-bottom:32px"">
                                                    </td>
                                                    </tr>
                                                </tbody>
                                    </table>
                                Obrigado, 
                            <br aria-hidden=""true"">
                            <b>Oskem Engenharia & Consultoria!</b> 
                            </td>
                            </tr>
                            <tr>
                            <td height=""20"" style=""font-family:'Montserrat',Arial,sans-serif; height:20px"">
                            </td>
                            </tr>
                            <tr>
<td height=""16"" style=""font-family:'Montserrat',Arial,sans-serif; height:16px"">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>";
        }
    }
}
