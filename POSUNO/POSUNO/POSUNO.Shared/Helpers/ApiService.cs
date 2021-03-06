using Newtonsoft.Json;
using POSUNO.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
                string url = Settings.GetApiUrl();

                HttpClient client = new HttpClient(handler)
                {
                    BaseAddress = new Uri(url) //Conexion a la URL
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
        } //Traer usuario

        public static async Task<Response> GetListAsync<T>(string controller)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                string url = Settings.GetApiUrl();
                HttpClient client = new HttpClient(handler)
                {
                    BaseAddress = new Uri(url)
                };

                HttpResponseMessage response = await client.GetAsync($"api/{controller}");
                string result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                List<T> list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list,
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