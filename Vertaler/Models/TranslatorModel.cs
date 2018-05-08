using Google.Cloud.Translation.V2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vertaler.Models
{
    public class TranslatorModel
    {
        public async Task<IEnumerable<Language>> GetAllLanguagesAsync()
        {
            return null;
        }

        public async Task<string> TranslateAsync(string text, Language sourceLanguage)
        {
            return null;
        }

        public async Task<string> TranslateAsync(string text, Language sourceLanguage, Language targetLanguage)
        {
            return null;
        }
    }
}
