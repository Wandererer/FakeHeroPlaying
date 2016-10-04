using UnityEngine;
using System.Collections;

public class Game  {

	private static Game instance;

	public static Game Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new Game();
			}

			return instance;
		}
	}


	public GameData gameData { get; private set;}

	public Game()
	{
		gameData = new GameData ();

	}

}
