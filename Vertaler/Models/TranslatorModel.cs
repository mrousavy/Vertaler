using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;

namespace Vertaler.Models
{
    public class TranslatorModel
    {
        public IEnumerable<Language> GetAllLanguages()
        {
            var languages = new List<Language>();
            var members = typeof(LanguageCodes).GetMembers();
            foreach (var member in members)
                if (member is FieldInfo fieldInfo)
                {
                    var value = fieldInfo.GetValue(null);
                    languages.Add(new Language(member.Name, value as string));
                }

            return languages;
        }

        public async Task<IEnumerable<Language>> GetAllLanguagesAsync()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "api.json");
            var client = await TranslationClient.CreateAsync();
            return await client.ListLanguagesAsync();
        }

        public async Task<string> TranslateAsync(string text, Language sourceLanguage, Language targetLanguage)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "api.json");
            var client = await TranslationClient.CreateAsync();
            var response = await client.TranslateTextAsync(text, targetLanguage.Code, sourceLanguage.Code);
            return response.TranslatedText;
        }
    }
}