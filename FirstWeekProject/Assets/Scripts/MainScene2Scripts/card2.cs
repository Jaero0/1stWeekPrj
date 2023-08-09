using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class card2 : MonoBehaviour
{
    public Animator anim;
    public AudioClip flip;
    public AudioSource audioSource;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openCard()
    {
        audioSource.PlayOneShot(flip);
        anim.SetBool("isOpen2", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);
        Imgcolor();//ssh


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
        Invoke("closeCardInvoke", 0.5f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen2", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }

    public void Imgcolor() //ssh
    {
        Transform backImg = transform.Find("back");
        SpriteRenderer backSpriteRenderer = backImg.GetComponent<SpriteRenderer>();
        backSpriteRenderer.color = new Color32(121, 121, 121, 255);
    }
}
