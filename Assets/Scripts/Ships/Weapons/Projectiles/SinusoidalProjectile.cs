using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private Rigidbody2D _rigidBody2D;
        [SerializeField] private float _speed;
        [SerializeField] private float _amplitude;
        [SerializeField] private float _frequency;

        private float _currentTime;
        private Vector3 _currentPosition;
        private Transform _myTransform;

        private void Start()
        {
            _currentTime = 0;
            _myTransform = transform;
            _currentPosition = _myTransform.position;
            StartCoroutine(DestroyIn(3));
        }

        private void FixedUpdate()
        {
            _currentPosition += _myTransform.up * _speed * Time.deltaTime;
            // horizontalPosition = amplitude * sin (x * frequency)
            var horizontalPosition = _myTransform.right * (_amplitude * Mathf.Sin(_currentTime * _frequency));
            _rigidBody2D.MovePosition(_currentPosition + horizontalPosition);

            _currentTime += Time.deltaTime;
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}
