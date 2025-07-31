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
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = 10f;
            Vector3 particlePos = Camera.main.ScreenToWorldPoint(mousePos);
            
            GameObject particle = Instantiate(clickParticleSys);
            particle.transform.parent = this.gameObject.transform;
            particle.transform.localPosition = particlePos;

            _audioSource.PlayOneShot(_audioSource.clip);
            // randomize pitch of audio
        }
    }
}
