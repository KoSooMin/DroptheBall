using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    //Continue ��ư�� ������ �� ����
    public void OnContinue()
    {
        //Stage2 �÷����� �׾��� �� �ٽ� Stage2���� �÷���
        SceneManager.LoadScene("Stage2");
    }

    // Update is called once per frame
    void Update()
    {

    }
}