using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float force;
    public Transform arrowTransform;
    public float horizontalSpeed;
    public float maxHorizontalDistance;
    public AudioSource audioSource;

    private Rigidbody rb;
    private bool isThrown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrown)
        {
            if (transform.position.z > GameManager.instance.changePointTransform.position.z)
            {
                GameManager.instance.secondCamera.SetActive(true);
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isThrown = true;
            rb.AddForce(force * arrowTransform.forward, ForceMode.Impulse);
            arrowTransform.gameObject.SetActive(false);
            audioSource.Play();
        }

        float direction = Input.GetAxisRaw("Horizontal");
        if (direction != 0)
        {
            Vector3 position = transform.position;
            if (position.x >= maxHorizontalDistance && direction > 0 || position.x <= -maxHorizontalDistance && direction < 0)
            {
                return;
            }
            position.x += direction * Time.deltaTime * horizontalSpeed;
            rb.MovePosition(position);
        }
    }
}
