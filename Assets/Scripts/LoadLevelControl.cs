using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;			//Libreria para el manejo de escenas.

public class LoadLevelControl : MonoBehaviour
{
	//Este metodo es llamado cuando el usuario hace click sobre un collider o un elemento de UI determinado (con collider asociado).
	//El evento es enviado a todos los scripts asociados al collider.
	void OnMouseDown()
	{
		//Se accede al componente AudioSource de la camara principal y se hace stop, no es necesario referenciarla con una variable publica.
		Camera.main.GetComponent<AudioSource>().Stop();

		//Se accede al componente AudioSource del mismo objecto que contiene el script, por lo cual no se referencia con variable publica.
		GetComponent<AudioSource>().Play ();

		//Se invoca el metodo que cargara el siguiente nivel pero con un tiempo de espera, en este caso, la duracion del audio del PlayButton.
		Invoke ("LoadLevel", GetComponent<AudioSource>().clip.length);
	}

	void LoadLevel()								//Funcion que carga el siguiente nivel.
	{
		switch (gameObject.name)					//En caso de que el nombre del objecto que contiene el script sea...
		{
		case "PlayAgainLabel":						//Si es PlayAgainLabel se carga la escena GameScene.
			SceneManager.LoadScene ("GameScene");
			break;

		case "PlayButton":						//Si es PlayAgainLabel se carga la escena GameScene.
			SceneManager.LoadScene ("GameScene");
			break;
		
		case "MenuLabel":							//Si es PlayAgainLabel se carga la escena MenuScene.
			SceneManager.LoadScene ("MainScene");
			break;
		}
	}
}
