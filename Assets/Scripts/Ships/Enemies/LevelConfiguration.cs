using UnityEngine;


namespace Assets.Scripts.Ships.Enemies
{
    [CreateAssetMenu(menuName = "Create LevelConfiguration", fileName = "LevelConfiguration", order = 0)]
    public class LevelConfiguration : ScriptableObject
    {
        [SerializeField] private SpawnConfiguration[] _spawnConfigurations;

        public SpawnConfiguration[] SpawnConfigurations => _spawnConfigurations;
    }
}
