/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file changes the player's sprite based on which direction it is facing 
to give the illusion of semi 3D
*/

using UnityEngine;

public class Semi3DAnimation : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController[] animatorController;
    private bool isRight;

    private Animator animator;
    // Awake is called when the script is being loaded
    void Awake()
    {
        // Get the Renderer component attached to the GameObject
        animator = GetComponent<Animator>();

        isRight = false;
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        // Set the rotation of BikeAnimation to the negative value of the rotation of TopLevel
        transform.rotation = Quaternion.Euler(0, 0, -transform.parent.rotation.z);
    }

    // Function to change the color of the shape
    public void ChangeAnimation(int index)
    {
        if(index >= 0 && index < animatorController.Length)
        {
            // Change the sprite to the specified index
            animator.runtimeAnimatorController = animatorController[index];
            
            if(1 <= index && index <= 3 && !isRight)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                isRight = true;
            }
            else if(5 <= index && index <= 7 && isRight)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                isRight = false;
            }
        }
    }
}
