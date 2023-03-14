using System;
using UnityEngine;

namespace Assets.Scripts.Ships.Enemies
{
    internal class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private LevelConfiguration _levelConfiguration;
        [SerializeField] private ShipsConfiguration _shipsConfiguration;
        private ShipFactory _shipFactory;

        private float _currentTimeInSeconds;
        private int _currentConfigurationIndex;

        private void Awake()
        {
            _shipFactory = new ShipFactory(Instantiate(_shipsConfiguration));
        }

        private void Update()
        {
            if(_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
            {
                return;
            }

            _currentTimeInSeconds += Time.deltaTime;

            var spawnConfiguration = _levelConfiguration.SpawnConfigurations[_currentConfigurationIndex];
            if(spawnConfiguration.TimeToSpawn > _currentTimeInSeconds) 
            {
                return;
            }
            SpawnShips(spawnConfiguration);
            _currentConfigurationIndex += 1;
        }

        private void SpawnShips(SpawnConfiguration spawnConfiguration)
        {
            for(int i = 0; i < spawnConfiguration.ShipToSpawnConfigurations.Length; i++)
            {
                var shipConfiguration = spawnConfiguration.ShipToSpawnConfigurations[i];
                var spawnPosition = _spawnPositions[i % _spawnPositions.Length];
                var ship = _shipFactory.Create(shipConfiguration.ShipId.Value, spawnPosition.position, spawnPosition.rotation);

                

                ship.Configure(new AIInputAdapter(ship), new InitialPositionCheckLimits(ship.transform, 10f), 
                    shipConfiguration.Speed, shipConfiguration.FireRate, shipConfiguration.DefaultProjectileId);
            }
        }
    }
}
