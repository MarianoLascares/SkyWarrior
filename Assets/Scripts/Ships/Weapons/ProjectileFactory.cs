using Assets.Scripts.Ships.Weapons.Projectiles;
using System;
using UnityEngine;

namespace Assets.Scripts.Ships.Weapons
{
    public class ProjectileFactory
    {
        private readonly ProjectilesConfiguration _configuration;

        public ProjectileFactory(ProjectilesConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Projectile Create(string id, Vector3 position, Quaternion rotation)
        {
            var prefab = _configuration.GetProjectile(id);
            return GameObject.Instantiate(prefab, position, rotation);
        }
    }
}
