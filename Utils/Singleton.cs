using UnityEngine;

namespace CWLib
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        [SerializeField] private bool dontDestroyOnLoad = false; 

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)FindAnyObjectByType(typeof(T));

                    if (instance == null)
                    {
                        GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                        instance = obj.GetComponent<T>();
                    }
                }

                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this as T;

            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }

        public void DestroyManager()
        {
            if (instance == this)
            {
                instance = null;
                Destroy(gameObject);
            }
        }
    }
}