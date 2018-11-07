
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NuvemERP.BasePage
{
    public class BasePedidoVendaPage:BasePage
    {
        
        public void AcessarPagina()
        {
            dsl.ClicarBotao("li.has-sub:nth-child(4) > a:nth-child(1) > span:nth-child(2)");
            Thread.Sleep(2000);
            dsl.ClicarBotao("li.has-sub:nth-child(4) > ul:nth-child(2) > li:nth-child(2) > a:nth-child(1) > span:nth-child(1)");
        }

        public void Cadastrar()
        {
            dsl.ClicarBotao("a.js_update");
        }

        public void SetCodigoCliente(string codigo)
        {
            dsl.Escrever("#BUSCA_PESSOAS", codigo);
            dsl.SelecionarOpcao("#BUSCA_PESSOAS");

        }

        public void SetCondicaoPagamento(string valor)
        {
            dsl.SelecionarComboBox("#ID_CONDPAGTO", valor);
        }

        public void SetPagamento(string valor)
        {
            dsl.SelecionarComboBox("#ID_FORMAPAGTOCONTA", valor);
        }

        public void SetContaBancaria(string valor)
        {
            dsl.SelecionarComboBox("#ID_BANCOCONTA", valor);
        }

        public void SetCategoriaFinanceira(string valor)
        {
            dsl.SelecionarComboBox("#ID_CATEGORIACONTA", valor);
        }


        /// na implementação, passar uma string com 5 casas
        public void SetProduto(string codigo, string quantidade)
        {
            dsl.Escrever("#BUSCA_ESTOQUE", codigo);

            if (codigo != string.Empty)
            {
                dsl.SelecionarOpcao("#BUSCA_ESTOQUE");
                Thread.Sleep(2000);
                dsl.Escrever("#ADDQUANTIDADE", quantidade);
                dsl.ClicarBotao("#box-additem > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > button:nth-child(2)");
                Thread.Sleep(2000);
            }

        }

        public void SetRecalcula()
        {
            dsl.ClicarBotao("#Btn_finan");
            dsl.ClicarBotao("#form_FINANCEIRO > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(2) > div:nth-child(3) > div:nth-child(1) > button:nth-child(1)");

        }

        public void Salvar()
        {
            dsl.ClicarBotao("button.js_update");
        }
    }
}
