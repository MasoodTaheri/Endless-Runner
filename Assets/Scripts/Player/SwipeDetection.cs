using System;
using UnityEngine;

namespace Player
{
    public class SwipeDetection : MonoBehaviour
    {
        public Action OnLeft;
        public Action OnRight;
        [SerializeField] private float swipeThreshold = 50f;
        private Vector2 _startTouchPosition;
        private bool _isSwiping = false;

        void Update()
        {
            DetectSwipe();
        }

        void DetectSwipe()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startTouchPosition = Input.mousePosition;
                _isSwiping = true;
            }

            if (Input.GetMouseButtonUp(0) && _isSwiping)
            {
                Vector2 endTouchPosition = Input.mousePosition;
                Vector2 swipeDelta = endTouchPosition - _startTouchPosition;

                if (swipeDelta.magnitude > swipeThreshold)
                {
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
            OnLeft?.Invoke();
        }

        void OnSwipeRight()
        {
            OnRight?.Invoke();
        }
    }
}