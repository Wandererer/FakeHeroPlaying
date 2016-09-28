using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Xml;
using System.Text;

public class SaveData : MonoBehaviour {
	
	InternalSaveData m_saveData=new InternalSaveData(); //세 이 브 용 선 언 

	public void FirstSetting()
	{
		m_saveData = LoadData ();
	}

	public InternalSaveData saveData
	{
		get { return m_saveData; }
	}

	public void SaveGameData(InternalSaveData data)
	{
		SaveBinaryFormat ("GameSaveData", SaveXml (data));
		m_saveData = data;
	}

	public InternalSaveData LoadData()
	{
		byte[] loadObject = (byte[])LoadBinaryFormat ("GameSaveData"); //해 당 데 이 터 가 져 옴 
		if(loadObject==null)
		{ //없 으 면 초 기 화 
			InternalSaveData data = new InternalSaveData ();
			data.ID="";

			return data;
		}
		//있 으 면 로 드 
		return LoadXml (loadObject);
	}

	byte[] SaveXml(InternalSaveData data)
	{
		//xml 저 장 용 
		XmlDocument loadXmlDoc = new XmlDocument (); 
		XmlElement rootElement = loadXmlDoc.CreateElement ("ROOT"); //루 트 생 성

		rootElement.SetAttribute ("ID", data.ID.ToString ());

		loadXmlDoc.AppendChild (rootElement);

		return Encoding.Default.GetBytes (loadXmlDoc.OuterXml);
	}

	InternalSaveData LoadXml(byte[] loadData)
	{
		//xml load용
		InternalSaveData saveData=new InternalSaveData();

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


	public void SaveIdData(string UserId)
	{
		//id 정 보 저 장 
		InternalSaveData saveData = LoadData ();
		saveData.ID = UserId;
		SaveGameData (saveData);
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

}
