using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || 
            Input.GetKey(KeyCode.A) || 
            Input.GetKey(KeyCode.S) || 
            Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsWalking",true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
