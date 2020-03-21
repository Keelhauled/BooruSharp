﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace BooruSharp.Booru
{
    public abstract partial class ABooru
    {
        public async Task<Search.Related.SearchResult[]> GetRelatedAsync(string tag)
        {
            if (relatedUrl == null)
                throw new Search.FeatureUnavailable();
            var content = (JObject)JsonConvert.DeserializeObject(await GetJsonAsync(CreateUrl(relatedUrl, (format == UrlFormat.danbooru ? "query" : "tags") + "=" + tag)));
            var jsons = (JArray)(format == UrlFormat.danbooru ? content["tags"] : content[content.Properties().First().Name]);
            Search.Related.SearchResult[] results = new Search.Related.SearchResult[jsons.Count];
            int i = 0;
            foreach (var json in jsons)
            {
                results[i] = GetRelatedSearchResult(json);
                i++;
            }
            return results;
        }
    }
}
