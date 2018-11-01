using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NuvemERP.Page
{

    public class PessoasPage
    {
        private Dsl dsl;
        string tipoPessoa = "";

        public PessoasPage(IWebDriver driver)
        {
            dsl = new Dsl(driver);
        }

        public void AcessarPagina()
        {
            dsl.ClicarBotao("li.has-sub:nth-child(2) > a:nth-child(1) > span:nth-child(2)");
            Thread.Sleep(2000);
            dsl.ClicarBotao("li.has-sub:nth-child(2) > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1) > span:nth-child(1)");
        }

        public void Cadastrar()
        {
            dsl.ClicarBotao("#OpcInserir");
        }

        /********************INFORMAÇÕES BASICAS**********************/
        #region
        public void SetTipoCadastro(string tipo)
        {
            // voltar a usar lista de string
            dsl.ClicarCheck(tipo);
        }

        public void SetTipoPessoa(string valor)
        {
            tipoPessoa = valor;
            dsl.SelecionarComboBox("#TIPOPESSOA", tipoPessoa);

        }

        public void SetCodigo(string id)
        {
            dsl.Escrever("#CODIGO", id);
        }

        public void SetNome(string nome)
        {
            if(tipoPessoa == "Pessoa Jurídica")
            {
                dsl.Escrever("#RAZAOSOCIAL", nome);
            }
            else
            {
            dsl.Escrever("#NOME", nome);
            }
        }

        public void SetCnpj(string codigo)
        {
            dsl.Escrever("#CNPJ", codigo);
        }

        public void SetCPF(string codigo)
        {
            dsl.Escrever("#CPF", codigo);
        }

        public void SetRg(string codigo)
        {
            dsl.Escrever("#RG", codigo);
        }
        #endregion

        /*********************DADOS FINANCEIROS***********************/
        #region
        public void AcessarDadosFinanceiros()
        {
            dsl.ClicarBotao("div.tabbable:nth-child(1) > ul:nth-child(1) > li:nth-child(2) > a:nth-child(1) > span:nth-child(2)");
        }

        public void SetLimiteCredito(string limite)
        {
            dsl.Escrever("#LIMITECREDITO", limite);
        }
        #endregion

        /*********************IMPOSTO E TRIBUTAÇÃO********************/
        #region
        public void AcessarImpostoETributacao()
        {
            dsl.ClicarBotao("div.tabbable:nth-child(4) > ul:nth-child(1) > li:nth-child(2) > a:nth-child(1) > span:nth-child(2)");
            Thread.Sleep(2000);
        }

        public void SetIE(string codigo)
        {
            dsl.Escrever("#IEESTADUAL", codigo);
        }

        public void SetTipoRegime(string valor = "0 - Simples Nacional")
        {
            dsl.SelecionarComboBox("#TIPOREGIME", valor);
        }

        public void SetTipoIe(string valor = "1 - Contribuinte ICMS")
        {
            dsl.SelecionarComboBox("#TIPO_INSCRICAOESTADUAL", valor);
        }

        public void SetTipoAquisicao(string valor = "2 - Revenda")
        {
            dsl.SelecionarComboBox("#TIPO_AQUISICAO", valor);
        }
        #endregion

        /***********************DADOS DE ENDEREÇO*********************/
        #region

        public void AcessarDadosDeEndereco()
        {
            dsl.ClicarBotao("div.tabbable:nth-child(4) > ul:nth-child(1) > li:nth-child(3) > a:nth-child(1)");
            Thread.Sleep(2000);
        }

        public void SetCep(string codigo = "02957020")
        {
            dsl.Escrever("#CEP", codigo);
        }

        public void SetNumero(string codigo = "85")
        {
            dsl.Escrever("#NUMERO", codigo);
        }
        #endregion

        public void Salvar()
        {
            dsl.ClicarBotao("button.js_update:nth-child(2)");
        }

        
        public void Excluir(string codigo)
        {
            dsl.Escrever("input.form-control:nth-child(1)", codigo);
            dsl.ClicarBotao("tr.gradeA:nth-child(1) > td:nth-child(8) > div:nth-child(1) > button:nth-child(1)");
            dsl.ClicarBotao("div.open > ul:nth-child(2) > li:nth-child(1) > a:nth-child(3)");
            dsl.ClicarBotao("#Excluir");
            
        }


    }
}
