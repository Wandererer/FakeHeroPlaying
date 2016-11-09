using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class FacebookManager : MonoBehaviour {

	private static FacebookManager instance; //싱글톤 선언 

	public static FacebookManager Instance
	{
		get { return instance; }
		set { instance=value; }
	}

	public string ID {
		get;
		set;
	}



	void Awake()
	{
		instance = this;
		FB.Init (InitCallBack);
	}

	void Start()
	{
		/*ServerDBHandler.Instance.LogIn ("dlawkrbs@hanmail.net");*/
	}


	public void LogIn()
	{
		//facebook 로 그 인 
		if(!FB.IsLoggedIn)
		{
			FB.LogInWithReadPermissions (new List<string> { "public_profile","email" }, LogInCallBack);
		}
		FB.LogInWithReadPermissions (new List<string> { "public_profile","email" }, LogInCallBack);
		//ServerDBHandler.Instance.LogIn ("dlawkrbs@hanmail.net");

		//FB.API ("me?fields=email", HttpMethod.GET, NameCallBack);

	}

	public void CheckID()
	{
		FB.LogInWithReadPermissions (new List<string> { "public_profile","email" }, CheckIDCallBack);
	}

	void InitCallBack()
	{		

		Debug.Log ("Facebook has been init");
	}

	void CheckIDCallBack(ILoginResult result)
	{
		if(result.Error==null)
		{
			FB.API ("/me?fields=email", HttpMethod.GET, EmailCallBackForCheckID);
		}
	}

	void LogInCallBack(ILoginResult result)
	{
		//로 그 인 결 과 에 따 라 실 행 
		var perms = new List<string>(){"public_profile", "email"}; //허 가 리 스 트 가 져 옴 
		var aToken = Facebook.Unity.AccessToken.CurrentAccessToken; //토 큰 확 인 
		foreach (string perm in aToken.Permissions) {
			Debug.Log(perm);//접 근 가 능 상 태 면 출 력 해 줌 
		}
		//GetConnection ();
		if(result.Error==null)
		{//에 러 가 아 니 면 
			Debug.Log ("FB has Logged in");	
			FB.API ("/me?fields=email", HttpMethod.GET, NameCallBack);
		}
		else
		{
			Debug.Log ("Error doing login: "+result.Error);
		}
	}
		 
	void NameCallBack(IGraphResult result)
	{
		//이 메 일 받 아 온 결 과 
		Dictionary<string,object> profile = (Dictionary<string,object>)result.ResultDictionary;
		//Debug.Log (profile ["email"].ToString ());
		//ServerDBHandler.Instance.LogIn (profile ["email"].ToString());

		StartCoroutine (ServerDBHandler.Instance.LogIn (profile ["email"].ToString ()));
		//DatabaseHandler.Instance.CheckIdIfNullInsertTable (profile ["email"].ToString ());
	
	
		//GameObject.Find ("EMAIL").GetComponent<UILabel> ().text = profile ["email"].ToString ();

		//name.GetComponent<UILabel> ().text = profile ["first_name"].ToString();
	}

	void EmailCallBackForCheckID(IGraphResult result)
	{
		Dictionary<string,object> profile = (Dictionary<string,object>)result.ResultDictionary;
		this.ID = profile ["email"].ToString ();//
	}
}
