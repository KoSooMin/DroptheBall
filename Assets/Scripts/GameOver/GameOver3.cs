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
    //Continue ��ư�� ������ �� ����
    public void OnContinue()
    {
        //Stage3 �÷����� �׾��� �� �ٽ� Stage3���� �÷���
        SceneManager.LoadScene("Stage3");
    }
    // Update is called once per frame
    void Update()
    {

    }
}