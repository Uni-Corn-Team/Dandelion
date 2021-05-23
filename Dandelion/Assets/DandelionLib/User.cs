using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    public class User : ICanColideWithEntity, IObservable
    {
        private int _currentHealth;
        private int _currentHight;
        private int _maxHealth;

        public int CureentHealth => _currentHealth;

        public User(int maxHealth, int currentHealth)
        {
            _currentHealth = currentHealth;
            _maxHealth = maxHealth;
        }

        public List<IObserver> Observers { get; } = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void ChangeHealth(int val)
        {
            _currentHealth += val;

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
                NotifyObservers(
                    new UserNotifyObserversContract
                    {
                        CurrentHealth = _currentHealth,
                        CurrentHight = _currentHight,
                        MaxHealth = _maxHealth
                    }
                    );
            }

            if (_currentHealth <= 0)
            {
                NotifyObservers(
                    new UserNotifyObserversContract
                    {
                        CurrentHealth = _currentHealth,
                        CurrentHight = _currentHight,
                        MaxHealth = _maxHealth
                    }
                    );
            }
        }

        public void DeleteObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void NotifyObservers(object o)
        {
            foreach(var observer in Observers)
            {
                observer.Update(o);
            }
        }
    }
}
