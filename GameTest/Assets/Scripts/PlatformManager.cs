using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

	public enum FollowType
	{
		MoveTowards,
		Lerp
	}

	public FollowType type = FollowType.MoveTowards;
	public PlatformDirectionManager platform;

	public float speedPlatform = 1;
	public float MaxDistanceToGoal = .1f;

	public IEnumerator<Transform> currentPositionPlatform;

	// Use this for initialization
	private void Start () {

		currentPositionPlatform = platform.GetPathEnumerator ();
		currentPositionPlatform.MoveNext ();									//mudar de posição

		transform.position = currentPositionPlatform.Current.position;			//posição onde a plataforma deve se mover
	}
	
	// Update is called once per frame
	private void Update () 
	{
		//movimenta de acordo com o tipo de movimento
		TypeMove ();

		//fazer com que a plataforma se mova em cada frame
		MovePerFrame ();
	}

	//movimenta de acordo com o tipo de movimento
	private void TypeMove() 
	{
		if (type == FollowType.MoveTowards) 
			transform.position = Vector3.MoveTowards (transform.position,                                     //posição em que a plataforma esta
													  currentPositionPlatform.Current.position,               //posição onde ela deve ir
													  Time.deltaTime * speedPlatform);                        //velocidade
		else if (type == FollowType.Lerp)
			transform.position = Vector3.Lerp (transform.position, 											  //posição em que a plataforma esta
											   currentPositionPlatform.Current.position, 					  //posição onde ela deve ir
											   Time.deltaTime * speedPlatform);								  //velocidade
	}

	//fazer com que a plataforma se mova em cada frame
	private void MovePerFrame()
	{
		float distanceSquared = (transform.position - currentPositionPlatform.Current.position).sqrMagnitude;

		if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal) 
			currentPositionPlatform.MoveNext ();	
	}
}
