using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollCircle : ScrollRect
{

    protected float mRadius;

    protected override void Start()
    {

        this.mRadius = (transform as RectTransform).sizeDelta.x * 0.5f;
    }

    public override void OnDrag(PointerEventData eventData)
    {

        base.OnDrag(eventData);

        Vector2 contentPostion = base.content.anchoredPosition;

        if (contentPostion.magnitude > this.mRadius)
        {

            contentPostion = contentPostion.normalized * this.mRadius;
        }

        base.content.anchoredPosition = contentPostion;
    }
}