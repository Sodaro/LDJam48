using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CrystalScript : Interactable
{
	[SerializeField] ToggleableObject[] objectsToToggle;
    AudioSource audioSource;
	private void Awake()
	{
        audioSource = GetComponent<AudioSource>();
        GetComponent<Renderer>().sharedMaterial.DisableKeyword("_EMISSION");
    }

	public override void Interact()
	{
        audioSource.PlayOneShot(audioSource.clip);
        Renderer renderer = GetComponent<Renderer>();
        if (renderer.sharedMaterial.IsKeywordEnabled("_EMISSION"))
		{
            renderer.sharedMaterial.DisableKeyword("_EMISSION");
            //renderer.material.SetColor("_EmissionColor", Color.white);
        }
        else
            renderer.sharedMaterial.EnableKeyword("_EMISSION");

        foreach (var toggleObj in objectsToToggle)
            toggleObj.Toggle();
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
