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

		Debug.Log (www.text);
		IsLogInSuccess (www.text,userID);
		//TODO : 가 져 온 이 후 로 딩 창 삭 제
	}

	private void IsLogInSuccess(string text,string userID)
	{
		switch(text)
		{
		case "ALREADY":
			Game.Instance.gameData.SaveIdData (userID);
			break;

		case "SUCCESS":
			Game.Instance.gameData.SaveIdData (userID);
			break;

		case "FAIL":
			StartCoroutine (LogIn (userID)); //WARNING :무 한 루 프 빠 질 가 능 성 있 음 ...... 일 정 이 상 하 면 아 예 안 되 게 바 꿔 야 
			break;

		default:

			break;
		}
	}


}
