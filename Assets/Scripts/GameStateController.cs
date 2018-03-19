using UnityEngine;
using System.Collections;

/* El espacio de nombres System contiene clases fundamentales y clases base que definen tipos de datos de valor y de referencia usados 
 * comúnmente, eventos y controladores de eventos, interfaces, atributos y excepciones de procesamiento. */
using System;

//El espacio de nombres System.Runtime.Serialization contiene clases que se pueden utilizar para serializar y deserializar objetos
/* El espacio de nombres System.Runtime.Serialization.Formatters proporciona enumeraciones, interfaces y clases que se utilizan los
 * formateadores de serialización común. */
using System.Runtime.Serialization.Formatters;


/* El espacio de nombres System.Runtime.Serialization.Formatters.Binary contiene la clase BinaryFormatter, que se puede utilizar para 
 * serializar y deserializar los objetos en formato binario */
using System.Runtime.Serialization.Formatters.Binary;

/* El espacio de nombres System.IO contiene tipos que permiten leer y escribir en los archivos y secuencias de datos, así como tipos 
 * que proporcionan compatibilidad básica con los archivos y directorios. */
using System.IO;

public class GameStateController : MonoBehaviour
{
	public static GameStateController gameStateStaticReference;		//Variable estatica para referenciar la clase.
	public int ScoreMax = 1;									//Variable de puntuacion maxima.

	private string filePath;									//Referencia a la ruta donde se guardara el archivo serializado.

	void Awake()
	{
		//Application.persistentDataPath retorna la ruta dentro de Unity3D donde se pueden guardar archivos por parte del usuario (datos persistentes).
		filePath = Application.persistentDataPath + "/persistentData.dat";

		if (gameStateStaticReference == null)	//Si es la primera vez que se ejecuta el script..
		{		
			gameStateStaticReference = this;			//Referenciamos a la variable statica la clase actual.
			DontDestroyOnLoad (gameObject);		//El gameobject de parametro no se destruira al cambiar el nivel.

		} else if (gameStateStaticReference != this)	//Si ya existe otro GameState....
				{
					Destroy (gameObject);		//Destruimos el gameobject actual...
				}
	}
		
	public void SaveGame()
	{
		// La clase BinaryFormatter Serializa y deserializa un objeto o todo un grafo de objetos conectados, en formato binario.
		//El objeto BinaryFormatter serializara la instancia de la clase SaveData.
		BinaryFormatter binaryFormatterReference = new BinaryFormatter ();

		//La clase FileStream proporciona un "Stream" para un archivo, lo que permite operaciones de lectura y escritura sincrónica y asincrónica.
		//La clase Stream proporciona una vista genérica de una secuencia de bytes. Esta es una clase abstracta.
		//File.Create crea o sobrescribe un archivo en la ruta de acceso especificada.
		FileStream fileStreamReference =  File.Create(filePath);

		SaveData saveData = new SaveData ();		//Se crea una instancia de la clase de los datos que se guardaran.
		saveData.ScoreMaxSave = ScoreMax;			//Se asigna el valor de ScoreMax a la variable de instacia que contendra el score a guardar.

		//Se serializa el archivo SaveData y se archiva en la ruta, a traves del string fileStreamReference.
		binaryFormatterReference.Serialize (fileStreamReference, saveData);

		fileStreamReference.Close();					//Se cierra el string fileStreamReference.

	}

	public  void LoadGame()
	{
		if(File.Exists(filePath))					//Si el archivo existe en la direccion dada...
		{
				
			BinaryFormatter binaryFormatterReference = new BinaryFormatter ();
			FileStream fileStreamReference =  File.Open(filePath, FileMode.Open);		//Abre un archivo para entrada o salida.

			//Se deserializa el archivo y se asigna a saveData.
			//Se realiza casting a la clase SaveData.
			SaveData saveData = (SaveData) binaryFormatterReference.Deserialize(fileStreamReference);

			ScoreMax = saveData.ScoreMaxSave;								// Se actualiza la puntuacion maxima.
			fileStreamReference.Close();

		} else
			{
				ScoreMax = 0;
			}
	}
		
	void Start ()
	{
		LoadGame ();			//Carga el estado del juego, en este caso el puntaje.
	
	}
}

/* La serialización es el proceso de convertir un objeto en una secuencia de bytes para almacenar el objeto o transmitirlo a memoria, 
 * una base de datos, o en un archivo. Su propósito principal es guardar el estado de un objeto para poder crearlo de nuevo cuando se necesita.
 * El proceso inverso se denomina deserialización. */

[Serializable]
class SaveData
{
	public int ScoreMaxSave;				//Variable publica de puntuacion maxima.


	//No se asigna ningun constructor.

//	public SaveData(int ScoreMax)		//Constructor de la clase.
//	{
//		this.ScoreMax = ScoreMax;
//	
//	}
}