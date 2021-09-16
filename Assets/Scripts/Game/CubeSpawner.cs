using UnityEngine;

using Game.Scriptables;

namespace Game
{
    class CubeSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CubeSpawnerData _data;
        [SerializeField] private Transform _spawnPoint;

        public Cube SpawnRandom()
        {
            var randomNumber = _data.NumberGenerator.Generate();
            return Spawn(randomNumber);
        }

        private Cube Spawn(int number)
        {
            var index = _data.NumberGenerator.GetIndex(number);
            var color = _data.Colors.GetColor(index);

            return Spawn(_spawnPoint.position, number, color);
        }
        private Cube Spawn(Vector3 position, int number, Color color)
        {
            var cube = Instantiate(_data.Prefab, position, Quaternion.identity);
            cube.Initialize(number, color);

            _data.SpawnAnimation?.Animate(cube.transform);

            return cube;
        }
    }
}