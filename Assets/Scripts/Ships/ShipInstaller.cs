using Assets.Scripts.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useAI;
        [SerializeField] private bool _useJoystick;
        [SerializeField] private ShipMediator _ship;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private JoyButton _joyButton;

        private void Awake()
        {
            _ship.Configure(GetImput(), GetCheckLimitsStrategy());
        }

        private ICheckLimits GetCheckLimitsStrategy()
        {
            if (_useAI)
            {
                return new InitialPositionCheckLimits(_ship.transform, 10f);
            }
            return new ViewportCheckLimits(_ship.transform, Camera.main);
        }

        private IInput GetImput()
        {
            if (_useAI)
            {
                Destroy(_joystick.gameObject);
                Destroy(_joyButton.gameObject);
                return new AIInputAdapter(_ship);
            }

            if (_useJoystick) return new JoystickInputAdapter(_joystick, _joyButton);

            Destroy(_joystick.gameObject);
            Destroy(_joyButton.gameObject);
            return new UnityInputAdapter();
        }
    }
}
