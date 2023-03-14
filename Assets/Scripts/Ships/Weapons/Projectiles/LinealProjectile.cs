using System.Collections;
using UnityEngine;


namespace Assets.Scripts.Ships.Weapons.Projectiles
{
    public class LinealProjectile : Projectile
    {
        [SerializeField] private float _speed;

        protected override void DoStart()
        {
            _rigidBody2D.velocity = transform.up * _speed;
        }

        protected override void DoMove()
        {
            
        }

        protected override void DoDestroy()
        {
            
        }

    }
}

