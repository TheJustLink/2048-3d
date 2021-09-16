using UnityEngine;

using TMPro;
using System;

namespace Game
{
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(Rigidbody))]
    class Cube : MonoBehaviour
    {
        public event Action<Cube, Cube> Collide;

        public bool IsKinematic { get; private set; }

        public int Number
        {
            get => _number;
            set => UpdateVisualNumber(_number = value);
        }
        private int _number;

        public Color Color
        {
            get => _color;
            set => UpdateVisualColor(_color = value);
        }
        private Color _color;

        [Header("References")]
        [SerializeField] private TextMeshPro[] _textNumbers;

        private Renderer _renderer;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Initialize(int number, Color color)
        {
            Number = number;
            Color = color;
        }

        public void Push(Vector3 direction, float force)
        {
            _rigidbody.AddForce(direction * force, ForceMode.Impulse);
        }
        public void Rotate(Vector3 torque)
        {
            _rigidbody.AddTorque(torque, ForceMode.Impulse);
        }

        public void EnableKinematic()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            IsKinematic = true;
        }
        public void DisableKinematic()
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
            IsKinematic = false;
        }

        private void UpdateVisualColor(Color color)
        {
            _renderer.material.color = color;
        }
        private void UpdateVisualNumber(int number)
        {
            foreach (var textField in _textNumbers)
                textField.text = number.ToString();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Cube cube))
                OnCollideWithCube(cube);
        }
        private void OnCollideWithCube(Cube cube)
        {
            if (cube.IsKinematic) return;

            if (cube.Number == Number)
                OnCollideWithSameNumberCube(cube);
        }
        private void OnCollideWithSameNumberCube(Cube cube)
        {
            Collide?.Invoke(this, cube);
        }
    }
}