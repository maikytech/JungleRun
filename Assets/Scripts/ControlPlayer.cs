using UnityEngine;
using System.Collections;

public class ControlPlayer : MonoBehaviour
{
	public float jumpForce;							//Magnitud de la fuerza en el salto del Player.
	public Transform GroundedReference;				//Referencia al componente Transform del objeto Grounded.
	public float radioGrounded;						//Radio que tendra la deteccion a traves del objeto Grounded.
	public LayerMask layerBlocks;					//Referencia al layer de los bloques.
	public Rigidbody2D playerRigidbodyReference;	//Referencia al Rigidbody del Player.
	public Animator animatorReference;				//Referencia al componente animator del Player.
	public float speedRunner;						//Velocidad del player cuando corre.

	private bool grounded;							//Variable que evalua si el Player se encuentra tocando el suelo.
	private bool doubleJump;						//Variable que evualua si se realizo un doble salto.
	private bool isRunning;							//Variable que evalua si el personaje esta corriendo.

	void StartGame()
	{
		isRunning = false;
	}
		
	void Run()
	{
		if (isRunning)
		{
			//Cambiamos la velocidad del player.
			playerRigidbodyReference.velocity = new Vector2 (speedRunner, playerRigidbodyReference.velocity.y);

			//Seteamos la variable de disparo SpeedPlayer para que comience la animacion "Run".
			animatorReference.SetFloat ("SpeedPlayer", playerRigidbodyReference.velocity.x);
		}
	}

	void ControlJump()
	{
		if (Input.GetMouseButtonDown (0))			//Si se hace click o se toca la pantalla...
		{		
			if (isRunning)					//Si el player esta corriendo...
			{							
				//Si se oprime el boton izquierdo del raton y el Player esta tocando el suelo o la variable doubleJump esta en false...
				if (grounded || !doubleJump)
				{

					GetComponent<AudioSource> ().Play ();		//Sonara el audio configurado en el AudioSource.

					/* En este caso no se aplica una fuerza sino que se modifica la velocidad del Player, para evitar el efecto que tendria al
			 			* realizar un doble salto cuando el Player esta cayendo. */
					playerRigidbodyReference.velocity = new Vector2 (playerRigidbodyReference.velocity.x, jumpForce);

					if (!doubleJump && !grounded)		//Si doubleJump es falsa y aun el Player no toca el suelo.	
					{ 	
						doubleJump = true;
					}
				}
			}
			else
			{
				isRunning = true;

				//Notificamos al metodo PlayerBeginToRun que el personaje comenzo a correr(isRunning = true).
				NotificationCenter.DefaultCenter ().PostNotification (this, "PlayerBeginToRun");
			}
		}
	}

	void GroundedDetector ()
	{
		//OverLapCircle permite detectar si un objeto colisiona con otro que tenga un Layer especifico.
		grounded = Physics2D.OverlapCircle (GroundedReference.position, radioGrounded, layerBlocks);

		animatorReference.SetBool ("isGrounded", grounded);		//Setea la variable isGrounded del componente Animator del Player.

		if (grounded)				//Si el Player esta en el suelo....
		{
			doubleJump = false;			//Con doubleJump en false el Player podra volver a realizar un doble salto.
		}
	}

	void Awake()
	{

	}
		
	void Start ()
	{
		StartGame ();
	}
	

	void Update ()
	{
		ControlJump ();
	}

	void FixedUpdate()
	{
		GroundedDetector ();
		Run ();
	}

	void Reset()
	{

	}
}
