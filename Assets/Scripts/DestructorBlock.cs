using UnityEngine;
using System.Collections;

public class DestructorBlock : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collider)		//Detecta la colision con un collider 2D.
	{
		Destroy (collider.gameObject);				//Destruye el game object que choca.
	}
}