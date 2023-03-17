using System;
using UnityEngine;
using Utils.FactoryTool;

namespace Level.Views
{
    public class SkillView : PoolableMonoBehaviour
    {
        
        public event Action onEnemyCollision;
        public event Action onMissed;
        
        private float _speed;

        public void Fire(float speed)
        {
            _speed = speed;
        }
        
        public void Refresh()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            _speed = 0.0f;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy")) onEnemyCollision?.Invoke();
        }

        private void Update()
        {
            if (_speed != 0.0f)
            {
                transform.position += transform.forward * _speed * Time.deltaTime;
            }

            if (!(transform.position.x >= 100.0f) && !(transform.position.z >= 100.0f)) return;
            Refresh();
            onMissed?.Invoke();
        }
    }
}