using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _UI.Scripts.UI.ItemSkinShopButton
{
    public class ButtonHighlight : MonoBehaviour,IPointerDownHandler
    {
        [SerializeField] private Image highlightImage;
        [SerializeField] private Color transparentColor;
        [SerializeField] private Color highlightColor;

        private static Image currentButtonHighlight;
        private void OnEnable()
        {
            highlightImage.color = transparentColor;
        }

        private void OnDisable()
        {
            highlightImage.color = transparentColor;
            currentButtonHighlight = null;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            ResetButtonHighlight();
            highlightImage.color = highlightColor;
            currentButtonHighlight = highlightImage;
        }

        private void ResetButtonHighlight()
        {
            if (currentButtonHighlight is not null)
            {
                currentButtonHighlight.color = transparentColor;
            }
            
        }
    }
}