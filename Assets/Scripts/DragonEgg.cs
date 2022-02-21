using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEgg : MonoBehaviour
{
    public static float BottomY = -30.0f;

   
    private void Update()
    {
        if(transform.position.y < BottomY)
        {
            Destroy(this.gameObject);
            DragonPicker apScript = Camera.main.GetComponent<DragonPicker>();
            apScript.DragonEggDestroyed();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        ParticleSystem particle = GetComponent<ParticleSystem>();
        var em = particle.emission;
        em.enabled = true;

        Renderer render;
        render = GetComponent<Renderer>();
        render.enabled = false;
    }
}
