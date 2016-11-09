using UnityEngine;
using System.Collections;
using System;

public class GameScene : MonoBehaviour {

	private static GameScene instance; //싱 글 톤 선 언 

	private Vector3 startPos, loginPos;
	private Vector3 startNewPos,loginNewPos;

	private GameObject loginButton, startButton;

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
			//Debug.Log ("play");
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
		Game.Instance.gameData.FirstSetting ();//저 장 데 이 터 가 저 옴 
		if (!isNew) {
			//새 로 시 작 이 아 닐  
			ResourceManager.Instance.ClonePrefab ("Menu");
			isNew = true;
			SetButtonOriginalPoseandSetButtonObject ();
		}
		CheckSaveDataIsLogIn ();
	}

	void SetButtonOriginalPoseandSetButtonObject()
	{
		loginButton = GameObject.Find ("FacebookLogin");
		loginPos = loginButton.GetComponent<Transform> ().localPosition;
		loginNewPos = new Vector3 (2500f, loginPos.y, 0);

		startButton=GameObject.Find ("GameStart");
		startPos = startButton.GetComponent<Transform> ().localPosition;
		startNewPos = new Vector3 (2500f, startPos.y, 0);
	}

	void MakePlayUIandPrefab()
	{
		//게 임 이 시 작 될 경 우 메 뉴 삭 제 하 고 플 레 이 용 생 
		if(isNew)
		{//게 임 시 작 일 경 우 
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
		//SetActive를 꺼 놓은 오 브 젝 트 들 은 에 러 가 발 생 함 
		if(Game.Instance.gameData.SaveData.ID=="")
		{
			ButtonAppearOrDissapearForLoginButton (loginPos);
			ButtonAppearOrDissapearForStartButton (startNewPos);


		}
		else
		{
			ButtonAppearOrDissapearForLoginButton (loginNewPos);
			ButtonAppearOrDissapearForStartButton (startPos);
		}
	}

	private void ButtonAppearOrDissapearForLoginButton(Vector3 newPos)
	{
		loginButton.GetComponent<Transform> ().localPosition = newPos;
	}

	private void ButtonAppearOrDissapearForStartButton(Vector3 newPos)
	{
		startButton.GetComponent<Transform> ().localPosition = newPos;
	}




}
