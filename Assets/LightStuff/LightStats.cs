using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStats : MonoBehaviour
{

    UnityEngine.Rendering.Universal.Light2D thisLight;
    public float energy;

    // Start is called before the first frame update
    void Start()
    {
        thisLight = this.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        energy = thisLight.intensity * 100;
    }

    // Update is called once per frame
    void Update()
    {
        thisLight.intensity = energy / 100;
    }
}
