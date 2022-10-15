using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
	[SerializeField] GameObject player;

	public void EnablePlayer()
	{
		player.GetComponent<FirstPersonController>().enabled = true;
	}
}
