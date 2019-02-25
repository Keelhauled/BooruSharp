﻿namespace BooruSharp.Booru
{
    public class E926 : Booru
    {
        public E926(BooruAuth auth = null) : base("e926.net", auth, UrlFormat.postIndexXml, 750, BooruOptions.wikiSearchUseTitle, BooruOptions.noTagById)
        { }

        public override bool IsSafe()
        {
            return (true);
        }
    }
}
