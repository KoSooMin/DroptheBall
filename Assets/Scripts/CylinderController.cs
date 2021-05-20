using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour
{
    // 변수 선언
    Vector2 past_pos;
    Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // 현재좌표 입력
            Vector2 now_pos = Input.mousePosition;

            if (past_pos == Vector2.zero)
            {
                // 처음누르면 현재좌표를 과거좌표로 대입
                past_pos = now_pos;
            }

            float delta = past_pos.x - now_pos.x; // 얼마나 좌표를 이동시켰는지 체크
            past_pos = now_pos; // 현재좌표를 과거좌표로 대입

            transform.Rotate(Vector3.up * delta); // 회전시키기
        }

        if (Input.GetMouseButtonUp(0))
        {
            // 더 이상 누르지 않으면 과거좌표는 다시 초기화
            past_pos = Vector2.zero;
        }
    }
}
