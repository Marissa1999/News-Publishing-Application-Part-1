using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublishing
{

    public class Reader : IObserver<Article>
    {
        public IDisposable unsubscriber;
        public int Number { get; set; }

        public Reader(int n)
        {
            Number = n;
        }

        public virtual void Subscribe(IObservable<Article> provider)
        {
            if (provider != null)
            {
                unsubscriber = provider.Subscribe(this);
            }
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine($"The Article Tracker has completed transmitting to Reader {Number}.");
            this.Unsubscribe();
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnError(Exception error)
        {
            Console.WriteLine($"The article is unknown for Reader {Number}.");
        }

        public virtual void OnNext(Article article)
        {
            Console.WriteLine($"Reader - {Number} has read the news: {article.ArticleName}");
        }

    }
}
