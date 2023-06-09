﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ships
{
    public class MovementController : MonoBehaviour
    {
        private Vector2 _speed;

        private IShip _ship;
        private Transform _myTransform;
        private ICheckLimits _checkLimits;

        private void Awake()
        {
            _myTransform = transform;
        }

        public void Configure(IShip ship, ICheckLimits checkLimits, Vector2 speed)
        {
            _ship = ship;
            _checkLimits = checkLimits;
            _speed = speed;
        }
        public void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            _checkLimits.ClampFinalPosition();
        }
    }
}
