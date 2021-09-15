using UnityEngine;

namespace Game
{
    class Game : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CubeSpawner _spawner;
        [SerializeField] private CubeSling _sling;

        private void Start()
        {
            _sling.Detached += OnCubeDetach;
            OnCubeDetach();
        }
        private void OnDisable()
        {
            _sling.Detached -= OnCubeDetach;
        }

        private void OnCubeDetach()
        {
            SpawnCube();
        }
        private void SpawnCube()
        {
            var cube = _spawner.Spawn();
            _sling.Attach(cube);
        }
    }
}