using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public bool AllowInput = false;
    [SerializeField] private Camera gameCamera;
    public int tapLimit = 2;
    void Start()
    {
        AllowInput = true;
    }

    private void Update()
    {
        if (AllowInput == false)
            return;

        if (Input.touchCount > 0)
        {
            int maxTouch = Input.touchCount >= tapLimit ? tapLimit : Input.touchCount; // limit to 4 finger touch
            //TODO Improve this shit
            for (int i = 0; i < maxTouch; i++)
            {
                Touch touch = Input.GetTouch(i);

                // Check if camera is available
                if (gameCamera?.gameObject.activeSelf == false)
                {
                    Debug.LogError("Can't find camera");
                    return;
                }

                // Check if position is in screen
                Vector3 pos = gameCamera.ScreenToViewportPoint(touch.position);
                if (float.IsNaN(pos.x) || float.IsNaN(pos.y))
                {
                    Debug.LogError("Touch object is not on screen");
                    return;
                }

                Ray ray = gameCamera.ScreenPointToRay(touch.position);
                float dist = gameCamera.farClipPlane - gameCamera.nearClipPlane;

                Vector3 point = ray.GetPoint(dist);
                Collider2D overlapCollider = Physics2D.OverlapPoint(point);

                if (overlapCollider != null)
                {
                    var objectBeingTouch = overlapCollider.GetComponent<TouchResponse>();
                    objectBeingTouch?.TouchInput(touch);
                }
            }
        }
    }
}
