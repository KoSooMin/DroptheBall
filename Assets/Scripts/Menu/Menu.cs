using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    //Start 버튼을 눌렀을 때 동작
    public void onStart()
    {
        //Stage1부터 시작
        SceneManager.LoadScene("Stage1");
    }

    // Update is called once per frame
    void Update()
    {

    }
}