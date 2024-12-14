using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource pasosAudioSource;
    private AudioSource saltoAudioSource;
    public AudioClip pasosClip;
    public AudioClip saltoClip;
    public CharacterController controller;
    public float velocidad = 10f;
    public float gravedad = -9.81f;
    public float alturaSalto = 3f;

    public Transform groundcheck;
    public float groundDis = 0.4f;
    public LayerMask groundMask;

    Vector3 veloz;
    bool isGrounded;
    void Start()
    {

        pasosAudioSource = gameObject.AddComponent<AudioSource>();
        saltoAudioSource = gameObject.AddComponent<AudioSource>();
        pasosAudioSource.clip = pasosClip;
        pasosAudioSource.loop = true;
        pasosAudioSource.volume = 0.2f;
        saltoAudioSource.clip = saltoClip;
        saltoAudioSource.loop = false;
        saltoAudioSource.volume = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundcheck.position, groundDis, groundMask);
        if (isGrounded && veloz.y < 0)
        {
            veloz.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * velocidad * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            veloz.y = Mathf.Sqrt(alturaSalto * -2f * gravedad);
            if (!saltoAudioSource.isPlaying)
            {
                saltoAudioSource.Play();
            }

        }

        if (move.magnitude > 0 && isGrounded)
        {
            if (!pasosAudioSource.isPlaying)
            {
                pasosAudioSource.Play();
            }
        }
        else
        {
            // Detener el sonido si el personaje no está en movimiento
            if (pasosAudioSource.isPlaying)
            {
                pasosAudioSource.Pause();
            }
        }

        veloz.y += gravedad * Time.deltaTime;

        controller.Move(veloz * Time.deltaTime);

    }
}
