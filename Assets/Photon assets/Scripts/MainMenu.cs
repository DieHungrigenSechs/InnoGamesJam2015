using UnityEngine;

public class MainMenu : Photon.MonoBehaviour
{
	[SerializeField] string multiplayerScene = "Multiplayer";
	private string serverIP = "angrybots.exitgames.com";
	private int serverPort = 5055;
	private string defaultAppId = "538dfcde-bb65-4b91-9c9d-5afef3eff2f3";
	private string roomName = "myRoom";
	private bool overridePhotonConfigFile = false;
	private string gameVersion = "v1.0";
	
	private bool photonConnectionFailed = false;
	
	int totalPlayers = 0;   // sum of players in all listed rooms
	float screenWidth = 960;
	
	
	private Vector2 scrollPos = Vector2.zero;
	public GUIStyle nullStyle;
	public GUISkin skin;
	
	void Awake()
	{
		//PhotonNetwork.logLevel = NetworkLogLevel.Full;
		
		//Connect to the main photon server. This is the only IP and port we ever need to set(!)
		if (!PhotonNetwork.connected)
			PhotonNetwork.ConnectUsingSettings(this.gameVersion); // the game's version. can be used to separate players with older and newer clients
		
		//Load name from PlayerPrefs
		PhotonNetwork.playerName = PlayerPrefs.GetString("playerName", "Guest" + Random.Range(1, 9999));
	}
	
	void OnJoinedRoom()
	{
		PhotonNetwork.isMessageQueueRunning = false;
		Application.LoadLevel(multiplayerScene);
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	
	void OnGUI()
	{
		screenWidth = Mathf.Min(Screen.width, 960);
		
		GUI.skin = skin;
		if (!PhotonNetwork.connected)
			ConnectGUI();
		else if (PhotonNetwork.room == null)
			MainGUI();
		else
			GameGUI();
	}
	
	void GameGUI()
	{
		GUI.Label(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 12, 140, 25), "Loading: " + (int)(Application.GetStreamProgressForLevel(2) * 100) + "%");
	}
	
	void RoomBrowser(int id)
	{
		//Join room by title
		GUILayout.BeginHorizontal();
		GUILayout.Label("Create room:", GUILayout.Width(150));
		roomName = GUILayout.TextField(roomName, GUILayout.Width(150));
		if (GUILayout.Button("GO", GUILayout.Height(20), GUILayout.Width(40)))
		{
			PhotonNetwork.CreateRoom(roomName, new RoomOptions() {maxPlayers = 4}, TypedLobby.Default);
		}
		GUILayout.EndHorizontal();
		
		GUILayout.Space(25);
		if (PhotonNetwork.GetRoomList().Length == 0)
		{
			GUILayout.Label("No games running at the moment.\nYou can wait or create a game yourself.");
		}
		else
		{
			//Room listing: simply call GetRoomList: no need to fetch/poll whatever!
			
			GUILayout.BeginHorizontal();
			GUILayout.Space(110);
			GUILayout.Label("Players", GUILayout.Width(110));
			GUILayout.Label("Title");
			
			GUILayout.EndHorizontal();
			
			
			scrollPos = GUILayout.BeginScrollView(scrollPos);
			foreach (RoomInfo game in PhotonNetwork.GetRoomList())
			{
				string maxP = game.playerCount + "/" + game.maxPlayers;
				if (game.maxPlayers < 1) maxP = "" + game.playerCount;
				
				GUILayout.BeginHorizontal();
				GUILayout.Space(10);
				if (GUILayout.Button("JOIN", GUILayout.Width(100)))
				{
					PhotonNetwork.JoinRoom(game.name);
				}
				GUILayout.Label("    " + maxP, GUILayout.Width(110));
				GUILayout.Label(game.name);
				
				GUILayout.EndHorizontal();
			}
			GUILayout.EndScrollView();
		}
	}
	
	void OnReceivedRoomListUpdate()
	{
		//Recalculate playercount
		totalPlayers = 0;
		RoomInfo[] roomList = PhotonNetwork.GetRoomList();
		foreach (RoomInfo game in roomList)
		{
			totalPlayers += game.playerCount;
		}
	}
	
	void MainGUI()
	{
		if (!PhotonNetwork.connected)
		{
			GUILayout.Label("Connecting...");
			return;
		}
		
		float thisW = screenWidth;
		float thisH = Mathf.Min(640, Screen.height);
		GUILayout.BeginArea(new Rect((Screen.width - thisW) / 2, (Screen.height - thisH) / 2, thisW, thisH));
		
		float leftWindowPos = Mathf.Max(0, Screen.width - screenWidth);
		
		GUI.Window(0, new Rect(leftWindowPos/2 + 200, 85, screenWidth - 200, thisH - 160), RoomBrowser, "Room listing");
		
		//Left bar
		if (PhotonNetwork.GetRoomList().Length > 0)
		{
			if (GUI.Button(new Rect(14, 150, 180, 20), "Join random"))
			{
				PhotonNetwork.JoinRandomRoom();
			}
		}
		GUI.Label(new Rect(14, 190, 180, 50), "Players: " + totalPlayers + "\nRooms: " + PhotonNetwork.GetRoomList().Length + "");
		
		GUI.Label(new Rect(14, 280, 180, 50), "Player name:");
		PhotonNetwork.playerName = GUI.TextField(new Rect(14, 310, 180, 20), PhotonNetwork.playerName);
		if (GUI.changed)
		{//Save name
			if (PhotonNetwork.playerName.Length > 13)
				PhotonNetwork.playerName = PhotonNetwork.playerName.Substring(0, 13);
			PlayerPrefs.SetString("playerName", PhotonNetwork.playerName);
		}
		
		GUILayout.EndArea();
	}
	
	void ConnectGUI()
	{
		GUILayout.BeginArea(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 400, 300));
		GUILayout.Label("Connecting to the Server..");
		if (photonConnectionFailed)
		{
			GUILayout.Label("Connection to Server Failed.");
			GUILayout.Label("Possible reasons:");
			GUILayout.Label("-No internet connection");
			GUILayout.Label("-Wrong hostname");
		}
		GUILayout.Space(10);
		
		GUILayout.BeginHorizontal();
		if (overridePhotonConfigFile)
		{
			serverIP = GUILayout.TextField(serverIP, GUILayout.Width(120));
			serverPort = int.Parse("0" + GUILayout.TextField(serverPort.ToString(), GUILayout.Width(60)));
			if (GUILayout.Button("Retry", GUILayout.Width(75)))
			{
				PhotonNetwork.ConnectToMaster(serverIP, serverPort, defaultAppId, this.gameVersion);
				photonConnectionFailed = false;
			}
		}
		else
		{
			if (GUILayout.Button("Retry", GUILayout.Width(75)))
			{
				PhotonNetwork.ConnectUsingSettings(this.gameVersion);
				photonConnectionFailed = false;
			}
		}
		
		GUILayout.EndHorizontal();
		
		GUILayout.EndArea();
	}
	
	void OnFailedToConnectToPhoton()
	{
		photonConnectionFailed = true;
	}
}