using System;

using UnityEngine;

using DG.Tweening;

using Game.Scriptables;
using Game.Extensions;

namespace Game
{
    class CubeCombiner : MonoBehaviour
    {
        public event Action<Cube> Combined;

        [SerializeField] private CubeCombinerData _data;

        public void Combine(Cube cube1, Cube cube2)
        {
            var nextNumber = GetNextNumber(cube1);
            var nextColor = GetNextColor(nextNumber);

            var middlePosition = GetMiddlePosition(cube1, cube2);
            var rotation = GetRotation(cube1);

            cube1.EnableKinematic();
            cube2.EnableKinematic();

            var duration = _data.CombineDuration;

            DOTween.Sequence()
                .Join(cube1.DOMove(middlePosition, duration))
                .Join(cube2.DOMove(middlePosition, duration))
                
                .Join(cube2.DORotate(rotation, duration))
                
                .Join(cube1.DOColor(nextColor, duration))
                .Join(cube2.DOColor(nextColor, duration))
                
                .Join(cube1.DONumber(nextNumber, duration))
                .Join(cube2.DONumber(nextNumber, duration))

                .AppendCallback(() => OnCombined(cube1, cube2));
        }

        private void OnCombined(Cube cube1, Cube cube2)
        {
            cube1.DisableKinematic();
            Destroy(cube2.gameObject);

            Combined?.Invoke(cube1);

            cube1.Push(Vector3.up, _data.PushUpForce);
            cube1.Rotate(UnityEngine.Random.rotation.eulerAngles);
        }

        private Vector3 GetMiddlePosition(Cube cube1, Cube cube2)
        {
            var position1 = cube1.transform.position;
            var position2 = cube2.transform.position;

            var vector = position1 - position2;
            var halfVector = vector / 2f;
            var middlePosition = position2 + halfVector;

            return middlePosition;
        }
        private Vector3 GetRotation(Cube cube)
        {
            return cube.transform.rotation.eulerAngles;
        }
        private Color32 GetNextColor(int number)
        {
            var nextIndex = _data.NumberGenerator.GetIndex(number);
            var nextColor = _data.Colors.GetColor(nextIndex);

            return nextColor;
        }
        private int GetNextNumber(Cube cube)
        {
            return _data.NumberGenerator.GenerateNext(cube.Number);
        }
    }
}