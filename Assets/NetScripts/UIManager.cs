using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {
	public GameObject StartServerButton;
	public GameObject StopServerButton;
	public GameObject ShowPlayerPanel;
	public GameObject HidePlayerPanel;
	public GameObject OfflinePanel;
	public GameObject OnlinePanel;
	public GameObject PlayerPanel;
	public GameObject netManager;
	public Dropdown PlayerCameras;
	public static UIManager Instance;
	//public Dictionary<int, List<GameObject>> cameraDict = new Dictionary<int,List<GameObject>>();

	void OnDisconnectedFromServer(NetworkDisconnection info) {
        Debug.Log("Disconnected from server: " + info);
    }
	
	void Awake()
	{
		if(Instance)
			DestroyImmediate(gameObject);
		else
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
	}
	
	void Update()
	{
		if(!NetworkTransport.IsBroadcastDiscoveryRunning())
		{
			netManager.GetComponent<NetDiscovery>().Initialize();
			netManager.GetComponent<NetDiscovery>().StartAsServer();
		}
	}
	
	void Start()
	{
		setupBtn();
	}
	void OnStartServer()
	{
		
	}
	
	public void setupBtn()
    {
        //StartServerButton.GetComponent<Button>().onClick.AddListener(delegate { StartServerButtonClicked(); });
		//StopServerButton.GetComponent<Button>().onClick.AddListener(delegate { StopServerButtonClicked(); });
		//ShowPlayerPanel.GetComponent<Button>().onClick.AddListener(delegate { ShowPlayerPanelClicked(); });
		//HidePlayerPanel.GetComponent<Button>().onClick.AddListener(delegate { HidePlayerPanelClicked(); });
    }
       
    public void StartServerButtonClicked()
    {
        NetworkManager.singleton.StartHost();
		OnlinePanel.SetActive(true);
		OfflinePanel.SetActive(false);
    }
	public void StopServerButtonClicked()
    {
        NetworkManager.singleton.StopHost();
		OnlinePanel.SetActive(false);
		OfflinePanel.SetActive(true);
    }
	
	public void StartBroadcastClicked()
    {
    }	

	public void ShowPlayerPanelClicked()
    {
		ShowPlayerPanel.SetActive(false);
		HidePlayerPanel.SetActive(true);
		PlayerPanel.SetActive(true);
	}
	public void HidePlayerPanelClicked()
    {
		ShowPlayerPanel.SetActive(true);
		HidePlayerPanel.SetActive(false);
		PlayerPanel.SetActive(false);
    }

	public void PlayerCamerasClicked()
    {
		foreach(NetworkConnection n in NetworkServer.connections)
		{
			//cameraDict.Add(n.connectionId,PlayerArray.Instance.PlayerList);
			foreach (GameObject go in PlayerArray.Instance.PlayerList)
			{
//				PlayerCameras.options.Add(new Dropdown.OptionData(go.name));
			}
		}
    }		
}