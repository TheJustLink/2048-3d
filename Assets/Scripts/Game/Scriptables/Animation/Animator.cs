using UnityEngine;

namespace Game.Scriptables.Animation
{
    abstract class Animator<T> : ScriptableObject
    {
        public abstract void Animate(T target);
    }
}