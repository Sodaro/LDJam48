using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInteraction : MonoBehaviour
{
    Camera cam;
    [SerializeField] DavePauseMenu pauseMenu;
    [SerializeField] Light lantern;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject uiPanel;

    private MagicProjectile magicProjectile;
    private GameObject magicProjectileObject;

    bool fire1, fire2, clear, interact, uiPressed, menuPressed;


    //GameO
    //[SerializeField] Transform handsTransform;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
		//      if (Input.GetKeyDown(KeyCode.T))
		//{
		//          lantern.enabled = !lantern.enabled;
		//}

		if (CrossPlatformInputManager.GetAxis("Menu") != 0)
		{
			if (!menuPressed)
			{
				if (pauseMenu.gameObject.activeInHierarchy)
					pauseMenu.gameObject.SetActive(false);
				else
					pauseMenu.gameObject.SetActive(true);
				menuPressed = true;
			}
		}
		else
			menuPressed = false;




		if (pauseMenu.GameIsPaused)
			return;

		if (CrossPlatformInputManager.GetAxis("UI") != 0)
		{
			if (!uiPressed)
			{
				uiPressed = true;
				uiPanel.SetActive(!uiPanel.activeInHierarchy);
			}
		}
		else
			uiPressed = false;

		if (uiPanel.activeInHierarchy)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
				uiPanel.SetActive(false);
		}



		if (CrossPlatformInputManager.GetAxis("Fire1") != 0)
        {
            if (!fire1)
			{
                fire1 = true;
                if (magicProjectileObject == null)
                {
                    magicProjectileObject = Instantiate(projectilePrefab, cam.transform.position + (cam.transform.forward * 2), cam.transform.rotation);
                    //magicProjectileObject.GetComponent<Rigidbody>().AddForce(cam.transform.forward * 1000);
                    magicProjectile = magicProjectileObject.GetComponent<MagicProjectile>();
                    //magicProjectile.HoldInPosition();
                    magicProjectile.Release();
                }
                else
                {
                    if (magicProjectile.IsFrozen)
                        magicProjectile.Release();
                    else
                        magicProjectile.HoldInPosition();
                }
            }
        }
        else
            fire1 = false;


        //
        if (CrossPlatformInputManager.GetAxis("Fire2") != 0)
        {
            if (!fire2)
			{
                fire2 = true;
                if (magicProjectileObject == null)
                {
                    magicProjectileObject = Instantiate(projectilePrefab, cam.transform.position + (cam.transform.forward * 2), cam.transform.rotation);
                    //magicProjectileObject.GetComponent<Rigidbody>().AddForce(cam.transform.forward * 1000);
                    magicProjectile = magicProjectileObject.GetComponent<MagicProjectile>();
                    magicProjectile.HoldInPosition();
                    //magicProjectile.Release();
                }
                else
                {
                    if (magicProjectile.IsFrozen)
                        magicProjectile.Release();
                    else
                        magicProjectile.HoldInPosition();
                }
            }
        }
        else
            fire2 = false;

        if (CrossPlatformInputManager.GetAxis("Clear") != 0)
        {
            if (!clear)
			{
                if (magicProjectileObject)
                {
                    magicProjectile.DestroyBall();
                    magicProjectile = null;
                }
                clear = true;
            }
        }
        else
            clear = false;

        if (CrossPlatformInputManager.GetAxis("Interact") != 0)
        {
            if (!interact)
			{
                int layermask = 1 << 8; //(binary 10000000)
                layermask = ~layermask; //everything except layer 8 (binary 01111111)
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 50f, layermask))
                {
                    Interactable script;
                    if ((script = hit.collider.GetComponent<Interactable>()) != null)
                    {
                        script.Interact();
                    }
                }
                interact = true;
            }
        }
        else
            interact = false;
    }
}
