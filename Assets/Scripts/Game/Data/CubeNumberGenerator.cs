using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/CubeNumberGenerator")]
    class CubeNumberGenerator : ScriptableObject
    {
        [SerializeField] private int _base = 2;
        [SerializeField] private int _startPower = 1;
        [SerializeField] private int _endPower = 6;

        public int Generate()
        {
            var randomPower = Random.Range(_startPower, _endPower);
            return (int)Mathf.Pow(_base, randomPower);
        }
        public int GetIndex(int number)
        {
            var power = GetPower(number);
            var index = power - 1;

            return index;
        }
        public int GetPower(int number)
        {
            return (int)Mathf.Log(number, _base);
        }
    }
}