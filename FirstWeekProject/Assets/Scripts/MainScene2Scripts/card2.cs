using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class card2 : MonoBehaviour
{
    public Animator anim;
    public AudioClip flip;
    public AudioSource audioSource;
    private bool isOpening = false; // ssh ī�尡 ���� �������� ����  
    private float CloseTime = 3.0f; // ssh �ڵ� ������ Ÿ�̸�

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
        anim.SetBool("isOpen2", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);
        Imgcolor();//ssh

        if (!isOpening)//ssh
        {
            isOpening = true;
            CloseTime = 2.0f;
        }

        if (gameManager2.M.firstCard == null)
        {
            gameManager2.M.firstCard = gameObject;
        }
        else
        {
            gameManager2.M.secondCard = gameObject;
            gameManager2.M.isMatched();
            gameManager2.M.deMatched();

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
        anim.SetBool("isOpen2", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
        gameManager2.M.firstCard = null;//ssh << �ֵ� 0.5�ʵڿ� ����� 
    }

    public void Imgcolor() //ssh
    {
        Transform backImg = transform.Find("back");
        SpriteRenderer backSpriteRenderer = backImg.GetComponent<SpriteRenderer>();
        backSpriteRenderer.color = new Color32(121, 121, 121, 255);
    }
}