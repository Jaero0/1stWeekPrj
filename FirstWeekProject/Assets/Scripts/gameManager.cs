using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.Linq;

public class gameManager : MonoBehaviour
{
    public Text timeTxt;

    public Text teamName;
    public GameObject card;
    float time = 0.0f;
    int count = 0;//:ssh
    public static gameManager I;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject endpenal;
    
    public Text scoreTxt;//matching score :ssh

    string humanName;
    public AudioClip match; 
    public AudioSource audioSource;
    



    void Awake()
    {
        I = this;
    }
    void Start()
    {



        Time.timeScale = 1.0f;

        int[] rtans = { 0,0,1,1,2,2,3,3,4,4,5,5};


        humans = humans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 12; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;


            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string humanName = "human" + humans[i].ToString();

            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(humanName);
        }
    }

        void Update()
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");

             if(time >= 30)
                 {
                     GameEnd();
                 }
        scoreTxt.text = "¸ÅÄªÈ½¼ö: " + count.ToString();
    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            if (firstCardImage == "human0" || firstCardImage == "human1")
            {
                teamName.text = "Á¤ÀçÈ£";
            }
            else if (firstCardImage == "human2" || firstCardImage == "human3")
            {
                teamName.text = "±èÁØ¹ü";
            }
            else if (firstCardImage == "human4" || firstCardImage == "human5")
            {
                teamName.text = "¼Û½ÂÈÆ";
            }
           
            audioSource.PlayOneShot(match);

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            count++; //matching score :ssh
            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {

                GameEnd();
            }
           
        }
    }

    public void deMatched()  // ³ª´« ÀÌÀ¯ ¸ÞÄ¡°¡ ¾ÈçÀ»¶§ ÀÏ¾î³¯¼öÀÖ´Â ÀÌº¥Æ®°¡ÀÕÀ»¼öµµÀÖ¾î¼­  
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        if (firstCardImage != secondCardImage)
        {
            count++; //matching score: ssh
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
            teamName.text = "½ÇÆÐ ¤Ð";
        }
        firstCard = null;
        secondCard = null;

    }



        void GameEnd()
    {
        endpenal.SetActive(true);
        Time.timeScale = 0f;
    }

}



