using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public GameObject box;
	public Transform playerObject;
	public Transform cameraObject;

	public float cameraVelocity = 1f;
	public float positionXVictory = 18f;

	// Update is called once per frame
	private void Update () 
	{
		//Camera seguindo o personagem
		FollowCam (); 

		//Verificar se o objetivo do jogo foi completado
		GameGoalChecker ();	
	}

	//Camera seguindo o personagem
	private void FollowCam()
	{
		if(playerObject.position.x >= -4)
			cameraObject.position = Vector3.Lerp (cameraObject.position, 																	   //posição atual da camera
											      new Vector3 (playerObject.position.x, cameraObject.position.y, cameraObject.position.z),     //nova posição da camera
											      cameraVelocity);
	}

	//Verificar se o objetivo do jogo foi completado
	private void GameGoalChecker() 
	{
		//Se a posição de x da box for >= 18 >> tela de vitória
		if(box.transform.position.x >= positionXVictory)
			SceneManager.LoadScene("VictoryScene");
	}


}
