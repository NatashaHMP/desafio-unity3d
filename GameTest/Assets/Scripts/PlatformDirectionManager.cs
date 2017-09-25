using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDirectionManager : MonoBehaviour {
	public Transform[] platformDirection;

	public int directionMovement;

	public IEnumerator<Transform> GetPathEnumerator()
	{
		int direction = 1;
		int index = 0;

		while (true) 
		{
			directionMovement = direction;

			yield return platformDirection [index];

			//verificar qual direção a plataforma precisa ir
			if (index <= 0)
				direction = 1;
			else if (index >= platformDirection.Length - 1)
				direction = -1;

			index += direction;	
		}
	}
}
