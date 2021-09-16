using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/CubeSling")]
    class CubeSlingData : ScriptableObject
    {
        public float PushForce => _pushForce;

        [Header("Parameters")]
        [SerializeField] private float _pushForce;
    }
}