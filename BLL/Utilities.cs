using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace BLL
{
    public static class Utilities
    {
        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }

        public static int intConvertir(string caracteres)
        {
            int auxiliar = 0;
            int.TryParse(caracteres, out auxiliar);
            return auxiliar;
        }

        public static bool ValidarTelefono(string Telefono)
        {
            return Regex.IsMatch(Telefono, @"^[+-]?\d+(\.\d+)?$");
        }

        public static bool ValidarEmail(string EmailAddress)
        {
            return Regex.IsMatch(EmailAddress, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        public static bool ValidarSoloNumero(string Numero)
        {
            return Regex.IsMatch(Numero, @"[0-9]{1,9}(\.[0-9]{0,2})?$");
        }

        public static bool ValidarNomUsuario(string NomUsuario)
        {
            return Regex.IsMatch(NomUsuario, @"[a-zA-ZñÑ\s]{2,50}");
        }
    }
}