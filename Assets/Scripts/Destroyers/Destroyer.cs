using UnityEngine;

namespace Destroyers
{
    public abstract class Destroyer<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out T obj))
            {
                obj.gameObject.SetActive(false);
            }
        }
    }
}
