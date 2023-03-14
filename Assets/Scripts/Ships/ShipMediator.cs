using Assets.Scripts.Ships;
using Assets.Scripts.Ships.Weapons;
using UnityEngine;


[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(WeaponController))]
public class ShipMediator : MonoBehaviour, IShip
{
    [SerializeField] private MovementController _movementControler;
    [SerializeField] private WeaponController _weaponControler;

    private IInput _input;

    [SerializeField] private ShipId _shipId;
    public string Id => _shipId.Value;

    public void Configure(IInput input, ICheckLimits checkLimits)
    {
        _input = input;
        _movementControler.Configure(this, checkLimits);
        _weaponControler.Configure(this);
    }

    private void Update() 
    { 
        var direction = _input.GetDirection();
        _movementControler.Move(direction);
        TryShoot();
    }

    private void TryShoot()
    {
        if (_input.IsFireActionPressed())
        {
            _weaponControler.TryShoot();
        }
    }
}
