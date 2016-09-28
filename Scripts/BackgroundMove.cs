using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {

	private Vector3 target=new Vector3(-3548f,0,0); //move position
	private float speed=100f; //move speed;

	public void MoveLeft()
	{
		TransportToRightObject ();
		transform.localPosition = Vector3.MoveTowards (transform.localPosition, target, speed * Time.deltaTime);
	}

	void TransportToRightObject()  //move postition +4190 for continuous look
	{
		if (transform.localPosition.x <= -3200f)
			transform.localPosition = new Vector3 (transform.localPosition.x + 6616f, 0, 0);
	}
}
