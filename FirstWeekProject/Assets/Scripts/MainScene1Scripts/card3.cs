using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class card3 : MonoBehaviour
{
    public Animator anim;
    public AudioClip flip;
    public AudioSource audioSource;
    private bool isOpening = false; // ssh 카드가 열린 상태인지 여부  
    private float CloseTime = 3.0f; // ssh 자동 닫히는 타이머

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening)//ssh
        {
            CloseTime -= Time.deltaTime;
            if (CloseTime <= 0.0f)
            {
                isOpening = false;
                CancelInvoke("closeCardInvoke");//ssh
                closeCardInvoke();
            }
        }
    }

    public void openCard()
    {

        audioSource.PlayOneShot(flip);
        anim.SetBool("isOpen3", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);
        Imgcolor();//ssh

        if (!isOpening)//ssh
        {
            isOpening = true;
            CloseTime = 2.0f;
        }

        if (gameManager3.Z.firstCard == null)
        {
            gameManager3.Z.firstCard = gameObject;
        }
        else
        {
            gameManager3.Z.secondCard = gameObject;
            gameManager3.Z.isMatched();
            gameManager3.Z.deMatched();

        }
    }

    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 1.0f);
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        CancelInvoke("closeCardInvoke");//ssh
        Invoke("closeCardInvoke", 0.5f);
        isOpening = false;//ssh
        CloseTime = 0.03f;
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen3", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
        gameManager3.Z.firstCard = null;//ssh << 애도 0.5초뒤에 사라짐 
    }

    public void Imgcolor() //ssh
    {
        Transform backImg = transform.Find("back");
        SpriteRenderer backSpriteRenderer = backImg.GetComponent<SpriteRenderer>();
        backSpriteRenderer.color = new Color32(121, 121, 121, 255);
    }
}