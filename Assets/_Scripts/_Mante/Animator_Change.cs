using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Change : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController[] animator_Controller;
    [SerializeField] private Liste_Mante lm;
    Animator animator;

    private void Start()
    {
        lm = FindObjectOfType<Liste_Mante>();
        animator = GetComponentInChildren<Animator>();
        lm.mantes.Add(this.gameObject);
    }

    private void Update()
    {
        if(this.tag == "Gendarme_Mante")
        {
            animator.runtimeAnimatorController = animator_Controller[1];
        }
    }
}
