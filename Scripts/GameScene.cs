using UnityEngine;
using System.Collections;

public class GameScene : MonoBehaviour {

	private static GameScene instance;

	public static GameScene Instnace{
		get { return instance; }
		set { instance = value; }
	}

	void Awake()
	{
		instance = this;
	}

	public GameState gameState;
	private 

	// Use this for initialization
	void Start () {
		gameState = GameState.Menu;
	}
	
	// Update is called once per frame
	void Update () {
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
}
