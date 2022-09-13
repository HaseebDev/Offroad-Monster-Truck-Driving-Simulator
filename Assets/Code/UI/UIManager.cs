using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private List<UIScreen> UI_LIST;

	public SCREEN_NAME CurrentScreen{ get; set;}
	public SCREEN_NAME LastScreen{ get; set;}

	// Use this for initialization
	void Awake ()
	{
		GameManager.UI = this;
		CurrentScreen = SCREEN_NAME.MAIN_MENU;
		LastScreen = SCREEN_NAME.MAIN_MENU;
	}

	void Start()
	{
		if (Application.loadedLevel == 1) {
			GameManager.UI.Show (SCREEN_NAME.MAIN_MENU);
		}
	}
	
	public void Show(SCREEN_NAME sName)
	{
		LastScreen = CurrentScreen;
		UIScreen screen = UI_LIST.Find (s => s.Name == sName);
			CurrentScreen = screen.Name;
		if(UI_LIST.Find (s => s.Name == LastScreen) != null)
			UI_LIST.Find (s => s.Name == LastScreen).HideScreen();
		screen.gameObject.SetActive (true);

	}


}


public enum SCREEN_NAME
{
	MAIN_MENU,
	SELECTION_MENU,
	GAME_PLAY,
	PAUSE,
	GAME_OVER,
	LEVEL_COMPLETE,
	LEVEL_SELECTION,
	SETTINGS,
	LOADING,
	MODE_SELECTION
}