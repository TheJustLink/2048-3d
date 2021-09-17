using UnityEngine;

namespace Game.Scriptables
{
    [CreateAssetMenu(menuName = "Game/CubeCombiner")]
    class CubeCombinerData : ScriptableObject
    {
        public CubeNumberGenerator NumberGenerator => _numberGenerator;
        public CubeColors Colors => _colors;
        public float PushUpForce => _pushUpForce;
        public float CombineDuration => _combineDuration;

        [Header("References")]
        [SerializeField] private CubeNumberGenerator _numberGenerator;
        [SerializeField] private CubeColors _colors;
        [Header("Parameters")]
        [SerializeField] private float _pushUpForce;
        [SerializeField] private float _combineDuration;
    }
}