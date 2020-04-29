using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using reCAPTCHAv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace reCAPTCHAv3.Services
{
    public class ReCAPTCHAService
    {
        private readonly ReCAPTCHASettings _settings;

        public ReCAPTCHAService(IOptions<ReCAPTCHASettings> settings)
        {
            _settings = settings.Value;
        }

        public virtual async Task<ReCAPTCHAResponse> VerifyCaptcha(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={_settings.Secret_Key}&response={token}");

                var tokenResponse = JsonConvert.DeserializeObject<ReCAPTCHAResponse>(response);

                return tokenResponse;
            }
        }
         
    }
}
