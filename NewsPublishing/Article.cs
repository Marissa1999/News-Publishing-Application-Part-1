using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublishing
{
    public struct Article
    {
        public string ArticleName { get; set; }

        public Article(string article)
        {
            ArticleName = article;
        }

    }
}
