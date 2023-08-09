/*using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour
{

    private int Timer = 0;

    public GameObject countdown_3;   //1번
    public GameObject countdown_2;   //2번
    public GameObject countdown_1;   //3번
    public GameObject countdown_start;

    void Start()

    {

        //시작시 카운트 다운 초기화
        Timer = 20;



        countdown_3.SetActive(false);
        countdown_2.SetActive(false);
        countdown_1.SetActive(false);
        countdown_start.SetActive(false);



    }



    void Update()
    {

        //게임 시작시 정지
        if (Timer == 0)
        {
            Time.timeScale = 0.0f;
        }


        //Timer 가 90보다 작거나 같을경우 Timer 계속증가

        if (Timer <= 90)
        {
            Timer++;

            // Timer가 30보다 작을경우 3번켜기
            if (Timer < 30)
            {
                countdown_3.SetActive(true);
            }

            // Timer가 30보다 클경우 3번끄고 2번켜기
            if (Timer > 30)
            {
                countdown_3.SetActive(false);
                countdown_2.SetActive(true);
            }

            // Timer가 60보다 작을경우 2번끄고 1번켜기
            if (Timer > 60)
            {
                countdown_2.SetActive(false);
                countdown_1.SetActive(true);
            }

            //Timer 가 90보다 크거나 같을경우 1번끄고 GO 켜기 LoadingEnd () 코루틴호출
            if (Timer >= 90)
            {
                countdown_1.SetActive(false);
                countdown_start.SetActive(true);
                StartCoroutine(this.LoadingEnd());
                Time.timeScale = 1.0f; //게임시작
            }
        }

    }


    IEnumerator LoadingEnd()
    {


        yield return new WaitForSeconds(1.0f);
        countdown_start.SetActive(false);
    }

}*/