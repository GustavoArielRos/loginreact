using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace backend_app
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web
            //Cria uma nova instacia da classe EnableCorsAttribute
            //essa classe é usada para configurar as regras de CORS para a API
            //* permite todas as origens para fazer a requisição API
            //* permite todos os cabeçalhos
            //* permite todos os métodos HTTP
            EnableCorsAttribute cors = new EnableCorsAttribute("*","*", "*");
            //config --> é o objeto HttpConfiguration
            //estamos permitindo o cors a partir das permissões que definimos
            config.EnableCors(cors);
            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
