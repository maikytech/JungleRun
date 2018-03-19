using UnityEngine;
using System.Collections;

public class ControlCam : MonoBehaviour
{
	public Transform playerTransformReference;		//Referencia al Transform del Player.
	public float distancePlayer;					//Distancia que debemos sumar a la posicion x de la camara para acomodar el Player.

	void FollowPlayer2D()							//Configura la camara para seguir el Player.
	{
		//Cambiamos la componente x de la camara por la del Player.
		transform.position = new Vector3 ((playerTransformReference.position.x + distancePlayer), transform.position.y, transform.position.z);
	}
		
	void Update ()
	{
		FollowPlayer2D ();		//Se llama a la funcion que configura la camara para seguir el player.
	}
}
