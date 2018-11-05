using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace NuvemERP
{
    public class Utils
    {
        public static String Versao(string nomeVersao)
        {
            string versao = ConfigurationManager.AppSettings[nomeVersao].ToString();

            return versao;
        }
    }
}
