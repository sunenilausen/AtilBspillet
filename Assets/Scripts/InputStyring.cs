using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputStyring : MonoBehaviour
{
	public bool Keyboard = true;
	private RaycastHit hit;
	private bool mouseDown = false;
	private int floorMask;

	public static InputStyring Instance
	{
		get;
		private set;
	}

	
	void Awake()
	{
		Instance = this;
		floorMask = LayerMask.GetMask("Gulv");
	}
	
	void FixedUpdate()
	{
		#if UNITY_EDITOR || UNITY_WEBPLAYER || UNITY_STANDALONE
		if (Keyboard)
			CheckKeyboard();
		else 
			CheckMouse();
		#endif
		
		#if UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8 || UNITY_BLACKBERRY
		CheckTouch();
		#endif
	}
	
	
	void Tap(Vector3 position)
	{
		Ray ray = Camera.main.ScreenPointToRay(position);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100.0F, floorMask))
		{
			//Debug.DrawLine(ray.origin, hit.point, Color.red, 10);
			KarakterStyring.Instance.Bevæg(KarakterStyring.Instance.RetningTilMål(hit.point));
		}
	}
	
	void CheckMouse()
	{
		if (Input.GetMouseButton(0) && mouseDown == false)
		{
			Click();
			mouseDown = true;
		}
		else if (Input.GetMouseButton(0))
		{
			Tap(Input.mousePosition);
		}
		else if (!Input.GetMouseButton(0))
		{
			mouseDown = false;
		}
	}
	
	void CheckTouch()
	{
		if (Input.touchCount == 1)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				Click();
			}
		}
		if (Input.touchCount > 0)
		{
			Touch touch = Input.touches[0];
			if (touch.deltaTime == 0.0)
			{
				return;
			}
			Tap(touch.position);
		}
	}

	void CheckKeyboard()
	{
		// Store the input axes.
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		
		// Move the player around the scene.
		KarakterStyring.Instance.Bevæg (new Vector3(h, v, 0));
			
	}
	
	void Click()
	{
		//do something with mouseclick
	}
}