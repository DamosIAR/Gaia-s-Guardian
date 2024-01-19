using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePanel : MonoBehaviour
{
    public GameObject paneltodisable;
    // Start is called before the first frame update

    // Update is called once per frame
    public void disable()
    {
        paneltodisable.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
