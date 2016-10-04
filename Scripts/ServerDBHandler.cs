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

	public IEnumerator LogIn(string userID)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("USERIDPOST", userID);

		WWW www= new WWW(LoginPhp,form);

		//TODO : 데 이 터 받 아 올 시 로 딩 창? 같 은 

		yield return www; //데 이 터 기 다 림 

		//TODO : 가 져 온 이 후 로 딩 창 삭 제
	}
}
