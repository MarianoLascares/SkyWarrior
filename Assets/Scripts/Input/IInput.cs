using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ships
{
    public interface IInput
    {
        Vector2 GetDirection();
        bool IsFireActionPressed();
    }
}
