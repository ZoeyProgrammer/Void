using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScrollRectExtensions
{
    public static void ScrollToSegment(this ScrollRect scrollRect, RectTransform segment)
    {
        Canvas.ForceUpdateCanvases();

        scrollRect.content.anchoredPosition =
            (Vector2)scrollRect.transform.InverseTransformPoint(scrollRect.content.position)
            - (Vector2)scrollRect.transform.InverseTransformPoint(segment.position);
    }

    public static void ScrollToTop(this ScrollRect scrollRect)
    {
        scrollRect.normalizedPosition = new Vector2(0, 1);
    }

    public static void ScrollToBottom(this ScrollRect scrollRect)
    {
        scrollRect.normalizedPosition = new Vector2(0, 0);
    }
}
