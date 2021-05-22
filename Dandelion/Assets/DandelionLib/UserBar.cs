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
            if(o is UserNotifyObserversContract contract){
                if(contract.CurrentHealth != null)
                {
                    _healthBar = (int)contract.CurrentHealth;
                }
                if (contract.CurrentHight != null)
                {
                    _hightBar = (int)contract.CurrentHight;
                }
                if (contract.MaxHealth != null)
                {
                    _maxHealth = (int)contract.MaxHealth;
                }
            }
        }

        public int HightBar => _hightBar;

        public double HealthBar => _healthBar / (double)_maxHealth;
    }
}
