using UI;
using UnityEngine;
using Utils.FactoryTool;

namespace Level.Views
{
    public class EnemyView : PoolableMonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;

        private int _currentHealth = 5353;
        private int _maxHealth = 5354;

        public void InitHealth(LevelCameraView camera)
        {
            _healthBar.Init(camera);
            _healthBar.ChangeHealthBar(_currentHealth, _maxHealth);
        }

        public void TakeDamage(int value)
        {
            _currentHealth -= value;
            _healthBar.ChangeHealthBar(_currentHealth, _maxHealth);
        }
    }
}