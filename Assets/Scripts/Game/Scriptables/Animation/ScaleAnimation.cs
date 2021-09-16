using UnityEngine;

using DG.Tweening;

namespace Game.Scriptables.Animation
{
    [CreateAssetMenu(menuName = "Game/Animations/Transform/Scale")]
    class ScaleAnimation : Animator<Transform>
    {
        [Header("Parameters")]
        [SerializeField] private Vector3 _startScale;
        [SerializeField] private Vector3 _targetScale = Vector3.one;
        [SerializeField] private float _duration;

        public override void Animate(Transform target)
        {
            target.localScale = _startScale;
            target.DOScale(_targetScale, _duration);
        }
    }
}