using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ships
{
    internal class InitialPositionCheckLimits : ICheckLimits
    {
        private readonly Transform _transform;
        private readonly Vector3 _initialPosition;
        private readonly float _maxDistance;

        public InitialPositionCheckLimits(Transform transform, float maxDistance)
        {
            _transform = transform;
            _initialPosition = _transform.position;
            _maxDistance = maxDistance;
        }

        public void ClampFinalPosition()
        {
            var currentPosition = _transform.position;
            var distance = Mathf.Abs(currentPosition.x - _initialPosition.x);
            var finalPosition = currentPosition;

            if (distance < _maxDistance)
                return;
            
            if(currentPosition.x > _initialPosition.x)
            {
                finalPosition.x = _initialPosition.x + _maxDistance;
            }
            else
            {
                finalPosition.x = _initialPosition.x - _maxDistance;
            }
            _transform.position = finalPosition;
            
        }
    }
}
