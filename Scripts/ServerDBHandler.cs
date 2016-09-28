using UnityEngine;
using System.Collections;

public class ServerDBHandler : MonoBehaviour {

	private static ServerDBHandler instance;

	public static ServerDBHandler Instance{
		get{ return instance; }
		set { instance = value; }
	}

	[SerializeField]
	private string serverURL;

	private string LoginPhp;

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		LoginPhp=serverURL+"Login.php";
		//Debug.Log (LoginPhp);
	}

	public void LogIn(string userID)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("USERIDPOST", userID);

		WWW www= new WWW(LoginPhp,form);

		GameObject.Find ("EMAIL").GetComponent<UILabel> ().text = www.text;
	}
}
