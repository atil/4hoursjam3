using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public Text ScoreText;
    private int score;

	public void OnScore()
    {
        ScoreText.text = (++score).ToString();
    }

    public void Screenshake()
    {
        StartCoroutine(ScreenshakeCoroutine());
    }

    IEnumerator ScreenshakeCoroutine()
    {
        var origPos = Camera.main.transform.position;
        for (float f = 0; f < 1f; f += Time.deltaTime)
        {
            var target = Camera.main.transform.position + (Vector3)Random.insideUnitCircle / 2;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, target, Time.deltaTime * 15);
            yield return null;
        }
        Camera.main.transform.position = origPos;
    }
}
