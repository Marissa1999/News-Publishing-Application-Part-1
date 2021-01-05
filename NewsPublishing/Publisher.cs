using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublishing
{

    public class Publisher : IObservable<Article>
    {
        public Publisher()
        {
            observers = new List<IObserver<Article>>();
        }

        private List<IObserver<Article>> observers;

        public IDisposable Subscribe(IObserver<Article> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber(observers, observer);
        }


        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Article>> _observers;
            private IObserver<Article> _observer;

            public Unsubscriber(List<IObserver<Article>> observers, IObserver<Article> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }


        public void TrackArticle(Nullable<Article> article)
        {
            foreach (var observer in observers)
            {
                if (!article.HasValue)
                {
                    observer.OnError(new ArticleUnknownException());
                }

                else
                {
                    observer.OnNext(article.Value);
                }
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
            {
                if (observers.Contains(observer))
                {
                    observer.OnCompleted();
                }
            }

            observers.Clear();
        }

    }


    public class ArticleUnknownException : Exception
    {
        internal ArticleUnknownException()
        { }
    }
}
