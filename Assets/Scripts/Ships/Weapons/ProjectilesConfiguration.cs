using Assets.Scripts.Ships.Weapons.Projectiles;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Ships.Weapons
{
    [CreateAssetMenu(menuName = "Create ProjectilesConfiguration", fileName = "ProjectilesConfiguration", order = 0)]
    public class ProjectilesConfiguration : ScriptableObject
    {
        [SerializeField] private Projectile[] _projectilePrefabs;
        private Dictionary<string, Projectile> _idToProjectilesPrefab;

        private void Awake()
        {
            _idToProjectilesPrefab = new Dictionary<string, Projectile>();
            foreach(var projectile in _projectilePrefabs)
            {
                _idToProjectilesPrefab.Add(projectile.Id, projectile);
            }
        }

        public Projectile GetProjectile(string id)
        {
            if (!_idToProjectilesPrefab.TryGetValue(id, out var projectile))
            {
                throw new Exception($"Projectile {id} not found.");
            }
            return projectile;
        }
    }
}
