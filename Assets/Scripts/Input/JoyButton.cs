using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Input
{
    public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public bool isPressed { get; private set; }
        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressed= false;
        }
    }
}
