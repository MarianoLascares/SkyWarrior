using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Ships.Weapons.Projectiles
{
    public class LinealProjectile : Projectile
    {
        
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _speed;

        private void Start()
        {
            _rigidBody.velocity = transform.up * _speed;
            StartCoroutine(DestroyIn(3));
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}
