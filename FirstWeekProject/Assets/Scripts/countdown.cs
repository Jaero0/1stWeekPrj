/*using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour
{

    private int Timer = 0;

    public GameObject countdown_3;   //1��
    public GameObject countdown_2;   //2��
    public GameObject countdown_1;   //3��
    public GameObject countdown_start;

    void Start()

    {

        //���۽� ī��Ʈ �ٿ� �ʱ�ȭ
        Timer = 20;



        countdown_3.SetActive(false);
        countdown_2.SetActive(false);
        countdown_1.SetActive(false);
        countdown_start.SetActive(false);



    }



    void Update()
    {

        //���� ���۽� ����
        if (Timer == 0)
        {
            Time.timeScale = 0.0f;
        }


        //Timer �� 90���� �۰ų� ������� Timer �������

        if (Timer <= 90)
        {
            Timer++;

            // Timer�� 30���� ������� 3���ѱ�
            if (Timer < 30)
            {
                countdown_3.SetActive(true);
            }

            // Timer�� 30���� Ŭ��� 3������ 2���ѱ�
            if (Timer > 30)
            {
                countdown_3.SetActive(false);
                countdown_2.SetActive(true);
            }

            // Timer�� 60���� ������� 2������ 1���ѱ�
            if (Timer > 60)
            {
                countdown_2.SetActive(false);
                countdown_1.SetActive(true);
            }

            //Timer �� 90���� ũ�ų� ������� 1������ GO �ѱ� LoadingEnd () �ڷ�ƾȣ��
            if (Timer >= 90)
            {
                countdown_1.SetActive(false);
                countdown_start.SetActive(true);
                StartCoroutine(this.LoadingEnd());
                Time.timeScale = 1.0f; //���ӽ���
            }
        }

    }


    IEnumerator LoadingEnd()
    {


        yield return new WaitForSeconds(1.0f);
        countdown_start.SetActive(false);
    }

}*/