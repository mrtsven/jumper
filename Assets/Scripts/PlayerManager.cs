﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

	#region Singleton

	public static PlayerManager instance;

	void Awake ()
	{
		instance = this;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	#endregion

	public GameObject player;

}
