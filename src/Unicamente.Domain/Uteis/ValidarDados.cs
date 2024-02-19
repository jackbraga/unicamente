using System.Globalization;
using System.Text.RegularExpressions;

namespace Unicamente.Repository.Uteis
{
    public class ValidarDados
    {
        /// <summary>
        /// Metodo para validar CNPJ
        /// </summary>
        /// <param name="cnpj">Numero do CNPJ com ou sem mascara</param>
        /// <returns>Retorna se o CNPJ e valido</returns>
        public bool CNPJ(string cnpj)
        {
            bool cnpjValido;
            int[] num = new int[14];
            int soma;
            int resultado1;
            int resultado2;
            try
            {
                cnpj = cnpj.Replace(".", "");
                cnpj = cnpj.Replace("-", "");
                cnpj = cnpj.Replace("/", "");
                if (Inteiro(cnpj) == true & cnpj.Length == 14)
                {
                    for (int i = 0; i < num.Length; i++)
                    {
                        num[i] = Convert.ToInt32(cnpj.Substring(i, 1));
                    }
                    soma = num[0] * 5 + num[1] * 4 + num[2] * 3 + num[3] * 2 + num[4] * 9 + num[5] * 8 + num[6] * 7 + num[7] * 6 + num[8] * 5 + num[9] * 4 + num[10] * 3 + num[11] * 2;
                    soma = soma - (11 * ((int)(soma / 11)));
                    if (soma == 0 | soma == 1)
                    {
                        resultado1 = 0;
                    }
                    else
                    {
                        resultado1 = 11 - soma;
                    }
                    if (resultado1 == num[12])
                    {
                        soma = num[0] * 6 + num[1] * 5 + num[2] * 4 + num[3] * 3 + num[4] * 2 + num[5] * 9 + num[6] * 8 + num[7] * 7 + num[8] * 6 + num[9] * 5 + num[10] * 4 + num[11] * 3 + num[12] * 2;
                        soma = soma - (11 * ((int)(soma / 11)));
                        if (soma == 0 | soma == 1)
                        {
                            resultado2 = 0;
                        }

                        else
                        {
                            resultado2 = 11 - soma;
                        }

                        if (resultado2 == num[13])
                        {
                            if (cnpj == "11111111111111" | cnpj == "22222222222222" | cnpj == "33333333333333" | cnpj == "44444444444444" | cnpj == "55555555555555" | cnpj == "66666666666666" | cnpj == "77777777777777" | cnpj == "88888888888888" | cnpj == "99999999999999" | cnpj == "00000000000000")
                            {
                                cnpjValido = false;
                            }
                            else
                            {
                                cnpjValido = true;
                            }
                        }
                        else
                        {
                            cnpjValido = false;
                        }

                    }
                    else
                    {
                        cnpjValido = false;
                    }
                }
                else
                {
                    cnpjValido = false;
                }
            }
            catch (Exception)
            {
                cnpjValido = false;
            }
            return cnpjValido;
        }

