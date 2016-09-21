using UnityEngine;
using System.Collections;

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
	private bool isNew=false;

	// Use this for initialization
	void Start () {
		gameState = GameState.Menu;
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
		if (!isNew) {
			ResourceManager.Instance.ClonePrefab ("Menu");
			isNew = true;
		}
	}
}
