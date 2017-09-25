using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	//Carregar Scene no menu
	public void ChangeMenu (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
