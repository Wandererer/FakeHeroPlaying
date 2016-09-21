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



	void Awake()
	{
		instance = this;
		FB.Init (InitCallBack);
	}

	IEnumerator Start()
	{
		WWW data = new WWW("Security");
		yield return data;
		string test = data.text;
		GameObject.Find ("EMAIL").GetComponent<UILabel> ().text = test;
		Debug.Log (test);
	}

	public void LogIn()
	{

		if(!FB.IsLoggedIn)
		{
			FB.LogInWithReadPermissions (new List<string> { "public_profile","email" }, LogInCallBack);
		}



		FB.LogInWithReadPermissions (new List<string> { "public_profile","email" }, LogInCallBack);



		//FB.API ("me?fields=email", HttpMethod.GET, NameCallBack);

	}

	void InitCallBack()
	{		

		Debug.Log ("Facebook has been init");
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

	IEnumerator GetConnection()
	{
		WWW data = new WWW("http://52.78.145.253/dbtest.php");
		yield return data;
		string test = data.text;
		GameObject.Find ("EMAIL").GetComponent<UILabel> ().text = test;
		Debug.Log (test);
	}

	void NameCallBack(IGraphResult result)
	{
		Dictionary<string,object> profile = (Dictionary<string,object>)result.ResultDictionary;
		Debug.Log (profile ["email"].ToString ());

		DatabaseHandler.Instance.CheckIdIfNullInsertTable (profile ["email"].ToString ());
		//GameObject.Find ("EMAIL").GetComponent<UILabel> ().text = profile ["email"].ToString ();

		//name.GetComponent<UILabel> ().text = profile ["first_name"].ToString();
	}
}
