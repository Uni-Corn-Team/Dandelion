namespace DandelionLib
{
    public class UserBar : IObserver
    {
        private int _healthBar;
        private int _hightBar;
        private int _maxHealth;

        public UserBar()
        {
            _healthBar = 100;
            _maxHealth = 100;
            _hightBar = 0;
        }

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

        public float HealthBarPercents => (float)_healthBar / (float)_maxHealth;

        public int HealthBar => _healthBar;

        public int MaxHealth => _maxHealth;
    }
}
