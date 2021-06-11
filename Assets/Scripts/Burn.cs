using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{

    public ParticleSystem smoke;
    public Animator burnable;
    public AudioSource steam;

    //Trigger burning when an object hits the lava
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Burnable")
        {
            //Play smoking animation and sound
            smoke = this.GetComponent<ParticleSystem>();
            smoke.Play();
            steam = this.GetComponent<AudioSource>();
            steam.Play();

            //Destroy object by playing animation then disabling object
            burnable = other.GetComponent<Animator>();
            burnable.SetTrigger("Burned");
            DelayDestroy();
            other.enabled = false;
        }
    }

    //Wait for animation to play before disabling object
    void DelayDestroy()
    {
        StartCoroutine(FinishAnimation());
    }

    IEnumerator FinishAnimation()
    {
        yield return new WaitForSeconds(3);
    }
}
