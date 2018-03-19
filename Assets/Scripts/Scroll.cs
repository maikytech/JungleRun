using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour
{
	public float speedScroll;				//Rapidez del scroll.
	public bool isScrollingMainScene;		//Variable que controla el scroll en MainScene;

	private float beginScroll;				//Tiempo en que comienza el scroll.
	private bool isScrolling;				//Variable que indica si el scroll se encuentra en play.


	void ScrollMovement()
	{
		//Se accede al componente Renderer, a su vez al componente material y a su vez a las caracteistcas de la textura.
		//Se asigna un nuevo vector que nos dara el movimiento.
		//((Time.deltaTime - beginScroll) * speedScroll) % 1 evita el salto del inicio y que el scroll empiece a moverse aleatoriamente.
		gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (((Time.time - beginScroll) * speedScroll) % 1, 0);
	}

	void PlayerBeginToRun()		//Recibe la notificacion para activarse.
	{
		beginScroll = Time.time;
		isScrolling = true;
	}

	void PlayerHasFallen()				//Configuracion si el jugador ha caido.
	{
		isScrolling = false;			//Se detiene el scroll.

	}

	void NotificationEvent()	//Se suscribe al evento de la notificacion.
	{
		NotificationCenter.DefaultCenter ().AddObserver (this, "PlayerBeginToRun");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PlayerHasFallen");
	}

	void ScrollMainScene()			//Funcion que configura el scroll en la escena de inicio.
	{
		if (isScrollingMainScene)	
		{
			PlayerBeginToRun ();	//Se hace una simulacion de llamado a este metodo, el cual iniciara el scroll.
		}
	}

	void StartScroll ()					//Condiciones iniciales de la clase.
	{
		beginScroll = 0;					//Set de beginScroll.		
		isScrolling = false;				//Set de isScrolling.
	}

	void Start ()
	{
		StartScroll ();					//Funcion condiciones iniciales.
		NotificationEvent ();			//Funcion del evento de Notificacion.
		ScrollMainScene();				//Funcion de scroll en pantalla de inicio.

	}

	void Update ()
	{
		if(isScrolling)				//Si isScrolling es true...
		{
			ScrollMovement ();		//Se inicia el scroll.
		}
	}
}
