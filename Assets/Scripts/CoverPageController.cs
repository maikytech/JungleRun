using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoverPageController : MonoBehaviour
{
	public float delayTime;						//Tiempo de retraso.

	void Start()
	{
		Invoke("LoadMainMenu", delayTime);			//Invoca un metodo con un tiempo de retraso.

	}

	void LoadMainMenu()								//Carga un nivel.
	{
		SceneManager.LoadScene ("MainScene");	
	}
}
