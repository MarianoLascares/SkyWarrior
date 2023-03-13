using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ships.Weapons
{
    [CreateAssetMenu(menuName = "Create ProjectileId", fileName = "ProjectileId", order = 0)]
    public class ProjectileId : ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}
