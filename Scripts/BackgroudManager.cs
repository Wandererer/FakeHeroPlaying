using UnityEngine;
using System.Collections;

public class BackgroudManager : MonoBehaviour {

	private static BackgroudManager instance;

	public static BackgroudManager Instance{
		get { return instance;} 
		set { instance = value; }
	}

	public bool isPause=true;
	private BackgroundMove[] backGround;


	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		backGround = transform.GetComponentsInChildren<BackgroundMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isPause)
			MoveLeftForChild ();
	}

	void MoveLeftForChild()
	{
		for (int i = 0; i < backGround.Length; i++) {
			backGround [i].MoveLeft ();
		}
	}

	public void PauseTrue()
	{
		isPause = true;
	}

	public void PauseFalse()
	{
		isPause = false;
	}
}
