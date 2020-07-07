using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TestWebZup.Util
{
    public class MetodosGenericos
    {
        public static string GerarNome(int tamanho)
        {
            /**
             * Codigo tirado do site /https://codereview.stackexchange.com/questions/146916/pronounceable-nome-generator
             */
            const string vogal = "aeiou";
            const string consoante = "bcdfghjklmnpqrstvwxyz";

            var rnd = new Random();
            var Nome = new StringBuilder();

            tamanho = tamanho % 2 == 0 ? tamanho : tamanho + 1;

            for (var i = 0; i < tamanho / 2; i++)
            {
                Nome
                    .Append(vogal[rnd.Next(vogal.Length)])
                    .Append(consoante[rnd.Next(consoante.Length)]);
            }

            var SobreNome = new StringBuilder();
            for (var i = 0; i < tamanho / 2; i++)
            {
                SobreNome
                    .Append(vogal[rnd.Next(vogal.Length)])
                    .Append(consoante[rnd.Next(consoante.Length)]);
            }

            String NomeCompleto = Nome.ToString() + " " + SobreNome.ToString();

            return NomeCompleto;
        }

        public static string GerarEmail(string nome)
        {
            Random random = new Random();
            string email = nome.Replace(" ", "") + random.Next(1, 9999) + "@teste.com";

            StringBuilder stringAuxiliar = new StringBuilder();
            var arrayText = email.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    stringAuxiliar.Append(letter);
            }
            return stringAuxiliar.ToString().ToLower();
        }

        public static string GerarTelefone(string tipoTelefone)
        {
            var random = new Random();
            string telefone;

            if (tipoTelefone == "Celular")
            {

                telefone = random.Next(10000000, 99999999).ToString();
                telefone = "319" + telefone;
            }
            else if (tipoTelefone == "Fixo")
            {
                telefone = random.Next(1000000, 9999999).ToString();
                telefone = "313" + telefone;
            }
            else
            {
                telefone = "31" + random.Next(900000000, 999999999).ToString();
            }

            return telefone;
        }

        public static string GerarCpf()
        {
            var random = new Random();
            string semente;

            do
            {
                semente = random.Next(1, 999999999).ToString().PadLeft(9, '0');
            }
            while (
                   semente == "000000000"
                || semente == "111111111"
                || semente == "222222222"
                || semente == "333333333"
                || semente == "444444444"
                || semente == "555555555"
                || semente == "666666666"
                || semente == "777777777"
                || semente == "888888888"
                || semente == "999999999"
            );

            semente += CalcularDigitoVerificador(semente).ToString();
            semente += CalcularDigitoVerificador(semente).ToString();
            return semente;
        }

        public static int CalcularDigitoVerificador(string semente)
        {
            int soma = 0;
            int resto = 0;
            int[] multiplicadores = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int iFinal = multiplicadores.Count();
            var iInicial = iFinal - semente.Count();

            for (int i = iInicial; i < iFinal; i++)
            {
                soma += int.Parse(semente[i - iInicial].ToString()) * multiplicadores[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            return resto;
        }

        public bool VerificarTextoTela(IWebElement elemento, string msg)
        {
            /// <summary>
            /// Metodo criado para verificar se há uma frase/texto presente na tela
            /// </summary>

            bool textoIgual = false;

            if (elemento.Displayed)
            {
                string texto = elemento.Text;

                if (texto.Contains(msg))
                {
                    return textoIgual = true;
                }
                return textoIgual;
            }
            else
            {
                return textoIgual;
            }
        }
        
    }
}
