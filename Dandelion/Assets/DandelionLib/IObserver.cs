using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    public interface IObserver
    {
        void Update(object o);
    }
}
