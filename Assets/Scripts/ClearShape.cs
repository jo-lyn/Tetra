using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearShape : MonoBehaviour
{
    public GameObject clearAnim;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Clear()
    {
        GameObject anim = Instantiate(clearAnim, transform.position, Quaternion.identity);
        gameObject.transform.SetParent(anim.transform);
        anim.GetComponent<ClearAnimator>().PlayClearAnimation(gameObject.transform.rotation.z);
    }
}
