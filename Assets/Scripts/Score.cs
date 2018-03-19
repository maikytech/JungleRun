using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public TextMesh scoreReference;		//Referencia al Text Mesh del objecto 3D Text que contendra el marcador.
	public int score;					//Variable que contendra la puntuacion.

	void starScore()
	{
		score = 0;							//Se inicializa el score en cero.
		UpdateScore();						//Se actualiza el marcador a cero al inicio del juego.
	}
		
	void IncreasePoints(Notification notification)
	{
		//Variable que contendra los valores a incrementar, dependiendo de si es una naranja o un bloque.
		int pointsToIncrease = (int) notification.data;

		score += pointsToIncrease;		//Se suman los puntos al puntaje.
		UpdateScore();					//Actualiza el marcador.
	}

	void UpdateScore()
	{
		scoreReference.text = score.ToString();		//ToString convierte enteros a string.
	}

	void NotificationEvent()	//Se suscribe a los eventos.
	{
		NotificationCenter.DefaultCenter ().AddObserver (this, "IncreasePoints");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PlayerHasFallen");
	}

	void PlayerHasFallen ()
	{
		if (score > GameStateController.gameStateStaticReference.ScoreMax)
		{
			GameStateController.gameStateStaticReference.ScoreMax = score;	//Se actualiza la puntuacion que sera guardada.
			GameStateController.gameStateStaticReference.SaveGame ();			//Salvamos la puntuacion del Player.

		} 
	}
		
	void Start ()
	{
		starScore ();

		//Se activa la notificacion del contacto con los bloques para el incremento y guardado de puntos.
		NotificationEvent();
	}
}
