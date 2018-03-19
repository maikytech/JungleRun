using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour
{
	public GameObject cameraGameOverReference;				//Referencia a la camara de game over.
	public AudioClip gameOverClip;							//Referencia al audio de game over.

	void NotificationEvent()	//Se suscribe a los eventos.
	{
		NotificationCenter.DefaultCenter ().AddObserver (this, "PlayerHasFallen");
	}

	void PlayerHasFallen()
	{
		GetComponent<AudioSource> ().Stop ();					//Se para la reproduccion del audio de la scene principal.
		GetComponent<AudioSource>().clip = gameOverClip;		//Se agrega el audio de game over al componente AudioSource.
		GetComponent<AudioSource> ().loop = false;				//Se deshabilita la propiedad Loop.
		GetComponent<AudioSource> ().Play ();
		cameraGameOverReference.SetActive (true);				//Se activa la camara de game over.



	}
		
	void Start ()
	{
		NotificationEvent ();				//Se llama a la funcion que contiene la suscripcion de notificaciones.
	}
}