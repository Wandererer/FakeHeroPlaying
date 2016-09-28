using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour {

	private static ResourceManager instance; //싱 글 톤 선 언 

	public static ResourceManager Instance{
		get { return instance; }
	}

	private Dictionary<string,GameObject> prefabList = new Dictionary<string,GameObject> (); //프 리 팹 관 리 용 딕 셔 너 리 

	void Awake()
	{
		instance = this;
		LoadAllPrefab ();
	}

	public void LoadAllPrefab()
	{
		//Resources라는 폴더에 있는 Prefabs에 있는 모든걸 가져옴
		object[] temp = Resources.LoadAll ("Prefabs");
		for (int i = 0; i < temp.Length; i++) {
			GameObject t0 = (GameObject)(temp [i]);
			if (prefabList.ContainsKey (t0.name))
				continue;
			prefabList [t0.name] = t0;
		}
	}

	public GameObject ClonePrefab(string key)
	{
		//리 스 트 에 있 는 프 리 팹 가 져 옴 
		GameObject temp = null;

		if(prefabList.ContainsKey(key))
		{
			temp = (GameObject)(GameObject.Instantiate (prefabList [key]));
		}

		if(temp==null)
		{
			Debug.Log (string.Format ("ResourceManager colone is failed, [key={0}]", key));
			return null;
		}

		temp.name = key;

		return temp;
	}

	public void DestroyGameObjectByList(string[] key)
	{
		for(int i=0; i<key.Length;i++)
		{
			GameObject obj=GameObject.Find (key [i]);
			if(obj!=null)
			{
				Destroy (obj);
			}
		}
	}

	public void  DestroyGameObjectByName(string key)
	{

			GameObject obj=GameObject.Find (key);
			if(obj!=null)
			{
				Destroy (obj);
			}

	}

	public void RemoveAllPrefab()
	{
		//리 스 트 에 서 삭 제 만 약 리 스 트 안 개 수 0 이 면 아 무 짓 도 안 함 
		if (prefabList.Count == 0)
			return;
		prefabList.Clear ();
	}


}
