using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(ScrollRect))]
public class VerticalAutoScroller : MonoBehaviour
{ 
    // If you find the range is not slow enough or fast enough adjust below
    [SerializeField][Range(0.001f, 0.5f)] 
    private float           scrollSpeed;
    // Allows the script to trigger user defined events when the scrolling reaches the end
    [SerializeField] 
    private UnityEvent      onScrollComplete;
    private ScrollRect      scrollRect;
    private RectTransform   scrollRectTransform;
    private RectTransform   contentRectTransform;
    private Vector2         updatedPosition;
    private float           stopThreshold = 0.001f;
   

    private void OnEnable()
    {
        scrollRect = gameObject.GetComponent<ScrollRect>();
        scrollRectTransform = gameObject.GetComponent<RectTransform>();
        contentRectTransform = scrollRect.content;
        updatedPosition.x = 0f;
        updatedPosition.y = 1f;
        if (scrollSpeed == 0) {scrollSpeed = 0.001f;}
        // reset the initial position of the content to be scrolled
        scrollRect.normalizedPosition = updatedPosition;
    }

    void Update()
    {   // only scroll if the content is bigger than the scroll area (unity bug - sometimes takes a couple of frames before we have height data.)
        if (contentRectTransform.rect.height > scrollRectTransform.rect.height) 
        { 
            if (scrollRect.normalizedPosition.y > stopThreshold)
            {
                // scrollRect.normalizedPosition.y is a readonly value so load it into updatedPosition
                updatedPosition.y = (scrollRect.normalizedPosition.y - (scrollSpeed * Time.deltaTime));
                // and set them both together
                scrollRect.normalizedPosition = updatedPosition;
            }
            else
            {
                // when the bottom is reached if there are any user events invoke them.
                onScrollComplete.Invoke();
            }
        }
    }
}
