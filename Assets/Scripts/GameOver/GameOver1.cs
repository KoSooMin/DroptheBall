using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    //Continue ��ư�� ������ �� ����
    public void OnContinue()
    {
        //Stage1 �÷����� �׾��� �� �ٽ� Stage1���� �÷���
        SceneManager.LoadScene("Stage1");
    }

    // Update is called once per frame
    void Update()
    {

    }
}