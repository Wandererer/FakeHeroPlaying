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

		var perms = new List<string>(){"public_profile", "email"};
		var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
		foreach (string perm in aToken.Permissions) {
			Debug.Log(perm);
		}
		//GetConnection ();
		if(result.Error==null)
		{
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
		Dictionary<string,object> profile = (Dictionary<string,object>)result.ResultDictionary;
		Debug.Log (profile ["email"].ToString ());
		//ServerDBHandler.Instance.LogIn (profile ["email"].ToString());

		StartCoroutine (ServerDBHandler.Instance.LogIn (profile ["email"].ToString ()));
		//DatabaseHandler.Instance.CheckIdIfNullInsertTable (profile ["email"].ToString ());
	
	
		//GameObject.Find ("EMAIL").GetComponent<UILabel> ().text = profile ["email"].ToString ();

		//name.GetComponent<UILabel> ().text = profile ["first_name"].ToString();
	}

	void EmailCallBackForCheckID(IGraphResult result)
	{
		Dictionary<string,object> profile = (Dictionary<string,object>)result.ResultDictionary;
		this.ID = profile ["email"].ToString ();
	}
}