        /// <summary>
        /// Metodo para validar CPF
        /// </summary>
        /// <param name="cpf">Numero do CPF com ou sem mascara</param>
        /// <returns>Retorna se o CPF e valido</returns>
        public bool CPF(string cpf)
        {
            try
            {
                cpf = cpf.Replace(".", "");
                cpf = cpf.Replace("-", "");
                int[] num = new int[11];
                int soma;
                int i;
                int resultado1;
                int resultado2;
                if (Inteiro(cpf) == true & cpf.Length == 11)
                {
                    for (i = 0; i <= num.Length - 1; i++)
                    {
                        num[i] = Convert.ToInt32(cpf.Substring(i, 1));
                    }
                    soma = num[0] * 10 + num[1] * 9 + num[2] * 8 + num[3] * 7 + num[4] * 6 + num[5] * 5 + num[6] * 4 + num[7] * 3 + num[8] * 2;
                    soma = soma - (11 * ((int)(soma / 11)));
                    if (soma == 0 | soma == 1)
                    {
                        resultado1 = 0;
                    }
                    else
                    {
                        resultado1 = 11 - soma;
                    }
                    if (resultado1 == num[9])
                    {
                        soma = num[0] * 11 + num[1] * 10 + num[2] * 9 + num[3] * 8 + num[4] * 7 + num[5] * 6 + num[6] * 5 + num[7] * 4 + num[8] * 3 + num[9] * 2;
                        soma = soma - (11 * ((int)(soma / 11)));
                        if (soma == 0 | soma == 1)
                        {
                            resultado2 = 0;
                        }
                        else
                        {
                            resultado2 = 11 - soma;
                        }
                        if (resultado2 == num[10])
                        {
                            if (cpf == "11111111111" | cpf == "22222222222" | cpf == "33333333333" | cpf == "44444444444" | cpf == "55555555555" | cpf == "66666666666" | cpf == "77777777777" | cpf == "88888888888" | cpf == "99999999999" | cpf == "00000000000")
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo para validar RG
        /// </summary>
        /// <param name="rg">Numero do RG com ou sem mascara</param>
        /// <returns>Retorna se o RG e valido</returns>
        public bool RG(string rg)
        {
            bool rgValido;
            rg = rg.Replace(".", "");
            rg = rg.Replace("-", "");
            rg = rg.Replace(" ", "");
            rg = rg.Replace("_", "");
            rg = rg.Replace("x", "10");
            rg = rg.Replace("X", "10");
            rgValido = (Inteiro(rg) | rg.Length > 4);
            return rgValido;
        }

        /// <summary>
        /// Metodo para validar Email
        /// </summary>
        /// <param name="email">Email completo</param>
        /// <returns>Retorna se o Email e valido</returns>
        public bool Email(string email)
        {
            email = email.Replace("ç", "c").Replace("Ç", "c");
            bool emailValido;
            Regex rgeEmailNova = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            Regex rgeEmail1 = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            Regex rgeEmail = new Regex(@"^([A-Za-z0-9]+)?([A-Za-z0-9_\.-]+)@([\dA-Za-z\.-]+)\.([A-Za-z\.]{2,6})$");

            emailValido = rgeEmailNova.IsMatch(email);
            return emailValido;
        }

        /// <summary>
        /// Metodo para validar Telefone Fixo ou Movel
        /// </summary>
        /// <param name="telefone">Telefone Fixo ou Movel com 11 Ex.: 11 9999 9999</param>
        /// <returns>Retorna se o Telefone e valido</returns>
        public bool Telefone(string telefone)
        {
            bool telefoneValido;
            telefone = telefone.Replace(".", "");
            telefone = telefone.Replace("-", "");
            telefone = telefone.Replace(" ", "");
            telefone = telefone.Replace("_", "");
            telefone = telefone.Replace("(", "");
            telefone = telefone.Replace(")", "");
            if (Inteiro(telefone) == true)
            {
                if (telefone.Length == 10 | telefone.Length == 11)
                {
                    telefoneValido = true;
                }
                else
                {
                    telefoneValido = false;
                }
            }
            else
            {
                telefoneValido = false;
            }
            return telefoneValido;
        }

        /// <summary>
        /// Metodo para validar CEP
        /// </summary>
        /// <param name="cep">Numero do CEP com ou sem mascara</param>
        /// <returns>Retorna se o CEP e valido</returns>
        public bool CEP(string cep)
        {
            bool cepValido;
            try
            {
                cep = cep.Replace(".", "");
                cep = cep.Replace("-", "");
                cep = cep.Replace(" ", "");
                cep = cep.Replace("_", "");
                if (Inteiro(cep) == true)
                {
                    if (cep.Length == 8)
                    {
                        cepValido = true;
                    }
                    else
                    {
                        cepValido = false;
                    }
                }
                else
                {
                    cepValido = false;
                }
            }
            catch (Exception)
            {
                cepValido = false;
            }
            return cepValido;
        }

        /// <summary>
        /// Metodo para validar Data
        /// </summary>
        /// <param name="data">Data no formato dd/MM/yyyy</param>
        /// <returns>Retorna se a Data e valida</returns>
        public bool Data(string data)
        {
            bool dataValida;
            DateTime dataDateTime;
            dataValida = DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataDateTime);
            return dataValida;
        }

        /// <summary>
        /// Metodo para validar Data verificar se a idade e valida
        /// </summary>
        /// <param name="data">Data no formato dd/MM/yyyy</param>
        /// <returns>Retorna se a Data de Nascimento e valida</returns>
        public  bool DataNascimento(string data, int idadeMaxima, int idadeMinima)
        {
            bool dataValida;
            DateTime dataDateTime;
            DateTime dataDateTimeAtual = DateTime.Now;
            DateTime dataDateTimeMax;
            DateTime dataDateTimeMin;
            dataValida = DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataDateTime);
            if (dataValida == true)
            {
                dataDateTimeMax = dataDateTimeAtual.AddYears(-idadeMaxima);
                dataDateTimeMin = dataDateTimeAtual.AddYears(-idadeMinima);
                if (dataDateTime < dataDateTimeMax | dataDateTime > dataDateTimeMin)
                {
                    dataValida = false;
                }
            }
            else
            {
                dataValida = false;
            }

            return dataValida;
        }

        /// <summary>
        /// Metodo para validar Hora
        /// </summary>
        /// <param name="hora">Hora no formato hh:mm</param>
        /// <returns>Retorna se a Hora e valida</returns>
        public bool Hora(string hora)
        {
            bool horaValida;
            DateTime horaDateTime;
            horaValida = DateTime.TryParseExact(hora, "hh:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out horaDateTime);
            return horaValida;
        }

        /// <summary>
        /// Metodo para validar Real
        /// </summary>
        /// <param name="real">Real no formato 999,99 ou 999.99</param>
        /// <returns>Retorna se o Real e valido</returns>
        public bool Real(string real)
        {
            bool realValido;
            decimal realDecimal;
            real = real.Replace(".", "");
            real = real.Replace(",", ".");
            realValido = decimal.TryParse(real, out realDecimal);
            return realValido;
        }

        /// <summary>
        /// Metodo para validar Inteiro
        /// </summary>
        /// <param name="inteiro">String contendo um inteiro</param>
        /// <returns>Retorna se o Valor Inteiro e valido</returns>
        public bool Inteiro(string inteiro)
        {
            bool inteiroValido;
            Int64 inteiroInt;
            inteiroValido = Int64.TryParse(inteiro, out inteiroInt);
            return inteiroValido;
        }

        /// <summary>
        /// Metodo para validar Inteiro
        /// </summary>
        /// <param name="inteiro">String contendo um inteiro</param>
        /// <returns>Retorna se o Valor Inteiro e valido</returns>
        public bool Inteiro32Bits(string inteiro)
        {
            bool inteiroValido;
            Int32 inteiroInt;
            inteiroValido = Int32.TryParse(inteiro, out inteiroInt);
            return inteiroValido;
        }

        /// <summary>
        /// Metodo para validar se todos os caracteres são números
        /// </summary>
        /// <param name="usuario">String contendo os números</param>
        /// <returns>Retorna se os dígitos são validos</returns>
        public bool Numeros(string texto)
        {
            bool textoValido;
            Regex rgeTexto = new Regex(@"^[0-9]+$");
            textoValido = rgeTexto.IsMatch(texto);
            return textoValido;
        }

        /// <summary>
        /// Metodo para validar Upload de Arquivo
        /// </summary>
        /// <param name="fileUp">FileUpload contendo o arquivo</param>
        /// <param name="listaExtencao">Lista de String contendo os formatos validos</param>
        /// <param name="tamanhoMaximo">Tamanho em Kb máximo que o arquivo pode conter</param>
        /// <returns>Retorna se o Arquivo e valido</returns>
        //public bool Upload(FileUpload fileUp, List<string> listaExtencao, int tamanhoMaximo)
        //{
        //    string extencaoArquivo;
        //    int tamanhoArquivo;
        //    bool uploadValido;
        //    tamanhoArquivo = fileUp.FileBytes.Length;
        //    extencaoArquivo = System.IO.Path.GetExtension(HttpUtility.HtmlEncode(fileUp.FileName));
        //    uploadValido = (listaExtencao.Contains(extencaoArquivo) & tamanhoArquivo < (tamanhoMaximo * 1024));
        //    return uploadValido;
        //}

        /// <summary>
        /// Metodo para validar IPv4
        /// </summary>
        /// <param name="ip">String contendo IPv4 no formato 255.255.255.255</param>
        /// <returns>Retorna se o IPv4 e valido</returns>
        public bool IPv4(string ip)
        {
            bool ipValido;
            Regex rgeIp = new Regex(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            ipValido = rgeIp.IsMatch(ip);
            return ipValido;
        }

        /// <summary>
        /// Metodo para validar Tag HTML
        /// </summary>
        /// <param name="htmlTag">Tag HTML Ex.: >body> </param>
        /// <returns>Retorna se a Tag HTML e valida</returns>
        public bool HtmlTag(string htmlTag)
        {
            bool htmlTagValidado;
            Regex rgeHtmlTag = new Regex(@"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
            htmlTagValidado = rgeHtmlTag.IsMatch(htmlTag);
            return htmlTagValidado;
        }

        /// <summary>
        /// Metodo para validar Nome de Usuario
        /// </summary>
        /// <param name="usuario">Nome do Usuario</param>
        /// <returns>Retorna se o Usuario e valido</returns>
        public bool Usuario(string usuario)
        {
            bool usuarioValido;
            Regex rgeUsuario = new Regex(@"[a-zA-Z][a-zA-Z0-9.\-_]{5,31}");
            usuarioValido = rgeUsuario.IsMatch(usuario);
            return usuarioValido;
        }

        /// <summary>
        /// Metodo para validar Nome
        /// </summary>
        /// <param name="nome">Nome contendo somente letras</param>
        /// <returns>Retorna se o Nome e valido</returns>
        public bool Nome(string nome)
        {
            bool nomeValido;
            Regex rgeNome = new Regex(@"^([a-zA-Z]+(?:\.)?(?: [a-zA-Z]+(?:\.)?)*){3,500}$");
            nome = nome.Trim();
            nomeValido = rgeNome.IsMatch(nome);
            return nomeValido;
        }


        /// <summary>
        /// Metodo para validar Senha
        /// </summary>
        /// <param name="senha">Senha devendo conter ao menos um catacter nao alfabetico</param>
        /// <returns>Retorna se o Senha e valido</returns>
        public bool Senha(string senha)
        {
            int tamanhoMinimo = 8;
            int tamanhoMaximo = 32;
            //int tamanhoMinusculo = 1;
            //int tamanhoMaiusculo = 1;
            int tamanhoNumeros = 1;
            int tamanhoCaracteresEspeciais = 1;

            // Definição de letras minusculas
            //Regex regTamanhoMinusculo = new Regex("[a-z]");

            // Definição de letras minusculas
            //Regex regTamanhoMaiusculo = new Regex("[A-Z]");

            // Definição de letras minusculas
            Regex regTamanhoNumeros = new Regex("[0-9]");

            // Definição de letras minusculas
            Regex regCaracteresEspeciais = new Regex("[^a-zA-Z0-9]");

            // Verificando tamanho minimo
            if (senha.Length < tamanhoMinimo)
                return false;

            // Verificando tamanho máximo
            if (senha.Length < tamanhoMaximo)
                return false;


            // Verificando numeros
            if (regTamanhoNumeros.Matches(senha).Count < tamanhoNumeros)
                return false;

            // Verificando os diferentes
            if (regCaracteresEspeciais.Matches(senha).Count < tamanhoCaracteresEspeciais)
                return false;


            return true;


        }
    }
}
