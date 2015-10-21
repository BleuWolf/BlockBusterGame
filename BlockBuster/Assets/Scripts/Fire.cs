using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
	
	public Rigidbody SpherePrefab;
	public Transform barrelEnd;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Use this for initialization
	void Update ()
	{
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
			if (fingerCount > 0){
				Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
				Vector2 touchPos = new Vector2(worldPoint .x, worldPoint.y);
				transform.LookAt(touchPos);
				
				Rigidbody rocketInstance;
				rocketInstance = Instantiate(SpherePrefab, touchPos, Quaternion.identity) as Rigidbody;
				rocketInstance.AddForce(barrelEnd.forward * 7000);
				
			}
		}
	}
}