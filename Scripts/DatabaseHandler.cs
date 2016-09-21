using UnityEngine;
using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data;
using MySql.Data.MySqlClient;

public class DatabaseHandler : MonoBehaviour {

	private static DatabaseHandler instance; //싱 글 톤 선 언 

	public static DatabaseHandler Instance{
		get { return instance; }
		set { instance = value;}
	}
		
	private MySqlConnection con=null; //mysql conntect 용 
	private MySqlCommand cmd=null; //커 멘 드 접 근 용 
	private MySqlDataReader reader=null; //읽 는 용  
	int i=10;
	string constr = "Security";

	public bool isNew=false;

	void Awake()
	{
		DontDestroyOnLoad (this.gameObject); //안 없 어 지 게 함 
		instance = this;


		try{
			con=new MySqlConnection(constr); // mysql 연 결 
			con.Open(); // connection open
			Debug.Log("MysqlState : "+con.State);
		}catch(Exception e)
		{
			Debug.Log (e);
		}


	}

	void OnApplicationQuit()
	{
		//게 임 종 료 시 연 결 꺼 지 게 함 
		if(con!=null)
		{
			if(con.State.ToString()!="Closed")
			{
				con.Close ();
				Debug.Log ("Mysql Connection Closed");
			}
			con.Dispose ();
		}
	}


	public void CheckIdIfNullInsertTable(string id)
	{
		//처음 로 그 인 시 아 이 디가 디 비 에 없 으 면 추 가 시 킴 
		string query = string.Empty;

		try{
			query="SELECT * FROM USERINFO where ID='"+id+"'";

			if(con.State.ToString()!="Open")
				con.Open();


			using(con)
			{
				using(cmd=new MySqlCommand(query,con))
				{
					reader=cmd.ExecuteReader();

					if(reader.HasRows)
					{
						
					}
					else
					{
						isNew=true;
					}
				}
			}
		}
		catch(Exception e)
		{
			
		}
		finally{
			if (isNew) {
				InsertNewIdInTable (id);
				isNew = false;
			}
		}
	}

	public void InsertNewIdInTable(string id)
	{
		//새 로 운 아 이 디 일 시 테 이 블 에 삽 입 
		string query = string.Empty;

		try{
			//query = "INSERT INTO USERINFO VALUES('"+id+"')";
			query ="INSERT INTO USERINFO(ID) VALUES('"+id+" ')";

			//query = "INSERT INTO USERINFO(ID) values(?ID)";
			//?해 서 넘 기 고 아 래 에 서 파 라 미 터 로 설 정 해 서 받 아 올 수 있 음ㅁ
			/*			if (con.State.ToString() != "Open")
				con.Open();*/
			//Debug.Log(query);
			if (con.State.ToString() != "Open")
				con.Open();
			
			using(con)
			{
				using (cmd = new MySqlCommand(query, con)) //해 당 query 실 행 
				{

					//MySqlParameter oParam = cmd.Parameters.Add("?ID", MySqlDbType.VarChar);
					//oParam.Value = id;
					cmd.ExecuteNonQuery();
					//Debug.Log("NONE");
				}
			}
		}
		catch(Exception e)
		{

		}
		finally
		{

		}
	}

}
