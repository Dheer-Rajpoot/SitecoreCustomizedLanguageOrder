using Sitecore;
using Sitecore.Caching;
using Sitecore.Data.Items;
using Sitecore.Events;
using System;

namespace SitecoreCustomizedLanguageOrder
{
    public class NotifyLanguageSortOrderChanged
    {
        public void OnItemSortorderChanged(object sender, EventArgs e)
        {
            Item item = Event.ExtractParameter(e, 0) as Item;
            if (item.TemplateID == TemplateIDs.Language)
            {
                foreach (Cache cache in CacheManager.GetAllCaches())
                {
                    if (cache.Name == "LanguageProvider - Languages")
                    {
                        cache.Clear();
                    }
                }
            }
        }
    }
}
