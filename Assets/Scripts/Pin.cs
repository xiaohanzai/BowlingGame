using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Rigidbody rb;
    public bool playStrikeAudio;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetToStartPosition()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.SetActive(true);
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        playStrikeAudio = false;
    }

    public bool CheckIsFallen()
    {
        bool isFallen = false;
        if (Mathf.Abs(transform.rotation.z) > 0.1f || Mathf.Abs(transform.rotation.x) > 0.1f || Vector3.Distance(originalPosition, transform.position) > 0.5f)
        {
            isFallen = true;
        }
        return isFallen;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            playStrikeAudio = true;
        }
        Debug.Log(collision.gameObject.tag);
    }
}
