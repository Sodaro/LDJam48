using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[SerializeField] GameEvent interactionEvent;

	public virtual void Interact()
	{
		interactionEvent.Invoke();
	}
}
