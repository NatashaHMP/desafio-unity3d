using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour 
{
	public Transform cameraObject;

	public float positionYRevive = 1.5f;
	public float positionXReviveBox = -10f;
	public float positionXRevivePlayer = -12f;
	public float positionXInitCamera = -4f;

	private Vector2 positionPlayerRevive;
	private Vector2 positionBoxRevive;

	private void Start()
	{
		positionPlayerRevive = new Vector2 (positionXRevivePlayer, positionYRevive);
		positionBoxRevive = new Vector2 (positionXReviveBox, positionYRevive);
	}

	//Caso sofra colisão		
	private void OnCollisionEnter2D (Collision2D collisionObject) 
	{
		if (collisionObject.gameObject.tag == "Player" || collisionObject.gameObject.tag == "Box") 
		{
			DieAndReviveObject (collisionObject.gameObject);
		}
	}

	//Matar e reviver objeto
	public void DieAndReviveObject(GameObject gameObject)
	{
		if (gameObject.tag == "Player") 
		{
			InitPositionCamera ();											//voltar para a posição atual da camera
			gameObject.transform.position = positionPlayerRevive;			//voltar para a posição inicial do objeto
		} else if (gameObject.tag == "Box") 
		{
			gameObject.transform.rotation = Quaternion.identity; 			//Fazer a box voltar na rotação atual
			gameObject.transform.position = positionBoxRevive;				//voltar para a posição inicial do objeto
		}
	}

	//voltar para a posição atual da camera
	private void InitPositionCamera()
	{
		cameraObject.position = new Vector3 (positionXInitCamera, cameraObject.position.y, cameraObject.position.z);
	}
}
