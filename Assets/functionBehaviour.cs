using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functionBehaviour : StateMachineBehaviour
{
    [SerializeField] Boss Boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.Function1();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.CanChoose = true;
    }

}
