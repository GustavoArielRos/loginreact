using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//importados
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using backend_app.Models;

namespace backend_app.Controllers
{   
    [RoutePrefix("api/Test")]
    //criei uma classe que herda de ApiController
    public class TestController : ApiController
    {   
        //Criando uma conexão com o banco de dados usando a string de conexão definida no web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        //esse cmd vai ser usado para executar comandos sql no VS
        SqlCommand cmd = null;
        //esse da vai ser usado para preencher um DataTable com dados vindo do bd
        SqlDataAdapter da = null;

        //método http que serve para criar
        [HttpPost]
        [Route("Registration")]//caminho da rota (URL)
        public string Registration(Employee employee)
        {   
            //variável que armazenará a variável de retorno
            string msg = string.Empty;
            try
            {   
                //cria um novo comando sql usando o procedimento "usp_Registration" que esta armazenado no banco de dados
                cmd = new SqlCommand("usp_Registration", conn);

                //defininindo que cmd é do tipo "StoreProcedure"(um procedimento armazenado no banco de dados)
                cmd.CommandType = CommandType.StoredProcedure;

                //Adicionando parâmentros no comando sql criado(cdm)
                //esses parâmentros abaixo serão passados para o procedimento "usp_registration"
                //parametro @Name recebe o valor de "employee.Name"( o mesmo esquema nos outros também
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);

                //abrindo a conexão com o banco de dados
                conn.Open();

                //executa o comando SQL "ExecuteNonQuery"(executa comandos que não retornam resultados como INSERT, UPDATE e DELETE)
                // O MÉTODO retorna o numero de linhas afetadas pela execução do comando
                int i = cmd.ExecuteNonQuery();

                //fechando a conexão com o banco de dados
                conn.Close();

                //se for maior que 0 , algo se alterou
                if (i > 0)
                {   
                    //armazena essa mensagem
                    msg = "Data inserted";
                }
                else
                {
                    //armazena essa mensagem
                    msg = "Error";
                }
            }
            catch(Exception ex)
            {   
                //Em caso de exceção, define essa mesagem
                msg = ex.Message;
            }
            
            //retorna a "msg"
            return msg;
        }

        //méotod de criar
        [HttpPost]
        [Route("Login")]//caminho da rota "Login"
        public string Login(Employee employee)
        {   
            //variável para armazenar o que será retornado
            string msg = string.Empty;
            try
            {
                //cria um Adaptador(objeto) usando um procedimento armazenado no banco(usp_Login)
                da = new SqlDataAdapter("usp_Login", conn);

                //Define o comando do Adaptador como procedimento armazenado
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                //Adiciona parâmetros com seus respectivos valores ao comando SQL
                da.SelectCommand.Parameters.AddWithValue("@Name", employee.Name);
                da.SelectCommand.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);

                //Cria um objeto Datatable que armazenará os dados retornados pelo comando SQL
                DataTable dt = new DataTable();

                //o adaptador de dados preenche o Datatable criado com os dados retornados pelo procedimento 'usp_Login'
                da.Fill(dt);

                //verifica se a linhas no datatable(caso houver, significa que mudanças ocorerrão
                if(dt.Rows.Count>0)
                {
                    msg = "User is valid";
                }
                else
                {
                    msg = "User is Invalid";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            //retorna uma string
            return msg;
        }
    }
}
