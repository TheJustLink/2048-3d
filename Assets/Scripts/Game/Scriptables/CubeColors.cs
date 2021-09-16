
using UnityEngine;

namespace Game.Scriptables
{
    [CreateAssetMenu(menuName = "Game/CubeColors")]
    class CubeColors : ScriptableObject
    {
        [Header("Parameters")]
        [SerializeField] private Color32[] _colors;

        public Color32 GetColor(int index)
        {
            var countColors = _colors.Length;

            if (countColors == 0)
                return Color.black;

            if (countColors > index)
                return _colors[index];

            var lastIndex = countColors - 1;
            return _colors[lastIndex];
        }
    }
}