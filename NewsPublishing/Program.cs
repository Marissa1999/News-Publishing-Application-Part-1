using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublishing
{
    class Program
    {
        static void Main(string[] args)
        {

            Publisher provider = new Publisher();
            Reader reader1 = new Reader(1);
            provider.Subscribe(reader1);
            Reader reader2 = new Reader(2);
            provider.Subscribe(reader2);

            Article article1 = new Article("Article-1: this is a news article!");
            provider.TrackArticle(article1);
            reader1.Unsubscribe();
            Article article2 = new Article("Article-2: this is a news article!");
            provider.TrackArticle(article2);
            provider.TrackArticle(null);
            provider.EndTransmission();
        }
    }
}
