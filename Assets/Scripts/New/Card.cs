using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerClickHandler

{
    [SerializeField]
    int card;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.Translate(Vector2.up * 2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.Translate(Vector2.down * 2f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameManager.Instance.SelectCard(card);
        }
    }
}
