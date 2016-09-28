using UnityEngine;
using System.Collections;

public class InternalSaveData : MonoBehaviour {

	string userID; //로 그 인 확 인 용 아 이 디 null 아 닐 시 facebook 로 그 인 UI 안 보 이 게 함 

	public string ID{
		get { return userID; }
		set { userID = value; }
	}
}
