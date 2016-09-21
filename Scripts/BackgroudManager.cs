using UnityEngine;
using System.Collections;

public class BackgroudManager : MonoBehaviour {

	private static BackgroudManager instance; // 싱 글 톤 선 언 

	public static BackgroudManager Instance{
		get { return instance;} 
		set { instance = value; }
	}

	public bool isPause=false; //일 시 정 지 일 경 우 멈 추 도 록 
	private BackgroundMove[] backGround; //하 위 에 background 접 근 용 


	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		backGround = transform.GetComponentsInChildren<BackgroundMove> (); //하 위 BackgroundMove 가 져 옴 
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPause)
			MoveLeftForChild ();
	}

	void MoveLeftForChild()
	{
		//하 위 자 식 들 왼 쪽 으 로 배 경 움 직 이 게 함 
		for (int i = 0; i < backGround.Length; i++) {
			backGround [i].MoveLeft ();
		}
	}

	public void PauseTrue()
	{
		isPause = true;
	}

	public void PauseFalse()
	{
		isPause = false;
	}
}
