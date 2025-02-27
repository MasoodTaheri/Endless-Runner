using System;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float swipeThreshold = 50f; // Minimum distance for a swipe
    private Vector2 _startTouchPosition; // Mouse position when swipe starts
    private bool _isSwiping = false; // Track if a swipe is in progress
    public Action OnLeft;
    public Action OnRight;

    void Update()
    {
        DetectSwipe();
    }

    void DetectSwipe()
    {
        // Swipe starts when the mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            _startTouchPosition = Input.mousePosition;
            _isSwiping = true;
        }

        // Swipe ends when the mouse button is released
        if (Input.GetMouseButtonUp(0) && _isSwiping)
        {
            Vector2 endTouchPosition = Input.mousePosition;
            Vector2 swipeDelta = endTouchPosition - _startTouchPosition;

            // Check if the swipe distance is greater than the threshold
            if (swipeDelta.magnitude > swipeThreshold)
            {
                // Determine swipe direction
                if (swipeDelta.x > 0)
                {
                    OnSwipeRight();
                }
                else if (swipeDelta.x < 0)
                {
                    OnSwipeLeft();
                }
            }

            _isSwiping = false;
        }
    }

    void OnSwipeLeft()
    {
        Debug.Log("Swiped Left");
        // Call your lane-switching logic here
        OnLeft?.Invoke();
    }

    void OnSwipeRight()
    {
        Debug.Log("Swiped Right");
        // Call your lane-switching logic here
        OnRight?.Invoke();
    }
}