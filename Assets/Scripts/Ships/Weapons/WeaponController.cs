using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private ProjectilesConfiguration _projectilesConfiguration;
        [SerializeField] private ProjectileId _defaultProjectileId;
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private Transform _projectileSpawnPosition;
        private float _remainingSecondsToBeAbleToShoot;
        private ProjectileFactory _projectileFactory;

        private string _activeProjectileId;
        private IShip _ship;

        public void Configure(IShip ship)
        {
            _ship = ship;
            _activeProjectileId = _defaultProjectileId.Value;
        }

        private void Awake()
        {
            var instance = Instantiate(_projectilesConfiguration);
            _projectileFactory = new ProjectileFactory(instance);
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
            Projectile prefab = _projectileFactory.Create(_activeProjectileId, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
        }

    }
}
