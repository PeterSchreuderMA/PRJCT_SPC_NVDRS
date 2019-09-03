using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DramaticDeath : MonoBehaviour
{
    [SerializeField]
    GameObject _explosionEffect;

    SoundEmitterInit soundEmitter;

    void Start()
    {
        soundEmitter = gameObject.GetComponent<SoundEmitterInit>();
    }

    public void StartDeath()
    {
        StartCoroutine(DeathAnimation());
    }

    private IEnumerator DeathAnimation()
    {
        CreateExplosion();

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }

    void CreateExplosion()
    {
        //- Play the explosion effect
        soundEmitter.PlaySound();
        GameObject _expl = Instantiate<GameObject>(_explosionEffect);
        _expl.transform.position = gameObject.transform.position;
    }
}
