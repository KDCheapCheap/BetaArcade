﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : StateMachineBehaviour {

    [SerializeField]
    private float m_DelayTime = 2f;
    [SerializeField]
    private string m_TransitionBoolName = "CanChop";
    private float m_CurrentDelay = 0f;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        m_CurrentDelay = 0;
	}

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        m_CurrentDelay += Time.deltaTime;

        if (m_CurrentDelay >= m_DelayTime)
        {
            animator.SetBool(m_TransitionBoolName, true);
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetBool(m_TransitionBoolName, false);
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
