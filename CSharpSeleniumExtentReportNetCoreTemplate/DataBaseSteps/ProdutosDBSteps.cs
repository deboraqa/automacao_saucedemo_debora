using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps
{
    public class ProdutosDBSteps
    {
        public static List<string> RetornaProduto(string idProduto)
        {
            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries\ConsultarProdutos.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{idProduto}", idProduto);

            return DataBaseHelpers.RetornaDadosQuery(query);
        }
    }
}
