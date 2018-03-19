using UnityEngine;
using System.Collections;

public class DetectorBlock : MonoBehaviour
{
	public int pointsToIncreaseInScore;		//Puntos a incrementar en el score.

	private bool hasCollided;

	void starDetectorBlock ()			//Condiciones iniciales.
	{
		hasCollided = false;

	}

	void OnCollisionEnter2D(Collision2D collision)					//Se actualiza en el FixedUpdate().
	{
		//Debug.Log (collision.contacts [0].collider.gameObject.name);	//collision.contacts [0] significa el primer contacto que realiza el Player.

		//Condicion para que se registre una sola colision y solo con las patas del pesonaje.
		if (!hasCollided && (collision.collider.gameObject.name == "LowerRightLegB" || collision.collider.gameObject.name == "LowerLeftLegB"))
		{
			/* Se envia la notificacion al metodo IncreasePoints, con tres parametros, el primero asocia la notificacion con la clase, 
			* el segundo es el nombre del metodo que recibe la notificacion, el tercero es un dato, en este caso los puntos que 
			* deben incrementarse. */

			NotificationCenter.DefaultCenter ().PostNotification (this, "IncreasePoints", pointsToIncreaseInScore);

			hasCollided = true;
		
		}
	}
		
	void Start ()
	{
		starDetectorBlock ();
	}
}