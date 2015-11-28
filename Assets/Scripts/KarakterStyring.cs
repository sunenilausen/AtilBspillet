using UnityEngine;
using System.Collections;

public class KarakterStyring : MonoBehaviour {

	public float hastighed = 1f;          
	
	// The vector to store the direction of the player's movement.
	Vector3 bevægelse;

	// Reference to the player's rigidbody.
	Rigidbody playerRigidbody;      

	public static KarakterStyring Instance
	{
		get;
		private set;
	}

	void Awake(){
		Instance = this;
		
		// Set up references.
		playerRigidbody = GetComponent<Rigidbody>();
	}
	
	public void Bevæg(Vector3 mål) {
		// Set the movement vector based on the axis input.
		bevægelse.Set (mål.x, mål.y, 0f);

		// Normalise the movement vector and make it proportional to the speed per second.
		bevægelse = bevægelse.normalized * hastighed * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition(transform.position + bevægelse);
	}

	public Vector3 RetningTilMål(Vector3 mål)
	{
		return mål - transform.position;
	}
}
