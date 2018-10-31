using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float snapDuration = 0.06f;
    public float rotationSpeed = 600f;
    public bool smoothRotation = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (smoothRotation)
        {
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            Debug.Log(Input.GetAxis("Horizontal"));
            rotation *= Time.deltaTime;
            transform.Rotate(0, 0, -1 * rotation);
        }
        else
        {
            if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
            {
                StartCoroutine(Rotate(Vector3.forward, 90));
            }
            if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
            {
                StartCoroutine(Rotate(Vector3.back, 90));
            }
        }

        if (GameController.instance.isGameOver) {
            this.enabled = false;
        }
    }

    IEnumerator Rotate(Vector3 axis, float angle)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation * Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;

        while (elapsed < snapDuration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / snapDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;

        StopAllCoroutines();
    }
}

