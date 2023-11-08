using UnityEngine;
using System.Collections;
public class CameraMovement : MonoBehaviour
{
    private float Speed = 0.2f; // 카메라 이동 속도
    private Vector2 nowPos, prePos; // 지금 위치, 이전 위치
    private Vector3 movePos;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Time.deltaTime * Speed;
                Camera.main.transform.Translate(movePos);
                prePos = touch.position - touch.deltaPosition;
            }
        }
    }
}