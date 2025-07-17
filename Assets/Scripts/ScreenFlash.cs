using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net.NetworkInformation;

public class ScreenFlash : MonoBehaviour
{
    public float FlashDuration = 0.33f;
    private Image flashImage;
    private Color ImageColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flashImage = GetComponent<Image>();
        ImageColor = flashImage.color;
        StartCoroutine(FlashRoutine());
    }

    public IEnumerator FlashRoutine()
    {
        float timer = 0f;
        float t =0;
        float alphaFrom = 1f;
        float alphaTo = 0f;

        while (t < 1f)
        {
            timer += Time.deltaTime;
            t = Mathf.Clamp01(timer / FlashDuration);
            float alpha = Mathf.Lerp(alphaFrom, alphaTo, t);
            Color col = ImageColor;
            col.a = alpha;
            flashImage.color = col;
            yield return new WaitForEndOfFrame();
        }





        Debug.Log("Start Flashing");
        yield return null;
        Debug.Log("Still flashing");
        yield return new WaitForSeconds(1);
        Debug.Log("Stopped Flashing");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(FlashRoutine());
    }


}


