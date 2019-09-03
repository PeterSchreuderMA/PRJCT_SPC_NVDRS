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
        CreateExplosion();
        //StartCoroutine(DeathAnimation());
    }

    private IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(0.01f);
    }

    void CreateExplosion()
    {
        //- Play the explosion effect
        GameObject _expl = Instantiate<GameObject>(_explosionEffect);
        _expl.transform.position = gameObject.transform.position;
        _expl.gameObject.GetComponent<SoundEmitterInit>().PlaySound();
        Destroy(_expl, 5f);

        //- Destroy self
        Destroy(gameObject);
    }
}
