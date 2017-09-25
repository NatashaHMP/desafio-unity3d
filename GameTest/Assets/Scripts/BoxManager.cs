using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour 
{
	public PlatformDirectionManager platform;
	public Transform floorChecker;

	public float boxVelocity = 1f;

	// Update is called once per frame
	private void Update () 
	{
		//Se mover enquanto estiver na plataforma de acordo com a direção de tal
		MoveInPlatform ();
	}

	//Se mover enquanto estiver na plataforma de acordo com a direção de tal
	private void MoveInPlatform()
	{
		//verifica se a box esta em cima da plataforma
		bool inPlatform = Physics2D.Linecast(gameObject.transform.position, 						//posição da box
											 floorChecker.position,                                 //posição do verificador da box (no chão)
											 1 << LayerMask.NameToLayer("Platform"));             //identificação do objeto que esta embaixo da box

		if (inPlatform) 
		{
			if(platform.directionMovement == 1)
				//Se mover para a direita
				transform.Translate (Vector2.right * boxVelocity * 
									 Time.deltaTime);
			else
				//Se mover para a esquerda
				transform.Translate (Vector2.left * boxVelocity * 
									 Time.deltaTime);
		}
	}
}
