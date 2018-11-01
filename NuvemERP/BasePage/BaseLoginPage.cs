using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemERP.BasePage
{
    public class BaseLoginPage:BasePage
    {

        public void Autentica(string user, string pass)
        {
            dsl.Escrever("#username", user);
            dsl.Escrever("#senha", pass);
            dsl.ClicarBotao("#LOGAR");
        }
    }
}
