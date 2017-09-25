using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public PlatformDirectionManager platform;
	public Transform floorChecker;

	public float velocityPlayerWalk = 2f,
				 velocityPlayerRun = 4f;

	private Rigidbody2D rgdbody2;
	private Animator animator;

	private float velocityPlayer;
	private Vector2 directionPlayer;
	private int horizontalKey;
	private bool playerIdle = true;
	private string animPlayer,
				   animWalk = "PlayerWalk",
	               animRun = "PlayerRun",
				   animJump = "PlayerJump";
				   
	// Use this for initialization
	private void Start () 
	{
		animator = GetComponent<Animator> ();	
		rgdbody2 = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	private void Update () 
	{
		//movimentar o personagem
		MovePlayer ();
	}

	//movimentar o personagem
	private void MovePlayer() 
	{
		//Verifica se o player esta correndo ou andando
		PlayerRunOrWalk ();

		//Verifica a direção que ele esta indo
		PlayerDirection ();

		//Faz o player andar
		if (!playerIdle) 
		{
			transform.Translate (directionPlayer * velocityPlayer * Time.deltaTime);
			animator.SetTrigger (animPlayer);
		}

		//faz o player pular
		PlayerJump ();
	}

	//Verifica se o player esta correndo ou andando
	private void PlayerRunOrWalk()
	{
		int ctrlKey = (int)(Input.GetAxisRaw ("Fire1"));

		if (ctrlKey == 1) 
		{
			animPlayer = animRun;
			velocityPlayer = velocityPlayerRun;
		} else 
		{
			animPlayer = animWalk;
			velocityPlayer = velocityPlayerWalk;
		}
	}

	//Verifica a direção que ele esta indo
	private void PlayerDirection()
	{
		horizontalKey = (int)(Input.GetAxisRaw ("Horizontal"));

		switch (horizontalKey) 
		{
		//Se ele estiver parado
		case 0:
			animator.SetTrigger ("PlayerIdle");
			playerIdle = true;
			break;

			//Se ele estiver indo para a direita
		case 1:
			directionPlayer = Vector2.right;
			playerIdle = false;
			break;

			//Se ele for para a esquerda
		case -1:
			animPlayer += "Left";
			directionPlayer = Vector2.left;
			playerIdle = false;
			break;
		}
	}

	//faz o player pular
	private void PlayerJump() 
	{
		bool jumpKey = Input.GetButtonDown ("Jump");

		//Se a tecla de pulo for apertada e o player estiver em cima de algo
		if (jumpKey && CheckPlayerIn()) 
		{
			if(horizontalKey == 1 || horizontalKey == 0)
				animator.SetTrigger (animJump);
			else
				animator.SetTrigger(animJump + "Left");
			
			rgdbody2.AddForce (transform.up * 300f);
		}
	}

	//Verifica se o player esta em cima de algo
	private bool CheckPlayerIn()
	{
		if (InSomething ("Floor") || InSomething ("Platform") || InSomething ("PlatformUp") || InSomething ("Box"))
			return true;
		else
			return false;
	}

	private bool InSomething(string layerName) 
	{
		bool inSomething = Physics2D.Linecast(transform.position, 									//posição do player
											  floorChecker.position, 								//posição do verificador do player (no chão)
			                                  1 << LayerMask.NameToLayer(layerName));				//identificação do layer

		return inSomething;
	}
}
