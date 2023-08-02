using LinkedinJobApplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Helper
{
    public class WordTimerManager
    {
        public static DateTime? GetCurrentDateTime()
        {
            try
            {
                
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync("http://worldtimeapi.org/api/ip").Result;
                    response.EnsureSuccessStatusCode();
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    // Using System.Text.Json to parse JSON
                    using (JsonDocument doc = JsonDocument.Parse(responseBody))
                    {
                        JsonElement root = doc.RootElement;
                        string currentDateTimeStr = root.GetProperty("datetime").GetString();
                        DateTime currentDateTime = DateTime.Parse(currentDateTimeStr);
                        return currentDateTime;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                ExceptionLogger.LogException(ex);
                return null;
            }
        }
    }
}
