using UnityEngine;

namespace CWLib
{
    public class UIBase : MonoBehaviour
    {
        protected RectTransform rect;

        protected virtual void Awake()
        {
            rect = GetComponent<RectTransform>();
            rect.localScale = Vector3.one;

            var canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                transform.SetParent(canvas.transform, false);
            }
        }
    }
}