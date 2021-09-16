using UnityEngine;

using DG.Tweening;

namespace Game.Extensions
{
    static class CubeExtensions
    {
        public static Tween DOMove(this Cube cube, Vector3 endPosition, float duration)
        {
            return cube.transform.DOMove(endPosition, duration);
        }
        public static Tween DORotate(this Cube cube, Vector3 endRotation, float duration)
        {
            return cube.transform.DORotate(endRotation, duration);
        }
        public static Tween DOColor(this Cube cube, Color endColor, float duration)
        {
            return DOTween.To(() => cube.Color,
                color => cube.Color = color,
                endColor,
                duration
            );
        }
        public static Tween DONumber(this Cube cube, int endNumber, float duration)
        {
            return DOTween.To(() => cube.Number,
                number => cube.Number = number,
                endNumber,
                duration
            );
        }
    }
}