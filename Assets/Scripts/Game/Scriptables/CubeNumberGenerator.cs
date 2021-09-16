using UnityEngine;

namespace Game.Scriptables
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
            return GetNumber(randomPower);
        }
        public int GenerateNext(int number)
        {
            var power = GetNextPower(number);
            return GetNumber(power);
        }

        public int GetIndex(int number)
        {
            var power = GetPower(number);
            var index = power - 1;

            return index;
        }
        public int GetNextPower(int number)
        {
            return GetPower(number) + 1;
        }
        public int GetPower(int number)
        {
            return (int)Mathf.Log(number, _base);
        }
        public int GetNumber(int power)
        {
            return (int)Mathf.Pow(_base, power);
        }
    }
}