using Sitecore.Collections;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;

namespace SitecoreCustomizedLanguageOrder
{
    public class LanguageSortOrder : Sitecore.Data.SqlServer.SqlServerDataProvider
    {
        public LanguageSortOrder(string connectionString) : base(connectionString) { }

        private class LanguageComparer : IComparer<Language>
        {
            #region IComparer<Language> Members
            LanguageSortOrder provider;
            public LanguageComparer(LanguageSortOrder dataProvider)
            {
                this.provider = dataProvider;

            }
            public int Compare(Language x, Language y)
            {
                return string.Compare(x.CultureInfo.EnglishName, y.CultureInfo.EnglishName);
            }

            #endregion
        }
        
        public override LanguageCollection GetLanguages()
        {           
            Language[] languages = base.GetLanguages().ToArray();           
            Array.Sort(languages, new LanguageComparer(this));
            LanguageCollection result = new LanguageCollection();
            foreach (Language language in languages)
            {
                result.Add(language);
            }
            return result;
        }
    }
}
