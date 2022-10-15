using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : Singleton<CheckpointManager>
{
    //[SerializeField] FirstPersonController player;
	[SerializeField] GameObject player;
	FirstPersonController fpc;
    protected CheckpointManager() { }
    [SerializeField] private Transform activeCheckpoint;
	//private List<Transform> checkPoints = new List<Transform>();

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		fpc = player.GetComponent<FirstPersonController>();
	}

	public void ActivateCheckpoint(Transform checkpoint)
	{
        activeCheckpoint = checkpoint;
	}

    public void ResetPlayer()
	{
		fpc.ToggleController();
		player.transform.position = activeCheckpoint.position;
		fpc.ToggleController();
		//player.ResetMoveDirection();
	}
}
