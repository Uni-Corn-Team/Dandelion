using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class UserBar : IObserver
    {
        private int _healthBar;
        private int _hightBar;
        private int _maxHealth;

        public void Update(object o)
        {
            throw new NotImplementedException();
        }

        public int HightBar => _hightBar;

        public double HealthBar => _healthBar / (double)_maxHealth;
    }
}
