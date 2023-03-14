using UnityEngine;

namespace Assets.Scripts.Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private ProjectilesConfiguration _projectilesConfiguration;
        [SerializeField] private Transform _projectileSpawnPosition;
        private float _fireRateInSeconds;
        private float _remainingSecondsToBeAbleToShoot;
        private ProjectileFactory _projectileFactory;

        private string _activeProjectileId;
        private IShip _ship;

        private void Awake()
        {
            var instance = Instantiate(_projectilesConfiguration);
            _projectileFactory = new ProjectileFactory(instance);
        }

        public void Configure(IShip ship, float fireRate, ProjectileId defaultProjectileId)
        {
            _ship = ship;
            _activeProjectileId = defaultProjectileId.Value;
            _fireRateInSeconds = fireRate;

        }

        public void TryShoot()
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
            var projectile = _projectileFactory
               .Create(_activeProjectileId,
                       _projectileSpawnPosition.position,
                       _projectileSpawnPosition.rotation);
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
        }
    }
}
