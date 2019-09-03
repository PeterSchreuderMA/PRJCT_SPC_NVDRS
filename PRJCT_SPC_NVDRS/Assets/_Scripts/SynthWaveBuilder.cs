using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthWaveBuilder : MonoBehaviour
{

    public GameObject _line;
    public GameObject _lineH;

    public int _verticalOnesNeedend;

    // Start is called before the first frame update
    void Start()
    {
        SpawnVertical();
        SpawnHorizontal();
    }

    void SpawnVertical()
    {
        for(int i = 0; i < _verticalOnesNeedend; i++)
        {
            GameObject currentLine = Instantiate(_line);
            currentLine.transform.localPosition = new Vector3(-(_verticalOnesNeedend * 3 / 2) + (3 * i), 0, 0);
        }
    }

    void SpawnHorizontal()
    {
        for (int i = 0; i < 53/3; i++)
        {
            GameObject currentLine = Instantiate(_lineH);
            currentLine.transform.position = new Vector3(0, 0, i * 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
