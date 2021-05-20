using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2 : MonoBehaviour
{
    public List<GameObject> FloorList = new List<GameObject>();

    RaycastHit hit;
    float MaxDistance = 0.05f;
    public LayerMask LayerMaskfinish;
    Vector3 pos;

    public GameObject SafePrefab;
    public GameObject DangerPrefab;
    public GameObject FinishPrefab;
    public GameObject BallPrefab;

    public int stage = 2; // 게임스테이지
    float floormax = 20; //층 개수
    Color SafeColor = new Color(71 / 255f, 125 / 255f, 67 / 255f);
    Color DangerColor = new Color(250 / 255f, 66 / 255f, 48 / 255f);
    int emptynum = 4;   //구멍 개수
    int dangernum = 4;  //밟으면 안되는 면적 

    int[] randlist;     //난수 list
    bool isempty = false;
    bool isdanger = false;
    List<int> emptylist = new List<int>();  //구멍 위치list
    List<int> dangerlist = new List<int>(); //밟으면 안되는 면적 놓을 위치list


    // Start is called before the first frame update
    void Start()
    {
        BallPrefab.transform.position = new Vector3(0.278f, 5, -1.424f);
        gameObject.transform.localScale = new Vector3(2, 10 * stage, 2);    // 원기둥 길이 (1단계:10, 2단계:20, 3단계:30)
        gameObject.transform.position = new Vector3(0, 5 - 10 * stage, 0);    // 원기둥 y 위치 (1단계:-5, 2단계:-15, 3단계:-25)   (비율 맞게 찾아낸 값)
        bool same;

        for (int floorcount = 0; floorcount < floormax; floorcount++)
        {
            //층마다 랜덤 선택
            if (floorcount != floormax - 1)
            {
                emptylist.Clear();
                dangerlist.Clear();

                // 임의로 'empty + danger' 총 개수만큼 난수list 생성 ,  조각은 0~11
                randlist = new int[emptynum + dangernum];
                for (int i = 0; i < emptynum + dangernum; i++)
                {
                    while (true)
                    {
                        randlist[i] = Random.Range(0, 11);
                        same = false;

                        for (int j = 0; j < i; j++)
                        {
                            if (randlist[j] == randlist[i])// 이전까지 수들중 중복 있는지 확인
                            {
                                same = true;
                                break;
                            }
                        }
                        if (!same) break;   // 중복있으면 다시 선택, 중복 없으면 다음 수 선택 (for 문으로 감)
                    }
                }

                //각 층마다 구멍, danger 놓을위치 선택
                for (int i = 0; i < emptynum; i++)
                {
                    emptylist.Add(randlist[i]);                //난수리스트에서 앞부분을 empty리스트로     
                }
                for (int i = emptynum; i < emptynum + dangernum; i++)
                {
                    dangerlist.Add(randlist[i]);     // 뒷부분을 danger 리스트로
                }
            }

            //조각들을 각각 알맞게 놓음
            for (int piece = 0; piece < 12; piece++)
            {
                //맨 마지막층인지 확인
                if (floorcount == floormax - 1)
                {
                    GameObject finishfloor = GameObject.Instantiate(FinishPrefab);
                    FloorList.Add(finishfloor);
                    finishfloor.transform.position = new Vector3(0, 3.0f - 2.0f * floorcount, 0);                       //초기 높이 y=3
                    finishfloor.transform.rotation = Quaternion.Euler(-90.0f, 30.0f * piece, 0);
                    finishfloor.transform.parent = transform;
                    continue;
                }

                //empty위치인지 확인
                for (int j = 0; j < emptynum; j++)
                {
                    if (emptylist[j] == piece)
                    {
                        isempty = true;                 //empty 리스트에 현재piece가 있는지 확인
                        break;                          //있으면 바로 for문 탈출
                    }
                }
                if (isempty)
                {
                    isempty = false;           //if문에 들어오기 위해 true로 바꿔 사용한 isempty를 다시 false로 돌려서 다음조각 판단에 제대로 사용되도록 함
                    continue;       // empty 해야되는 곳이면 다음 조각 으로 넘어감 (다음 i로)
                }

                if (floorcount == 0)
                {
                    GameObject safefloor = GameObject.Instantiate(SafePrefab);
                    safefloor.GetComponent<MeshRenderer>().material.color = SafeColor;
                    FloorList.Add(safefloor);
                    safefloor.transform.position = new Vector3(0, 3.0f - 2.0f * floorcount, 0);
                    safefloor.transform.rotation = Quaternion.Euler(-90.0f, 30.0f * piece, 0);
                    safefloor.transform.parent = transform;
                    continue;
                }

                //danger위치인지 확인
                for (int j = 0; j < dangernum; j++)
                {
                    if (dangerlist[j] == piece)
                    {
                        isdanger = true;                 //danger 리스트에 piece가 있는지 확인
                        break;                          //있으면 바로 for문 탈출
                    }
                }
                if (isdanger)   //piece가 danger 놓을 위치면
                {
                    GameObject dangerfloor = GameObject.Instantiate(DangerPrefab);
                    dangerfloor.GetComponent<MeshRenderer>().material.color = DangerColor;
                    FloorList.Add(dangerfloor);
                    dangerfloor.transform.position = new Vector3(0, 3.0f - 2.0f * floorcount, 0);                       //초기 높이 y=3
                    dangerfloor.transform.rotation = Quaternion.Euler(-90.0f, 30.0f * piece, 0);
                    dangerfloor.transform.parent = transform;
                    isdanger = false;           //if문에 들어오기 위해 true로 바꿔 사용한 isdanger을 다시 false로 돌려서 다음조각 판단에 제대로 사용되도록 함
                }

                // 나머지는 safe 
                else
                {
                    GameObject safefloor = GameObject.Instantiate(SafePrefab);
                    safefloor.GetComponent<MeshRenderer>().material.color = SafeColor;
                    FloorList.Add(safefloor);
                    safefloor.transform.position = new Vector3(0, 3.0f - 2.0f * floorcount, 0);
                    safefloor.transform.rotation = Quaternion.Euler(-90.0f, 30.0f * piece, 0);
                    safefloor.transform.parent = transform;
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(BallPrefab.transform.position, (BallPrefab.transform.position - pos), out hit, MaxDistance, LayerMaskfinish))
        {
            FloorList.Clear();
            SceneManager.LoadScene("Stage3");
        }

    }
}
