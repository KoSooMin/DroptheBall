using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // 변수 선언
    int cnt; // 체크변수

    float power; // 힘
    float MaxDistance = 0.05f;

    RaycastHit hit;

    public LayerMask LayerMasksafe; //safe 면적
    public LayerMask LayerMaskdanger; // dangerous 면적

    Vector3 check_pos; //체크좌표
    Vector3 now_pos; //현재좌표
    Vector3 first_pos; //초기좌표


    // Start is called before the first frame update
    void Start()
    {
        // 변수 초기화
        cnt = 0;
        check_pos = gameObject.transform.position;
        power = -2.5f;
        first_pos = gameObject.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 공이 힘에 따라 이동
        gameObject.transform.position += (new Vector3(0, power, 0) * Time.deltaTime);

        // 공의 이동거리에 따라 힘 증가
        if (check_pos.y - gameObject.transform.position.y >= 1)
        {
            check_pos = gameObject.transform.position;
            power -= 0.001f;
        }

        Debug.DrawRay(transform.position, (gameObject.transform.position - first_pos) * MaxDistance, Color.blue, 0.3f);

        // Safe면적에 공이 닿았을때
        if (Physics.Raycast(transform.position, (gameObject.transform.position - first_pos), out hit, MaxDistance, LayerMasksafe))
        {
            if (power <= -2.505f)
            {
                // 버프가 있는 상태에서 Safe 면적에 닿았을때 
                Destroy(hit.collider.gameObject, 0); // 면적 제거
            }

            cnt++;
            now_pos = gameObject.transform.position;

            power = 2.5f;

        }

        // 공이 자연스럽게 움직이도록
        if (cnt == 1 && (transform.position.y - now_pos.y) >= 0.7)
        {
            cnt++;
            power = -0.5f;
        }
        else if (cnt == 2 && (transform.position.y - now_pos.y) <= 0.67)
        {
            cnt = 0;
            power = -2.5f;
            check_pos = gameObject.transform.position;
        }

        if (Physics.Raycast(transform.position, (gameObject.transform.position - first_pos), out hit, MaxDistance, LayerMaskdanger))
        {
            // 버프시 Danger에 도달
            if (power <= -2.505f)
            {
                Destroy(hit.collider.gameObject, 0); // 면적제거

                cnt++;
                now_pos = gameObject.transform.position;

                power = 2.5f;
            }

            //게임 오버(버프없이 Danger에 도달)
            else
            {

                if (SceneManager.GetActiveScene().name == "Stage1") // Stage1 게임오버면 GameOver1씬으로 이동
                    SceneManager.LoadScene("GameOver1");   
                else if (SceneManager.GetActiveScene().name == "Stage2") // Stage2 게임오버면 GameOver2씬으로 이동
                    SceneManager.LoadScene("GameOver2");
                else if (SceneManager.GetActiveScene().name == "Stage3") // Stage3 게임오버면 GameOver3씬으로 이동
                    SceneManager.LoadScene("GameOver3");


                //Debug.Log("gravity : " + power);
                //gameObject.transform.position = first_pos;
                //power = -2.5f;
                //cnt = 0;
                //check_pos = first_pos;

            }
        }
    }
}
