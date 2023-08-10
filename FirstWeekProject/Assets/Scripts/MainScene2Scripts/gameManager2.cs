using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class gameManager2 : MonoBehaviour
{
    float time = 80.0f;

    int count = 0;//:ssh
    float score;
    float lastTime;
    public Text countTxt;//matching score :ssh
    public Text scoreText;
    public Text lastTimeText;

    bool underTime = false; //JJH

    public Text timeTxt;
    public Text teamName;
    public GameObject card;

    public static gameManager2 M;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject endpenal;

    public Text Penalty; //kjb;
    public GameObject PenaltyTxt; //kjb;

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
        M = this;

        audioManager = FindObjectOfType<audioManager>(); //JJH
    }

    void Start()
    {
        /*
        firstCard = null; //ssh
        secondCard = null; //ssh
        */

        Time.timeScale = 1.0f;
        int[] humans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };


        humans = humans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 18; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;


            float x = (i % 6) * 0.9f - 2.2f;
            float y = (i / 6) * 0.9f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            humanName = "human" + humans[i].ToString();

            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(humanName);


        }
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
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
            if (firstCardImage == "human0" || firstCardImage == "human1" || firstCardImage == "human2")
            {
                teamName.text = "JJH";
            }
            else if (firstCardImage == "human3" || firstCardImage == "human4" || firstCardImage == "human5")
            {
                teamName.text = "KJB";
            }
            else if (firstCardImage == "human6" || firstCardImage == "human7" || firstCardImage == "human8")
            {
                teamName.text = "SSH";
            }

            audioSource.PlayOneShot(match);

            firstCard.GetComponent<card2>().destroyCard();
            secondCard.GetComponent<card2>().destroyCard();

            count++; //matching score :ssh

            PenaltyTxt.SetActive(false); //kjb;

            int cardsLeft = GameObject.Find("cards").transform.childCount;

            if (cardsLeft == 2)
            {

                GameEnd(); //JJH : 

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

            audioSource.PlayOneShot(wrong);

            firstCard.GetComponent<card2>().closeCard();
            secondCard.GetComponent<card2>().closeCard();


            teamName.text = "fail";//


            Penalty.text = " -1"; //kjb;

            PenaltyTxt.SetActive(true); //kjb;
        }

        firstCard = null;
        secondCard = null;
    }



    void GameEnd()
    {
        endScore();
        endpenal.SetActive(true);
        Time.timeScale = 0f;
        audioManager.audioSource.Stop();
        audioSource.Stop();
    }

    void endScore()
    {
        lastTime = time;//ssh
        lastTimeText.text = " time:" + lastTime.ToString("N2");
        countTxt.text = "count:" + count.ToString();
        score = lastTime * 100 - count * 150;
        scoreText.text = "Score: " + score.ToString("N0"); ;

        if (score < 0)
        {
            score = 0;
            scoreText.text = "Score: " + score.ToString("N0"); ;
        }
        else
        {
            scoreText.text = "Score: " + score.ToString("N0"); ;
        }
    }
}
