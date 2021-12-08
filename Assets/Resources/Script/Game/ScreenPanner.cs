using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenPanner : TouchResponse
{
    float speed = 0.5f;

    [SerializeField] private Camera gameCamera = null;
    [SerializeField] private SpriteRenderer sizeTracker;
    private float leftBound = -1.8f;
    private float rightBound = 1.8f;
    private float topBound = 0.2f;
    private float bottomBound = -0.2f;

    private bool ratioChecked = false;

    public bool checkAspectRatio()
    {
        Debug.Log(gameCamera.aspect);

        if (ratioChecked == true)
            return true;

        if (gameCamera == null)
            return false;

        if (gameCamera.aspect == 0.75f)
            Debug.Log("3:4");
        else if (gameCamera.aspect == 0.5625f)
            Debug.Log("9:16");
        else if (gameCamera.aspect <= 0.5)
        {
            leftBound = -2.4f;
            rightBound = 2.4f;
            topBound = 0.3f;
            bottomBound = -0.3f;
        }
        ratioChecked = true;

        return ratioChecked;
    }

    public void Update()
    {
        if (checkAspectRatio() == false)
            return;

        if (Input.touchCount <= 0)
            return;

        if (Input.touches.Any(x => x.phase == TouchPhase.Moved))
        {
            Touch touch = Input.touches.First(x => x.phase == TouchPhase.Moved);

            Vector3 oldPosition = gameCamera.transform.position;
            Vector3 newPosition = new Vector3(oldPosition.x - touch.deltaPosition.x * speed,
                oldPosition.y - touch.deltaPosition.y * speed,
                oldPosition.z);

            Vector3 movePosition = Vector3.Lerp(oldPosition, newPosition, Time.deltaTime);

            if (allowMove(movePosition))
                gameCamera.transform.position = movePosition;
        }
    }

    public bool allowMove(Vector3 movePosition)
    {
        return rightBound > movePosition.x && leftBound < movePosition.x &&
            topBound > movePosition.y && bottomBound < movePosition.y;
    }
}

public class TouchResponse : MonoBehaviour
{
    public void TouchInput(Touch touch)
    {
        if (touch.phase == TouchPhase.Moved)
        {
            OnDrag(touch);
        }
        else if (touch.phase == TouchPhase.Began)
        {
            OnTouchDown(touch);
        }
        else if (touch.phase == TouchPhase.Stationary)
        {
            OnHold(touch);
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            OnTouchUp(touch);
        }
    }

    public virtual void OnTouchDown(Touch touch) { }
    public virtual void OnDrag(Touch touch) { }
    public virtual void OnTouchUp(Touch touch) { }
    public virtual void OnHold(Touch touch) { }
}
