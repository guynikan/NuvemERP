using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NuvemERP.BasePage
{
    public class BaseProdutoPage:BasePage
    {

        public void AcessarPagina()
        {
            
            dsl.ClicarBotao("li.has-sub:nth-child(3) > a:nth-child(1)");
            Thread.Sleep(2000);
            dsl.ClicarBotao("li.has-sub:nth-child(3) > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1)");
        }

        public void Cadastrar()
        {             
            dsl.ClicarBotao("#OpcInserir");
        }

        /****************DADOS DO PRODUTOS****************/
        #region
        public void SetCodigo(string codigo)
        {
            
            dsl.Escrever("#ITENS_CODIGO", codigo);
        }

        public void SetDescricao(string descricao)
        {
            dsl.Escrever("#ITENS_NOME", descricao);
        }

        public void SetEan(string codigo)
        {
            dsl.Escrever("#ITENS_CODIGOBARRAS", codigo);
        }

        public void SetNcm(string codigo)
        {
            dsl.Escrever("#ITENS_NCM", codigo);
        }
        #endregion
        /*****************ESTOQUE***********************/
        #region
        public void AcessarEstoque()
        {
            dsl.ClicarBotao("div.tabbable:nth-child(3) > ul:nth-child(1) > li:nth-child(3) > a:nth-child(1)");
            
        }

        public void SetEstoqueAtual(string quantidade)
        {
            
            dsl.Escrever("#ITENS_ESTOQUE_INICIAL", quantidade);
        }

        public void SetUnidadeEstoque(string unidade)
        {
            
            dsl.SelecionarComboBox("#ID_UNIDADE", unidade);
        }
        #endregion
        /*******************DADOS FINANCEIROS************/
        #region
        public void AcessarDadosFinanceiros()
        {
            dsl.ClicarBotao("div.tabbable:nth-child(3) > ul:nth-child(1) > li:nth-child(4)");
            
        }
        
        public void SetPrecoVenda(string preco)
        {
            dsl.Escrever("#ITENS_PRECO_VENDA", preco);
        }
        #endregion

        public void Salvar()
        {
            
            dsl.ClicarBotao("button.js_update:nth-child(2)");
        }


        }
}

