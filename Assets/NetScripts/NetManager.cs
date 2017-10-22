using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
 
public class NetManager : NetworkManager {
	public UIManager uiManager;

	public NetManager()
    {
		dontDestroyOnLoad = false;
	}
	
	//this is called when a client disconnects from server
    public override void OnServerDisconnect (NetworkConnection conn)
    {
		Debug.Log("OnServerDisconnect");
		//remove gameobjects of disconnected players
		NetworkServer.DestroyPlayersForConnection(conn);
		//clean list
		for(var i = PlayerArray.Instance.PlayerList.Count - 1; i > -1; i--)
		{
//			if (PlayerArray.Instance.PlayerList[i] == null)
//			PlayerArray.Instance.PlayerList.RemoveAt(i);
//			uiManager.PlayerCameras.options.Remove(new Dropdown.OptionData("player_" + conn.connectionId));
		}
    }
	
	public override void OnStopClient()
	{
		Debug.Log("OnStopClient");
	}

	public override void OnServerConnect(NetworkConnection conn)
	{
//		uiManager.PlayerCameras.options.Add(new Dropdown.OptionData("player_" + conn.connectionId));
	}
	
	
}