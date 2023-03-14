using UnityEngine;

namespace Assets.Scripts.Ships
{
    public class ShipFactory
    {
        private readonly ShipsConfiguration _configuration;

        public ShipFactory(ShipsConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IShip Create(string id, Vector3 position, Quaternion rotation)
        {
            var prefab = _configuration.GetShip(id);
            return GameObject.Instantiate(prefab, position, rotation);
        }
    }
}
