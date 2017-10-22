using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour {

	public Text poop;
	// Use this for initialization
	void Start () {
		
	}
	
	void Awake()
	{
		Application.logMessageReceived += Application_logMessageReceived;
	}
	
	private void Application_logMessageReceived(string condition, string stackTrace, LogType type)
	{
		poop.text = string.Format("{0}, {1}, {2}", condition, stackTrace, type);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
