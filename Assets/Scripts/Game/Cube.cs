using UnityEngine;

using TMPro;

namespace Game
{
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(Rigidbody))]
    class Cube : MonoBehaviour
    {
        public int Number { get; private set; }

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
            SetColor(color);
            SetNumber(number);
        }
        public void Push(float force)
        {
            _rigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
        }
        public void EnableKinematic()
        {
            _rigidbody.constraints =
                  RigidbodyConstraints.FreezePositionY
                & RigidbodyConstraints.FreezePositionZ;
            _rigidbody.freezeRotation = true;
        }
        public void DisableKinematic()
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.freezeRotation = false;
        }

        private void SetColor(Color color)
        {
            _renderer.material.color = color;
        }
        private void SetNumber(int number)
        {
            Number = number;

            foreach (var textField in _textNumbers)
                textField.text = number.ToString();
        }
    }
}