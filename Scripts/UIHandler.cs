using UnityEngine;
using System.Collections;

public class UIHandler : MonoBehaviour {

	public void OnClickFacebookLoginButton()
	{
		FacebookManager.Instance.LogIn ();
	}
}
