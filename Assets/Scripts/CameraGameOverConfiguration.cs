using UnityEngine;
using System.Collections;

public class CameraGameOverConfiguration : MonoBehaviour
{
	public TextMesh ScoreFinalValueLabelReference;						//Referencia al label del puntaje final.
	public TextMesh HighScoreValueLabelReference;						//Referencia al label del puntaje mas alto.
	public Score scoreClassReference;									//Referencia a la clase Score.


	void OnEnable()												//Esta funcion se llama en el momento que el gameobject es activado.
	{
		//Se actualizan los valores de los labels finales.
		ScoreFinalValueLabelReference.text = scoreClassReference.score.ToString ();

		if (GameStateController.gameStateStaticReference.ScoreMax != null)	//Si ScoreMax es diferente de cero...
		{
			//Este valor no necesita referencia a la clase dado que gameStateReference es una variable estatica o de clase.
			HighScoreValueLabelReference.text = GameStateController.gameStateStaticReference.ScoreMax.ToString ();
		}
	}
		
	void Start ()
	{
	
	}

}
