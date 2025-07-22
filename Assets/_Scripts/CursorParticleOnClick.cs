using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorParticleOnClick : MonoBehaviour
{
    public GameObject clickParticleSys;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void OnMyMouseDown(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            // Instantiate(clickParticleSys, pos, Quaternion.identity);
            GameObject particle = Instantiate(clickParticleSys);
            particle.transform.parent = this.gameObject.transform;
            particle.transform.localPosition = pos;

            _audioSource.PlayOneShot(_audioSource.clip);
            // randomize pitch of audio
        }
    }
}
