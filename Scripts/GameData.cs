using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Xml;
using System.Text;

public class GameData  {

	GameSaveData saveData=new GameSaveData();

	public void FistSetting()
	{
		saveData = LoadGameData ();
	}

	public void SaveGameData(GameSaveData data)
	{
		SaveBinaryFormat ("GameSaveData", SaveXml (data));
		saveData = data;
	}

	public GameSaveData SaveData
	{
		get { return saveData; }
	}

	public GameSaveData LoadGameData()
	{
		byte[] loadObject = (byte[])LoadBinaryFormat ("GameSaveData"); //해 당 데 이 터 가 져 옴 
		if(loadObject==null)
		{ //없 으 면 초 기 화 
			GameSaveData data = new GameSaveData ();
			data.ID="";

			return data;
		}
		//있 으 면 로 드 
		return LoadXml (loadObject);
	}

	byte[] SaveXml(GameSaveData data)
	{
		//xml 저 장 용 
		XmlDocument loadXmlDoc = new XmlDocument (); 
		XmlElement rootElement = loadXmlDoc.CreateElement ("ROOT"); //루 트 생 성

		rootElement.SetAttribute ("ID", data.ID.ToString ());

		loadXmlDoc.AppendChild (rootElement);

		return Encoding.Default.GetBytes (loadXmlDoc.OuterXml);
	}

	GameSaveData LoadXml(byte[] loadData)
	{
		//xml load용
		GameSaveData saveData=new GameSaveData();

		MemoryStream m_stream = new MemoryStream (loadData);
		XmlDocument loadXmlDoc = new XmlDocument ();
		loadXmlDoc.Load (m_stream);//메 모 리 스 트 림 에 서 가 져 옴 

		XmlNode rootNode = loadXmlDoc.SelectSingleNode ("ROOT"); //ROOT 라 는 노 드 에 있 는 거 가 져 옴 

		for(int i=0;i<rootNode.Attributes.Count;i++)
		{
			String temp = null;

			XmlAttribute attr = rootNode.Attributes [i];

			switch(attr.Name)
			{
			case "ID":
				saveData.ID = attr.Value;
				break;
			}
		}

		return saveData;
	}


	public void SaveBinaryFormat(string key, object data)
	{
		// 저 장 용 
		BinaryFormatter b= new BinaryFormatter(); // 바이 너 리 포 맷 을 이 용 객 체 그 래 프 를 스 트 림 으 로 직 렬 
		MemoryStream m = new MemoryStream ();
		b.Serialize (m, data);
		PlayerPrefs.SetString (key, Convert.ToBase64String (m.GetBuffer ()));
		return;
	}

	public  object LoadBinaryFormat(string key)
	{
		// 로 드 용 
		string data = PlayerPrefs.GetString(key);
		if(data==null || data=="")
		{
			return null;
		}

		BinaryFormatter b= new BinaryFormatter();
		MemoryStream m = new MemoryStream (Convert.FromBase64String (data));
		return b.Deserialize (m);
	}

	public void SaveIdData(string UserId)
	{
		//id 정 보 저 장 
		GameSaveData saveData = LoadGameData ();
		saveData.ID = UserId;
		SaveGameData (saveData);
	}

}
