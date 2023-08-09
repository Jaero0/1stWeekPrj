using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;

public class gameManager : MonoBehaviour
{
    float time = 20.0f;
    int count = 0;//:ssh
    bool underTime = false; //JJH

    public Text timeTxt;
    public Text teamName;
    public GameObject card;

    public Text Penalty; //kjb;

    public static gameManager I;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject endpenal;

    public Text scoreTxt;//matching score :ssh

    public GameObject camera;//JJH

    string humanName;
    public AudioClip match;
    public AudioClip end; //JJH
    public AudioClip wrong; //JJH
    public AudioClip warning;//JJH
    public AudioClip timeOver;//JJH
    public AudioSource audioSource;
    public audioManager audioManager; //JJH

    void Awake()
    {
        I = this;

        audioManager = FindObjectOfType<audioManager>(); //JJH
    }

    void Start()
    {

        camera.GetComponent<camera>().NotChange();

        Time.timeScale = 1.0f;
        int[] humans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };


        humans = humans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 12; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;


            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            humanName = "human" + humans[i].ToString();

            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(humanName);


        }
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        scoreTxt.text = ""/* count matching*/ + count.ToString();
    }


    void FixedUpdate() //JJH
    {
        TimeFunc();
    }


    void TimeFunc() //JJH
    {

        if (time < 5 && underTime == false) //JJH
        {
            audioManager.audioSource.pitch = 1.6f;
            timeTxt.color = Color.red;
            camera.GetComponent<camera>().ChangeBack();
            audioSource.PlayOneShot(warning);
            underTime = true;
        }
        else if (time <= 0)
        {
            GameEnd();

            audioSource.PlayOneShot(timeOver); //JJH
        }
    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            if (firstCardImage == "human0" || firstCardImage == "human1")
            {
                teamName.text = "JJH";
            }
            else if (firstCardImage == "human2" || firstCardImage == "human3")
            {
                teamName.text = "KJB";
            }
            else if (firstCardImage == "human4" || firstCardImage == "human5")
            {
                teamName.text = "SSH";
            }

            audioSource.PlayOneShot(match);

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            count++; //matching score :ssh

            Penalty.enabled = false; //kjb;

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                //endTxt.SetActive(true);
               
                GameEnd(); //JJH : invoke함수를 제외함
                audioSource.PlayOneShot(end); // JJH
            }
        }
    }


    public void deMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage != secondCardImage)
        {
            count++; //matching score: ssh

            float result = time --; // kjb

            audioSource.PlayOneShot(wrong);

            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();

            teamName.text = " 실패 ㅠ";

            Penalty.text = " -1"; //kjb;
            Penalty.enabled = (true); //kjb;
        }

        firstCard = null;
        secondCard = null;
    }



    void GameEnd()
    {
        endpenal.SetActive(true);
        Time.timeScale = 0f;
        audioManager.audioSource.Stop();
        audioSource.Stop();
    }

}
