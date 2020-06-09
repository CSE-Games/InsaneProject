using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip myrJump, myrLand, myrSlash, myrDash, myrSlashHit, myrRangedAttack, enemyDies;
    public AudioClip projectileDies, objectDestroyed;
    public AudioSource audSrc;
    public AudioSource musicSrc;
    public float effectsVolume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audSrc.PlayOneShot(myrJump, effectsVolume);
                break;
            case "land":
                audSrc.PlayOneShot(myrLand, effectsVolume);
                break;
            case "slash":
                audSrc.PlayOneShot(myrSlash, effectsVolume);
                break;
            case "dash":
                audSrc.PlayOneShot(myrDash, effectsVolume);
                break;
            case "slashHit":
                audSrc.PlayOneShot(myrSlashHit, effectsVolume);
                break;
            case "rangedAttack":
                audSrc.PlayOneShot(myrRangedAttack, effectsVolume);
                break;
            case "endProjectile":
                audSrc.PlayOneShot(projectileDies, effectsVolume/3);
                break;
            case "destruction":
                audSrc.PlayOneShot(objectDestroyed, effectsVolume);
                break;
            case "enemydies":
                audSrc.PlayOneShot(enemyDies, effectsVolume);
                break;
        }
    }
}
