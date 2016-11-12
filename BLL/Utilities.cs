﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}