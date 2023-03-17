using System;
using UnityEngine;
using Utils.FactoryTool;

namespace Level.Views
{
    public class PlayerView : PoolableMonoBehaviour
    {
        [SerializeField] private LevelConfig _config;
        [SerializeField] private Transform _shootPoint;
        public Transform shootPoint => _shootPoint;

        public bool isCast { get; private set; }
        public bool isDoubleCast { get; private set; }

        public event Action onCasted;
        
        private float _rotX;
        private float _rotY;
        private float _currentRotX;
        private float _currentRotY;
        private float _velocityX;
        private float _velocityY;

        private float _castTime = 2.0f;
        
        public void CastSkill()
        {
            if (isCast) CastSecondSkill();
            else isCast = true;
        }

        private void CastSecondSkill()
        {
            isDoubleCast = true;
            _castTime += 1.0f;
        }

        private void RefreshCast()
        {
            isDoubleCast = false;
            isCast = false;
            _castTime = 2.0f;
        }

        private void Follow()
        {
            _rotX += Input.GetAxis("Mouse Y") * _config.cameraSensitivity;
            _rotY += Input.GetAxis("Mouse X") * _config.cameraSensitivity;;
            _rotX = Mathf.Clamp(_rotX, _config.cameraVerticalMin, _config.cameraVerticalMax);
            _currentRotX = Mathf.SmoothDamp(_currentRotX, _rotX, 
                ref _velocityX, _config.cameraSmooth);
        
            _currentRotY = Mathf.SmoothDamp(_currentRotY, _rotY,
                ref _velocityY, _config.cameraSmooth);
        
            transform.rotation = Quaternion.Euler(-_rotX, _rotY, 0.0f);
        }
        private void Update()
        {
            Follow();
            
            if (isCast)
            {
                _castTime -= Time.deltaTime;;
                if (_castTime <= 0.0f)
                {
                    RefreshCast();
                    onCasted?.Invoke();
                }
            }
        }
        
    }
}