using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineH : MonoBehaviour
{

    public float _speed = 1;

    private Material m_Material;

    private void Start()
    {
        m_Material = GetComponent<Renderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * _speed * Time.deltaTime;

        if(transform.position.z <= 0) { transform.position += Vector3.forward * 50; }
        m_Material.color = new Color(1, (transform.position.z/ 50 ), ((transform.position.z / 50) / 2) + 0.5f, 1);
    }
}
