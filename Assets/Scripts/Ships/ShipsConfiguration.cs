using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Ships
{
    [CreateAssetMenu(menuName = "Create ShipsConfiguration", fileName = "ShipsConfiguration", order = 0)]
    public class ShipsConfiguration : ScriptableObject
    {
        [SerializeField] private ShipMediator[] _shipPrefabs;
        private Dictionary<string, ShipMediator> _idToShipPrefab;

        private void Awake()
        {
            _idToShipPrefab = new Dictionary<string, ShipMediator>();
            foreach (var ship in _shipPrefabs)
            {
                _idToShipPrefab.Add(ship.Id, ship);
            }
        }

        public ShipMediator GetShip(string id)
        {
            if (!_idToShipPrefab.TryGetValue(id, out var ship))
            {
                throw new Exception($"Ship {id} not found.");
            }
            return ship;
        }
    }
}
