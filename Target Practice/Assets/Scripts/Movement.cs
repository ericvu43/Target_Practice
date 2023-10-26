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
        HandArrow.gameObject.SetActive(false);
    }

    void HandArrowActive()
    {
        HandArrow.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("aim", true);
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("aim", false);
            animator.SetBool("shoot", true);
        }
        else
        {
            animator.SetBool("shoot", false);
        }
    }
}
