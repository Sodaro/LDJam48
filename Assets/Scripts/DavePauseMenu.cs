using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DavePauseMenu : MonoBehaviour
{
	bool gameisPaused = false;

	[SerializeField] Button resumeButton;
	[SerializeField] FirstPersonController fpc;

	public bool GameIsPaused => gameisPaused;
	private void OnEnable()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		Time.timeScale = 0;
		fpc.enabled = false;
		//resumeButton.Select();
	}
	private void OnDisable()
	{
		Resume();
	}

	public void Resume()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
		Time.timeScale = 1;
		fpc.enabled = true;
		gameObject.SetActive(false);
		
	}

	public void ExitGame()
	{
		Application.Quit();
	}
	//public void MenuOff()
	//{
	//    Time.timeScale = 1;
	//    AudioListener.volume = 1;
	//    //m_Paused = false;
	//}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Crosspla)
    }
}
