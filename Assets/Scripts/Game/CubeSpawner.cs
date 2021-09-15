using UnityEngine;

using Game.Animation;

namespace Game
{
    class CubeSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Cube _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Animator<Transform> _spawnAnimation;

        public Cube Spawn()
        {
            var cube = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            cube.Initialize(8, Color.black);

            _spawnAnimation?.Animate(cube.transform);

            return cube;
        }
    }
}