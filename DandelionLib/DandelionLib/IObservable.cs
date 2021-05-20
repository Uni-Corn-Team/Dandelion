using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
