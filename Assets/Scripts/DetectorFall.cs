using UnityEngine;
using System.Collections;

public class DetectorFall : MonoBehaviour
{
	public GameObject playerReference;			//Referencia publica al Player.

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			//Se envia notificacion de que el Player ha caido.
			NotificationCenter.DefaultCenter ().PostNotification (this, "PlayerHasFallen");

			GameObject Player = GameObject.Find ("Player");		//Busca el gameobject con el nombre "Player" y lo retorna.

			playerReference.SetActive (false);

		}
	}
}
