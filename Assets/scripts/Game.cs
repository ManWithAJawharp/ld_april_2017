﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
	None=0,
	Main=1,
	Game=2,
	Score=3
};

public enum Score
{
	CatPerson,
	DogPerson,
	Box,
	Yarn,
	Fish
}

public class Game : MonoBehaviour
{
	[SerializeField]
	private bool load_scene = true;

	private static Scenes current_scene = Scenes.None;

	private static int[] score_values;
	private static int[] scores;

	protected void Awake()
	{
		SceneManager.sceneLoaded += SceneManager_sceneLoaded;

		if (load_scene)
		{
			ChangeScene (Scenes.Main);
		}

		score_values = new int[] {100, 20, 30, 40, 60};
		scores = new int[5];
		Debug.Log(scores);
	}

	public static void ChangeScene(Scenes new_scene)
	{
		Debug.Log ("Change scene from " + current_scene + " to " + new_scene);

		if ((int)current_scene > 0) 
		{
			Debug.Log ("Unload " + current_scene);
			SceneManager.UnloadSceneAsync((int)current_scene);
		}

		current_scene = new_scene;

		SceneManager.LoadSceneAsync((int)current_scene, LoadSceneMode.Additive);
	}

	public static void AddScore(Score type)
	{
		Debug.Log("Found a " + type.ToString() + "!");
		scores[(int)type]++;
	}

	private void SceneManager_sceneLoaded (Scene scene, LoadSceneMode loadSceneMode)
	{
		
	}
}
