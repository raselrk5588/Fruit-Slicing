using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroutsSponer : MonoBehaviour
{
    public GameObject FroutsPrefab;
    public Transform[] forutsPoints;
    float maxTime = 1f;
    float miniTime = 0.1f;

    void Start()
    {
        StartCoroutine(sponFrouts());
    }

    IEnumerator sponFrouts()
    {
        while (true)
        {
            float diley = Random.Range(miniTime, maxTime);
            yield return new WaitForSeconds(diley);
            int index = Random.Range(0, forutsPoints.Length);
            Transform frout = forutsPoints[index];
            GameObject OldFrouts = Instantiate(FroutsPrefab, frout.position, frout.rotation);
            Destroy(OldFrouts, 5f);
        }
    }
}
