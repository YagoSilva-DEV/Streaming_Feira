using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Data.SqlClient;

namespace Streamall.DAL
{
    internal class DataBaseConnectionDAL  
    {
        private readonly IConfiguration _configuration;

        public DataBaseConnectionDAL()
        {
            //Comentarios para os desenvolvedores:
            _configuration = new ConfigurationBuilder()//Instancia a classe ConfigurationBuilder para ler o arquivo appsettings.json
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)//Define o diretório base para a leitura do arquivo appsettings.json
                .AddJsonFile("appsettings.json",//Adiciona o arquivo appsettings.json à configuração
                optional: false,//Define que o arquivo appsettings.json é obrigatório
                reloadOnChange: true//Se o arquivo appsettings.json for alterado, a configuração será recarregada automaticamente
                )//Adiciona o arquivo appsettings.json à configuração
                .Build();//Constrói a configuração
        }

        public SqlConnection Connect()
        {
            return new SqlConnection(_configuration.GetConnectionString("Streamall"));
        }
    }
}
