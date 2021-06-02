using System.Collections.Generic;

namespace DandelionLib
{
    interface IObservable
    {
        List<IObserver> Observers { get; }

        void AddObserver(IObserver observer);
        void DeleteObserver(IObserver observer);
        void NotifyObservers(object o);
    }
}
