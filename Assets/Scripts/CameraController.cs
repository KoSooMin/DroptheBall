using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball; // 공
    float distance; // 거리
    // Start is called before the first frame update
    void Start()
    {
        // 간격 설정(카메라와 공의 Y좌표 사이의 거리)
        distance = transform.position.y - ball.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // 공을 따라 카메라 이동
        Vector3 pos = transform.position;
        pos.y = ball.transform.position.y + distance; // 공의 Y좌표 + 간격 => 카메라가 위에서 아래를 볼 수 있도록
        transform.position = pos;
    }
}
