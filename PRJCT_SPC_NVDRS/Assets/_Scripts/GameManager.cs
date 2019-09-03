using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public event Action OnPlayerDeath;

    public Wave[] _waves;
    public GameObject _enemy;
    public GameObject _enemyBase;

    private GameObject _UI;
    private Text _upcommingWaveText;
    private string _upcommingWaveTextText = "Next Wave starting in: ";

    private int _waveNumber = 0;

    void Start()
    {
        _UI = GameObject.Find("Ui");
        _upcommingWaveText = GameObject.FindGameObjectWithTag("WaveText").GetComponent<Text>();
        StartCoroutine(WaveTimer());
    }

    IEnumerator WaveTimer()
    {
        _UI.SetActive(true);
        _upcommingWaveText.text = _upcommingWaveTextText + 3;
        yield return new WaitForSeconds(1f);
        _upcommingWaveText.text = _upcommingWaveTextText + 2;
        yield return new WaitForSeconds(1f);
        _upcommingWaveText.text = _upcommingWaveTextText + 1;
        yield return new WaitForSeconds(1f);
        _upcommingWaveText.text = "0";
        yield return new WaitForSeconds(0.5f);
        _UI.SetActive(false);

        NextWave();

    }

    private void NextWave()
    {
        _waveNumber++;
        GameObject thisWave = Instantiate(_enemyBase);
        thisWave.transform.position = new Vector3(0, 2);
        for (int j = 0; j < _waves[_waveNumber - 1]._xAmount; j++)
        {
            for(int i = 0; i < _waves[_waveNumber - 1]._yAmount; i++)
            {
                GameObject currentSpawn = Instantiate(_enemy, thisWave.transform);
                currentSpawn.transform.localPosition = new Vector3(
                    -(_waves[_waveNumber - 1]._xAmount / 2) + (j * _waves[_waveNumber - 1]._xAmount/ _waves[_waveNumber - 1]._xAmount),
                    -(_waves[_waveNumber - 1]._yAmount / 2) + (i  * _waves[_waveNumber - 1]._yAmount/ _waves[_waveNumber - 1]._yAmount),
                    0);
            }
        }
        thisWave.GetComponent<EnemyBase>().ChildrenAmount = _waves[_waveNumber - 1]._xAmount * _waves[_waveNumber - 1]._yAmount;
        thisWave.GetComponent<EnemyBase>().StartMoving();
    }

    public void NextWaveCaller()
    {
        StartCoroutine(WaveTimer());
    }

    public void PlayerDied()
    {
        GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().ChangeAllowInput(false);
    }
}
