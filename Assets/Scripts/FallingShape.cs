﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FallingShape : MonoBehaviour
{
    public float fallSpeed;
    private bool isHit = false;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isHit)
        {
            fallSpeed = GameController.instance.GetFallSpeed();
        } else {
            fallSpeed = 0;
        }
        Vector2 direction = transform.rotation * new Vector2(0, -1 * fallSpeed);
        rb2d.MovePosition(rb2d.position + direction * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isHit = true;
        if (other.GetComponent<Stacker>().GetStackCount() == 1
            && other.CompareTag(gameObject.tag))
        {
            StartCoroutine(Bloat());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Bloat()
    {
        gameObject.GetComponent<Animator>().Play("bloat");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        yield return null;
    }
}
