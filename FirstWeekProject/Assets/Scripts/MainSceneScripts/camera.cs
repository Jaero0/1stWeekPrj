using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeBack()
    {
        animator.SetBool("IsTime", true);
        Debug.Log("¾ÈµÊ");
    }

    public void NotChange()
    {
        animator.SetBool("IsTime", false);
        
    }
}
