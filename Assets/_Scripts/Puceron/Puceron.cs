using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Puceron : MonoBehaviour
{
    private Animator animatorPuceron;

    private NavMeshAgent NMA;

    private float velocityPuceron;

    // Start is called before the first frame update
    void Start()
    {
        animatorPuceron = this.GetComponent<Animator>();
        NMA = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       
            UpdateAnimation();
            //float velocityPuceron = eachPuceron[i].GetComponent<NavMeshAgent>().velocity.x;

            

        

    }

    void UpdateAnimation()
    {


        float velocityPuceronX = NMA.velocity.x;
        float velocityPuceronY = NMA.velocity.y;

        velocityPuceronX = Mathf.Abs(velocityPuceronX);
        velocityPuceronY = Mathf.Abs(velocityPuceronY);

        velocityPuceron = velocityPuceronX + velocityPuceronY;


        //Debug.Log(velocityPuceron);

        if (!animatorPuceron) { return; }

        else
        {
            animatorPuceron.SetFloat("Velocity", velocityPuceron);
        }
    }
}
