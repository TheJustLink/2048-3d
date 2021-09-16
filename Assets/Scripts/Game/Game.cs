using UnityEngine;

namespace Game
{
    class Game : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CubeSpawner _spawner;
        [SerializeField] private CubeSling _sling;
        [SerializeField] private CubeCombiner _combiner;

        private void Start()
        {
            _sling.Detached += OnCubeDetach;
            _combiner.Combined += OnCubeCombined;

            SpawnNewCube();
        }
        private void OnDisable()
        {
            _sling.Detached -= OnCubeDetach;
            _combiner.Combined -= OnCubeCombined;
        }

        private void OnCubeDetach(Cube cube)
        {
            cube.Collide += OnCubeCollide;

            SpawnNewCube();
        }
        private void SpawnNewCube()
        {
            var cube = _spawner.SpawnRandom();
            _sling.Attach(cube);
        }

        private void OnCubeCollide(Cube cube1, Cube cube2)
        {
            _combiner.Combine(cube1, cube2);

            cube1.Collide -= OnCubeCollide;
            cube2.Collide -= OnCubeCollide;
        }
        private void OnCubeCombined(Cube cube)
        {
            cube.Collide += OnCubeCollide;
        }
    }
}