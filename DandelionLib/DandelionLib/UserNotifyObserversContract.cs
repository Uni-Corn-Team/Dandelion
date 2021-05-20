using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class UserNotifyObserversContract
    {
        public int? CurrentHealth { get; set; }
        public int? CurrentHight { get; set; }
        public int? MaxHealth { get; set; }
    }
}
