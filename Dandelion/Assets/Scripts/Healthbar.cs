using DandelionLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image Bar;
    public float Fill;
    public UserBar UserBar;

    // Start is called before the first frame update
    void Start()
    {
        UserBar = new UserBar();
        Fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Fill = UserBar.HealthBar;
        //Debug.LogWarning($"HB: {Fill}");
        Bar.fillAmount = Fill;

        if(Fill == 0)
        {
            Debug.LogWarning($"{this}: THERE IS DEATH TIME");
        }
    }
}
