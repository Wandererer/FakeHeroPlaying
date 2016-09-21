using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {

	private Vector3 target=new Vector3(-2048f,0,0); //move position
	private float speed=100f; //move speed;

	public void MoveLeft()
	{
		TransportToRightObject ();
		transform.localPosition = Vector3.MoveTowards (transform.localPosition, target, speed * Time.deltaTime);
	}

	void TransportToRightObject()  //move postition +4190 for continuous look
	{
		if (transform.localPosition.x <= -2048f)
			transform.localPosition = new Vector3 (transform.localPosition.x + 4190f, 0, 0);
	}
}
