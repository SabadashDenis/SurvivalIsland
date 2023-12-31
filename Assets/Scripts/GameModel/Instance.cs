using UnityEngine;

namespace GameModel
{
    public abstract class Instance : MonoBehaviour
    {
        protected bool isActive = false;

        protected virtual void Awake()
        {
            Init();
        }
    
        protected virtual void Start()
        {
            Activate(true);
        }

        protected abstract void Init();

        protected virtual void Activate(bool condition)
        {
            isActive = condition;
            gameObject.SetActive(condition);
        }
    }
}
