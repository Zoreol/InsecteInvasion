using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Change : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController[] animator_Controller;
    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(this.tag == "Gendarme_Mante")
        {
            animator.runtimeAnimatorController = animator_Controller[1];
        }
    }
}
