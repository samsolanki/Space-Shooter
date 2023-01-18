using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameoverPenalAnimation : MonoBehaviour
{
    public float timer = 1;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;
    
    public void FadeInAnimation()
    {
        canvasGroup.alpha = 0;
        rectTransform.transform.localPosition = new Vector3(0, -1000, 0);
        rectTransform.DOAnchorPos(new Vector2(0, 0), timer, false).SetEase(Ease.InBack);
        canvasGroup.DOFade(1, timer);
    }

    public void FadeOutAnimation()
    {
        canvasGroup.alpha = 1;
        rectTransform.transform.localPosition = new Vector3(0, -00, 0);
        rectTransform.DOAnchorPos(new Vector2(0, -1000), timer, false).SetEase(Ease.InBack);
        canvasGroup.DOFade(0, timer);
    }

}
