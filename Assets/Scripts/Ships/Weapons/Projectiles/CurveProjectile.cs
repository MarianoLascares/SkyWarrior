using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Ships.Weapons.Projectiles
{
    public class CurveProjectile : Projectile
    {
        [SerializeField] private Rigidbody2D _rigidBody2D;
        [SerializeField] private float _speed;
        [SerializeField] AnimationCurve _horizontalPosition;

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
            var horizontalPosition = _myTransform.right * _horizontalPosition.Evaluate(_currentTime);
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
