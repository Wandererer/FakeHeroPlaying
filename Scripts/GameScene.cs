using UnityEngine;
using System.Collections;
using System;

public class GameScene : MonoBehaviour {

	private static GameScene instance; //싱 글 톤 선 언 

	public static GameScene Instnace{
		get { return instance; }
		set { instance = value; }
	}

	void Awake()
	{
		instance = this;
	}

	public GameState gameState; //게임 상태 

	private bool isNew=false; //새로 시작
	private bool isNewPlay=false;//플레이 시작 

	// Use this for initialization
	void Start () {
		gameState = GameState.Menu;
		Game.Instance.gameData.FirstSetting ();
	}
	
	// Update is called once per frame
	void Update () {
		switch(gameState)
		{
		case GameState.Menu:
			MakeMenu ();
			break;

		case GameState.Shop:

			break;

		case GameState.Play:
			Debug.Log ("play");
			MakePlayUIandPrefab ();
			break;

		case GameState.Pause:

			break;

		case GameState.End:

			break;

		default:

			break;
		}
	}

	void OnGUI()
	{
		switch(gameState)
		{
		case GameState.Menu:

			break;

		case GameState.Shop:

			break;

		case GameState.Play:

			break;

		case GameState.Pause:

			break;

		case GameState.End:

			break;

		default:

			break;
		}
	}

	void MakeMenu()
	{
		Game.Instance.gameData.FirstSetting ();
		if (!isNew) {
			ResourceManager.Instance.ClonePrefab ("Menu");
			isNew = true;
		}
		CheckSaveDataIsLogIn ();
	}

	void MakePlayUIandPrefab()
	{
		if(isNew)
		{
			ResourceManager.Instance.DestroyGameObjectByName ("Menu");
			isNew = false;
		}

		if(!isNewPlay)
		{
			ResourceManager.Instance.ClonePrefab ("BackGroundManager");
			isNewPlay = true;
		}
	}


	void CheckSaveDataIsLogIn()
	{
		if(Game.Instance.gameData.SaveData.ID=="")
		{
			try{
			GameObject.FindGameObjectWithTag ("Login").SetActive (true);
			GameObject.FindGameObjectWithTag ("Start").SetActive (false);
			}
			catch(Exception e)
			{
				
			}

		}
		else
		{
			try{
			GameObject.FindGameObjectWithTag ("Login").SetActive (false);
			GameObject.FindGameObjectWithTag ("Start").SetActive (true);
			}
			catch(Exception e)
			{

			}
		}
	}


}
