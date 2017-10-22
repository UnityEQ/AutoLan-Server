using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
 
public class NetDiscovery : NetworkDiscovery {
 
    public NetDiscovery()
    {
	}

	void Start()
	{
		Initialize();
		StartAsServer();
		Debug.Log("START");
	}
	
	public override void OnReceivedBroadcast(string fromAddress, string data)
	{
		base.OnReceivedBroadcast(fromAddress, data);
		Debug.Log("fromAddress: " + fromAddress);
		Debug.Log("data: " + data);
	}
}