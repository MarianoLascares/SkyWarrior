using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private Projectile[] _projectilePrefabs;
        [SerializeField] private Transform _projectileSpawnPosition;
        private float _remainingSecondsToBeAbleToShoot;

        private string _activeProjectile;
        private IShip _ship;

        public void Configure(IShip ship)
        {
            _ship = ship;
            _activeProjectile = "Projectile";
        }

        internal void TryShoot()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            if (_remainingSecondsToBeAbleToShoot > 0)
            {
                return;
            }
            Shoot();
        }

        private void Shoot()
        {
            var prefab = _projectilePrefabs.First(projectile => projectile.Id.Equals(_activeProjectile));
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
            Instantiate(prefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }

    }
}
