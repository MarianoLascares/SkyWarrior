using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ships.Weapons.Projectiles
{
    //in the factory method it would be an interface
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileId _id;
        public string Id => _id.Value;
    }
}
