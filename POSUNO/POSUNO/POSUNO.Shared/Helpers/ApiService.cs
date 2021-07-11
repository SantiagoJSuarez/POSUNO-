using Newtonsoft.Json;
using POSUNO.Api.Data.Entities;
using POSUNO.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace POSUNO.Helpers
{
    class ApiService //Metodo que permite leer el API
    {
        public static async Task<Response>  LoginAsync(LoginRequest model)
        {
            try
            {
                string request = JsonConvert.SerializeObject(model); //Convertir a string un Json (Serializacion)
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");

                HttpClientHandler handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };
                HttpClient client = new HttpClient(handler)
                {
                    BaseAddress = new Uri("https://localhost:44326") //Conexion a la URL
                };

                HttpResponseMessage response = await client.PostAsync("api/Account/Login", content); //Post
                string result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                User user = JsonConvert.DeserializeObject<User>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = user
                };


            }
            catch (Exception ex)
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
