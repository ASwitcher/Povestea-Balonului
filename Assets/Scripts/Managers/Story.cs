using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public float pauseTime;
    public float duration = 1f;
    public float t = 0f;

    public Text textLeft, textRight;

    public Color whiteText;
    public Color blackText;

    private bool endOfStory = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTheStory());
    }


    IEnumerator StartTheStory()
    {
        while (endOfStory)
        {
            yield return new WaitForSeconds(pauseTime);
            textLeft.text = "A fost odata ca niciodată";
            textLeft.enabled = true;
            yield return new WaitForSeconds(pauseTime);
            textLeft.enabled = false;
            yield return new WaitForSeconds(10f);
            textRight.text = "Un balon care a ales să scape din mâinile unei fetițe";
            textRight.enabled = true;
            yield return new WaitForSeconds(pauseTime);
            textRight.enabled = false;
            endOfStory = false;
        }
    }
}
