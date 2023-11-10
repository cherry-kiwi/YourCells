using UnityEngine;
using System.Collections;
public class CameraMovement : MonoBehaviour
{
    public float Speed = 1.0f; // 카메라 이동 속도
    private Vector2 nowPos, prePos;
    private Vector3 movePos;

    void Update()
    {
        if (Input.touchCount == 1) // 손가락 1개가 눌렸을 때
        {
            Touch touch = Input.GetTouch(0); // 첫번째 손가락 터치를 저장
            if (touch.phase == TouchPhase.Began) // 손가락이 화면에 터치됐을 때
            {
                prePos = touch.position - touch.deltaPosition; // 이전 위치 저장
            }
            else if (touch.phase == TouchPhase.Moved) // 터치된 상태에서 움직였을 때
            {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Time.deltaTime * Speed;
                Camera.main.transform.Translate(movePos);
                prePos = touch.position - touch.deltaPosition;
            }
        }
    }
}