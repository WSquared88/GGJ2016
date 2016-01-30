using UnityEngine;
using System.Collections;

public class Lerping : MonoBehaviour
{
    public static Lerping instance;
    public delegate void finalAction();

    void Awake()
    {
        instance = this;
    }

    public static void DoCoroutine(IEnumerator coroutine)
    {
        instance.StartCoroutine(coroutine);
    }

    public static IEnumerator LerpTo(Transform pos, Vector3 startPos, Vector3 endPos, float time, finalAction action)
    {
        float startTime = Time.time;
        float timeLeft = 0;

        while (timeLeft <= time)
        {
            timeLeft = Time.time - startTime;
            pos.position = Vector3.Lerp(startPos, endPos, timeLeft);
            yield return null;
        }
        action();
    }
}
