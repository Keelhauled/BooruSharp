﻿using BooruSharp.Booru;
using System.Net;
using Xunit;

namespace BooruSharp.UnitTests
{
    public class Program
    {
        private void CheckCount(Booru.Booru booru)
        {
            int nbGeneral = booru.GetNbImage();
            int nbMed = booru.GetNbImage("wet");
            int nbMin = booru.GetNbImage("wet", "swimsuit");
            Assert.NotEqual(0, nbMin);
            Assert.InRange(nbMed, nbMin, nbGeneral);
        }

        [Fact]
        public void GelbooruCount()
        {
            CheckCount(new Gelbooru());
        }

        [Fact]
        public void SafebooruCount()
        {
            CheckCount(new Safebooru());
        }

        [Fact]
        public void KonachanCount()
        {
            CheckCount(new Konachan());
        }

        [Fact]
        public void E621Count()
        {
            CheckCount(new E621());
        }

        [Fact]
        public void Rule34Count()
        {
            CheckCount(new Rule34());
        }

        [Fact]
        public void LolibooruCount()
        {
            CheckCount(new Lolibooru());
        }

        [Fact]
        public void YandereCount()
        {
            CheckCount(new Yandere());
        }

        private bool CheckUrl(string url)
        {
            if (url.StartsWith("http://") || url.StartsWith("https://"))
            {
                try
                {
                    WebRequest request = WebRequest.Create(url);
                    request.Method = "HEAD";
                    request.GetResponse();
                    return (true);
                }
                catch (WebException)
                { }
            }
            return (false);
        }

        private void CheckResult(ImageSearch.SearchResult result, string inputTag)
        {
            Assert.True(CheckUrl(result.fileUrl));
            Assert.True(CheckUrl(result.previewUrl));
            Assert.InRange(result.rating, ImageSearch.Rating.Safe, ImageSearch.Rating.Explicit);
            Assert.Contains(inputTag, result.tags);
        }

        private void CheckGetById(Booru.Booru booru)
        {
            ImageSearch.SearchResult result = booru.GetImage(2, "school_swimsuit");
            CheckResult(result, "school_swimsuit");
        }

        [Fact]
        public void GelbooruGetById()
        {
            CheckGetById(new Gelbooru());
        }

        [Fact]
        public void SafebooruGetById()
        {
            CheckGetById(new Safebooru());
        }

        [Fact]
        public void KonachanGetById()
        {
            CheckGetById(new Konachan());
        }

        [Fact]
        public void E621GetById()
        {
            CheckGetById(new E621());
        }

        [Fact]
        public void Rule34GetById()
        {
            CheckGetById(new Rule34());
        }

        [Fact]
        public void LolibooruGetById()
        {
            CheckGetById(new Lolibooru());
        }

        [Fact]
        public void YandereGetById()
        {
            CheckGetById(new Yandere());
        }

        private void CheckGetRandom(Booru.Booru booru)
        {
            ImageSearch.SearchResult result = booru.GetRandomImage("school_swimsuit");
            CheckResult(result, "school_swimsuit");
        }

        [Fact]
        public void GelbooruGetRandom()
        {
            CheckGetRandom(new Gelbooru());
        }

        [Fact]
        public void SafebooruGetRandom()
        {
            CheckGetRandom(new Safebooru());
        }

        [Fact]
        public void KonachanGetRandom()
        {
            CheckGetRandom(new Konachan());
        }

        [Fact]
        public void E621GetRandom()
        {
            CheckGetRandom(new E621());
        }

        [Fact]
        public void Rule34GetRandom()
        {
            CheckGetRandom(new Rule34());
        }

        [Fact]
        public void LolibooruGetRandom()
        {
            CheckGetRandom(new Lolibooru());
        }

        [Fact]
        public void YandereGetRandom()
        {
            CheckGetRandom(new Yandere());
        }

        [Fact]
        public void CustomBooru()
        {
            new Booru.Custom.CustomBooru("furry.booru.org", UrlFormat.indexPhp, null, Booru.Custom.BooruOptions.useHttp);
        }

        [Fact]
        public void CustomBooruNotUrl()
        {
            Assert.Throws<Booru.Custom.InvalidBooru>(delegate() { new Booru.Custom.CustomBooru("AWAWAWAWAWA", UrlFormat.indexPhp); });
        }

        [Fact]
        public void CustomBooruBadUrl()
        {
            Assert.Throws<Booru.Custom.InvalidBooru>(delegate () { new Booru.Custom.CustomBooru("https://zirk.eu", UrlFormat.indexPhp); });
        }
    }
}
