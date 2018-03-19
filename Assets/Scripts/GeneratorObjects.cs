using UnityEngine;
using System.Collections;

public class GeneratorObjects : MonoBehaviour
{
	public GameObject[] arrayObjectsCreated;		//Array de objectos que se van a crear.
	public GameObject orangeReference;				//Referencia al game object de la naranja
	public float timeMin;							//Tiempo minimo entre la creacion de un objeto y el siguiente.
	public float timeMax;							//Tiempo maximo entre la creacion de un objeto y el siguiente.

	private bool isPlayerFallen;					//Variable bool que indica si el Player ha caido.

	void  StartGeneratorObjects()		//Condiciones iniciales de la clase.
	{
		isPlayerFallen = false;			//Set de la variable isPlayerFallen.
	}
		
//	void makeObjects()
//	{
//		//La funcion Instantiate() instancia los objetos que tengamos en el array.
//		//Se tomara un objecto aleatorio del array, cuyo subindice estara entre cero y el ultimo objeto de la lista.
//		//Quaternion.identity es la rotacion original del objeto.
//		Instantiate(arrayObjectsCreated[Random.Range(0, arrayObjectsCreated.Length)], transform.position, Quaternion.identity);
//
//		//A traves del metodo Invoke, hacemos que el metodo makeObjects se llame a si mismo, un tiempo aleatorio.
//		Invoke ("makeObjects", Random.Range (timeMin, timeMax));
//	}

	void newMakeObjects()
	{
		if(!isPlayerFallen)		//Si el Player aun no ha caido...
		{
			//Se crea el objeto de manera aleatoria.
			GameObject objectCreated = arrayObjectsCreated [Random.Range (0, arrayObjectsCreated.Length)];

			Instantiate (objectCreated, transform.position, Quaternion.identity);	//Se instancia el objeto.

			//Se invoca el metodo newMakeObjects() en un intervalo de tiempo aleatorio.
			Invoke("newMakeObjects", Random.Range(timeMin, timeMax));

			//Se accede a los limites, punto medio  y tamaño de los bloques, lo asignamos a la variable sizeObjectCreated.
			float sizeObjectCreated = objectCreated.GetComponent<Collider2D>().GetComponent<Renderer>().bounds.size.x / 2;

			//Creamos la naranja encima del bloque de manera aleatoria, solo si el aleatorio es igual a uno.
			if (Random.Range (0, 3) == 1)
			{
				/* Random.Range (transform.position.x - sizeObjectCreated, transform.position.x + sizeObjectCreated) es el rango aleatorio en x
			 	* donde aparecera la manzana, sizeObjectCreated equivale al tamaño del bloque creado  */

				// transform.position.y + 1 es la posicion en el eje "y" donde aparece la naranja, una unidad por encima.
				Instantiate (orangeReference, new Vector3 (Random.Range (transform.position.x - sizeObjectCreated, transform.position.x + sizeObjectCreated), transform.position.y + 1), Quaternion.identity);
			}
		}
	}

	void PlayerBeginToRun()
	{
		newMakeObjects ();			//Se comienzan a generar los bloques.
	}

	void PlayerHasFallen ()
	{
		isPlayerFallen = true;		//El Player ha caido.
	}

	void NotificationEvent()
	{
		//GeneratorObjects se suscribe a la notificacion.
		NotificationCenter.DefaultCenter ().AddObserver (this, "PlayerBeginToRun");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PlayerHasFallen");
	}

	void Start ()
	{
		//makeObjects ();	//Este metodo se llamara a traves de la clase NotificationCenter.

		StartGeneratorObjects ();
		NotificationEvent ();
	}
}
