using System;

using UnityEngine;

using Game.Data;
using Game.Input;

namespace Game
{
    class CubeSling : MonoBehaviour
    {
        public event Action Detached;

        [SerializeField] private CubeSlingData _data;

        private Cube _cube;
        private Transform _cubeTransform;
        private DragTouchInput _touchInput;

        public void Update()
        {
            _touchInput?.Update();
        }

        public void Attach(Cube cube)
        {
            _cube = cube;
            _cubeTransform = cube.transform;
            _cube.EnableKinematic();

            _touchInput = new DragTouchInput(_cubeTransform);
            _touchInput.Drag += OnDragCube;
            _touchInput.EndDrag += OnEndDragCube;
        }
        private void Detach()
        {
            _touchInput.EndDrag -= OnEndDragCube;
            _touchInput.Drag -= OnDragCube;
            _touchInput = null;

            _cube.DisableKinematic();
            _cube.Push(_data.PushForce);
            _cube = null;

            Detached?.Invoke();
        }

        private void OnDragCube(Vector3 position)
        {
            var oldPosition = _cubeTransform.position;
            var newPosition = new Vector3(position.x, oldPosition.y, oldPosition.z);

            _cubeTransform.position = newPosition;
        }
        private void OnEndDragCube()
        {
            Detach();
        }
    }
}