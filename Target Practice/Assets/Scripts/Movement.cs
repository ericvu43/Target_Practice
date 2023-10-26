using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("aim", true);
            
        }
        if (Input.GetMouseButtonUp(0))
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
