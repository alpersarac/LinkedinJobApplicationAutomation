using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJAASerialGenerator
{
    public class KeyGenerator
    {
        public string GenerateKey(string emailAddress, TimeSpan duration)
        {
            string emailPart = emailAddress.Replace("@", "").Replace(".", "");
            string datePart = DateTime.UtcNow.AddDays(duration.Days).ToString("yyyyMMdd");
            Guid guid = Guid.NewGuid();

            string uniqueKey = $"{emailPart}_{datePart}_{guid}";

            return uniqueKey;
        }
    }
}
