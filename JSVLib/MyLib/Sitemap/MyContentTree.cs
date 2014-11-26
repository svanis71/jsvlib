using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using N2;
using N2.Web;

namespace MyLib.Sitemap
{
    public static class SitemapFormat
    {
        public const string Text = "text";
        public const string Xml = "xml";
    }

    public static class SitemapHelper
    {
        public static string ToXml(this ContentItem start)
        {
            string content = GetSitemapString(start);
            var hrefIdx = content.IndexOf("href");

            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var sitemap = new XElement(ns + "urlset");

            while (hrefIdx != -1)
            {
                hrefIdx += 6;
                var url = content.Substring(hrefIdx, content.IndexOf("\"", hrefIdx) - hrefIdx);

                XElement urlElem = new XElement(ns + "url",
                                                new XElement(ns + "loc", EscapeUrl(AddProtocolAndHostname(url))),
                                                new XElement(ns + "lastmod",
                                                             DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd")),
                                                new XElement(ns + "changefreq", "monthly"));
                sitemap.Add(urlElem);

                hrefIdx = content.IndexOf("href=\"", hrefIdx + 1);
            }


            var doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                                    sitemap);
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                doc.Save(sw);
            }

            return Regex.Replace(sb.ToString(), "UTF-16", "UTF-8", RegexOptions.IgnoreCase);
        }

        private static string GetSitemapString(ContentItem start)
        {
            return Tree.From(start)
                .Filters(N2.Content.Is.Accessible())
                .ExcludeRoot(false).ToString();
        }

        public static string ToPlainText(this ContentItem start)
        {
            string content = GetSitemapString(start);
            var hrefIdx = content.IndexOf("href");
            var result = new StringBuilder("");
            while (hrefIdx != -1)
            {
                hrefIdx += 6;
                var url = content.Substring(hrefIdx, content.IndexOf("\"", hrefIdx) - hrefIdx);
                result.AppendLine(AddProtocolAndHostname(url));
                hrefIdx = content.IndexOf("href=\"", hrefIdx + 1);
            }

            return result.ToString();
        }

        private static string AddProtocolAndHostname(string url)
        {
            var leftPart = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            return leftPart + url;
        }

        private static string EscapeUrl(string url)
        {
            url.Replace("&", "&amp;");
            url.Replace("<", "&lt;");
            url.Replace(">", "&gt;");
            url.Replace("\"", "&quot;");
            url.Replace("'", "&apos;");
            return url;
        }
    }
}
