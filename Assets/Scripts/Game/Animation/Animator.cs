using UnityEngine;

namespace Game.Animation
{
    abstract class Animator<T> : ScriptableObject
    {
        public abstract void Animate(T target);
    }
}