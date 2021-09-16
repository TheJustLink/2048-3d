using UnityEngine;

using Game.Scriptables.Animation;

namespace Game.Scriptables
{
    [CreateAssetMenu(menuName = "Game/CubeSpawner")]
    class CubeSpawnerData : ScriptableObject
    {
        public Cube Prefab => _prefab;
        public Animator<Transform> SpawnAnimation => _spawnAnimation;
        public CubeNumberGenerator NumberGenerator => _numberGenerator;
        public CubeColors Colors => _colors;

        [Header("References")]
        [SerializeField] private Cube _prefab;
        [SerializeField] private Animator<Transform> _spawnAnimation;
        [SerializeField] private CubeNumberGenerator _numberGenerator;
        [SerializeField] private CubeColors _colors;
    }
}