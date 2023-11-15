using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;
    [Header("Arrow")]
    public GameObject HandArrow;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("aim", true);
            HandArrowActive();
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("aim", false);
            animator.SetBool("shoot", true);
            HandArrow.SetActive(false);
        }
        else
        {
            animator.SetBool("shoot", false);
        }
    }
    public void HandArrowActive()
    {
        HandArrow.SetActive(true);
    }
}
