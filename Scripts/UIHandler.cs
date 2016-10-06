using UnityEngine;
using System.Collections;

public class UIHandler : MonoBehaviour {

	public void OnClickFacebookLoginButton()
	{
		FacebookManager.Instance.LogIn ();
	}

	public void OnClickGameStartButton()
	{
		FacebookManager.Instance.CheckID ();
		Game.Instance.gameData.FirstSetting ();
		if(FacebookManager.Instance.ID==Game.Instance.gameData.SaveData.ID)
		{
			GameScene.Instnace.gameState = GameState.Play;
		}
	}
}
