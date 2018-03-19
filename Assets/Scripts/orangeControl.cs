using UnityEngine;
using System.Collections;

public class orangeControl : MonoBehaviour
{
	public int pointsToIncreaseInScore;		//Puntos a incrementar en el score.
	public AudioClip takeOrangeClip;		//Referencia al audio cuando el personaje toma una naranja.
	public float takeOrangeClipVolume;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player")			//Condicionamos la colision con el Player.
		{
			//Enviamos la notificacion de la colision para que el metodo "IncreasePoints" sume los puntos.
			NotificationCenter.DefaultCenter ().PostNotification (this, "IncreasePoints", pointsToIncreaseInScore);

			/* PlayClipAtPoint es una funcion estatica que reproduce un Audioclip en cualquier posicion del juego, se debe ingresar como 
			 * parametros, el audioclip que se quiere reproducir, la posicion y el volumen, en este caso, se reproducira el audio takeOrangeClip
			 * en la posicion de la camara principal. */
			AudioSource.PlayClipAtPoint (takeOrangeClip, Camera.main.transform.position, takeOrangeClipVolume);
		}

		Destroy (gameObject);		//Se destruye la naranja.
	}
}