using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class card : MonoBehaviour
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
        anim.SetBool("isOpen", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);
        Imgcolor();//ssh


        if (gameManager.M.firstCard == null)
        {
            gameManager.M.firstCard = gameObject;
        }
        else
        {
            gameManager.M.secondCard = gameObject;
            gameManager.M.isMatched();
            gameManager.M.deMatched();
           
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
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }

   public  void Imgcolor() //ssh
    {
        Transform backImg = transform.Find("back");
        SpriteRenderer backSpriteRenderer = backImg.GetComponent<SpriteRenderer>();
        backSpriteRenderer.color = new Color32(121, 121, 121, 255);
    }

}
