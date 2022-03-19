using System;
using System.Threading.Tasks;
using UnityEngine;

namespace CubeEssence
{
    public class Pusher
    {
        public event Func<Task> OnEnd;

        private float _speed;
        private Transform _transform;
        private Vector3 _startPos;
        private Vector3 _endPos;
        private float _interpolateAmount;
        private Vector3 direction;

        public Pusher(Transform transform, Vector3 endPos, float speed)
        {
            _speed = speed;
            _transform = transform;
            _startPos = transform.position;
            _endPos = endPos;
            direction = (_endPos - _startPos).normalized;
        }

        public void UpdateSpeed(float speed)
        {
            _speed = speed;
        }

        public void UpdateDistance(float distance)
        {
            var vector = direction * distance;
            _endPos = _startPos + vector;
        }

        public void Reset()
        {
            _transform.position = _startPos;
        }
        
        public async Task Push()
        {
            while (_interpolateAmount <= 1)
            {
                if(_transform == null) return;
                _interpolateAmount = (_interpolateAmount + Time.deltaTime * _speed);
                _transform.position = Vector3.Lerp(_startPos, _endPos, _interpolateAmount);
                await Task.Yield();
            }
            _interpolateAmount = 0;
            OnEnd?.Invoke();
        }
        
    }
}