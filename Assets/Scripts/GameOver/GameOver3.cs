using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    //Continue 버튼을 눌렀을 때 동작
    public void OnContinue()
    {
        //Stage3 플레이중 죽었을 때 다시 Stage3부터 플레이
        SceneManager.LoadScene("Stage3");
    }
    // Update is called once per frame
    void Update()
    {

    }
}