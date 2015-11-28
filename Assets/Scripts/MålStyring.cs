using UnityEngine;
using System.Collections;

public class MålStyring : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Karakter")
			VindBanen ();
	}

	void VindBanen()
	{
		print ("du har vundet banen!");
		//måske load næste scene!
	}
}
