using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

/*
TODO
1- Get the randomized coordinates for pointing and look from an array
2- Positionate bot into the scene
3- Positionate the pointing elements in the scene
*/

public class PointingCtrlScript : MonoBehaviour {

	protected Animator animator;

	// ik = inverse kinematics
	public bool ikActive = false;
	public Transform lookObj = null;
	public Transform pointedObject = null;
	public float ikWeight = 1;


	// Use this for initialization
	void Start () {
		Debug.Log ("Start called\n");
		animator = GetComponent<Animator> ();
	}

	void OnAnimatorIK(){
		ikWeight = animator.GetFloat ("CurveIkWeight");
		Debug.Log ("ik float = ");
		Debug.Log (ikWeight);

		//if IK is active, set the position and rotation directly to the goal
		if (ikActive) {

			//set the look target position, if one has been asigned
			if (lookObj != null) {
				animator.SetLookAtWeight(ikWeight);
				animator.SetLookAtPosition(lookObj.position);
			}

			if (pointedObject != null){
				//
				if (ikActive) {
					animator.SetIKPositionWeight(AvatarIKGoal.RightHand,ikWeight);
					animator.SetIKPosition(AvatarIKGoal.RightHand,pointedObject.position);
				}

			}


			//if IK not active then set the the position of the head at its initial position
		} else {
			animator.SetLookAtWeight(0);
			animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
		}


	}

	// Update is called once per frame
	void Update () {
	
	}


}
