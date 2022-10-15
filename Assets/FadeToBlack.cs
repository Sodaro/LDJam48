using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] Text winText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade()
	{
        float t = 0;
        float duration = 2f;
        while (t < 2)
		{
            t += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, t / duration);
            yield return null;
		}
        winText.enabled = true;
	}

    public void ActivateFade()
	{
        StartCoroutine(Fade());
	}
}
