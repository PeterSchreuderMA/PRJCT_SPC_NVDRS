using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public event Action OnPlayerDeath;

    public event Action<int> WaveAmount;

    public Wave[] _waves;
    public GameObject _enemy;
    public GameObject _enemyBase;
    private GameObject[] _enemies;

    private GameObject _UI;
    private Text _upcommingWaveText;
    private string _upcommingWaveTextText = "Next Wave starting in: ";

    private int _waveNumber = 0;
    private int _countDown = 3;

    void Start()
    {
        WaveAmount += FindObjectOfType<ScoreManager>().WaveAmount;

        _UI = GameObject.FindGameObjectWithTag("WaveText");
        _upcommingWaveText = GameObject.FindGameObjectWithTag("WaveText").GetComponent<Text>();
        StartCoroutine(WaveTimer());
    }

    IEnumerator WaveTimer()
    {
        yield return new WaitForSeconds(1);
        if (_countDown == 0)
        {
            _upcommingWaveText.text = "0";
            yield return new WaitForSeconds(0.5f);
            _upcommingWaveText.text = "";
            NextWave();
        }
        else
        {
            _upcommingWaveText.text = _upcommingWaveTextText + _countDown.ToString();
            _countDown--;
            StartCoroutine(WaveTimer());
        }
    }

    private IEnumerator EnemyShootTimer()
    {
        int _index = (int)Mathf.Round(UnityEngine.Random.Range(0, _enemies.Length));
        _enemies[_index].GetComponent<Enemy>().Shoot();

        yield return new WaitForSeconds(1f);
        StartCoroutine(EnemyShootTimer());
    }

    private void NextWave()
    {
        _waveNumber++;
        WaveAmount?.Invoke(_waveNumber);
        GameObject thisWave = Instantiate(_enemyBase);
        thisWave.transform.position = new Vector3(0, 2);
        float _distanceBetween = 1.46f;
        int _minDex = 0;
        for (int j = 0; j < _waves[_waveNumber - 1]._xAmount; j++)
        {
            for (int i = 0; i < _waves[_waveNumber - 1]._yAmount; i++)
            {
                GameObject currentSpawn = Instantiate(_enemy, thisWave.transform);
                currentSpawn.transform.localPosition = new Vector3(
                    (-(_waves[_waveNumber - _minDex]._xAmount / 2) + (j * _waves[_waveNumber - _minDex]._xAmount / _waves[_waveNumber - _minDex]._xAmount) * _distanceBetween),
                    -(_waves[_waveNumber - _minDex]._yAmount / 2) + (i * _waves[_waveNumber - _minDex]._yAmount / _waves[_waveNumber - _minDex]._yAmount),
                    0);
            }
        }
        thisWave.GetComponent<EnemyBase>().ChildrenAmount = _waves[_waveNumber - _minDex]._xAmount * _waves[_waveNumber - _minDex]._yAmount;
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        StartCoroutine(EnemyShootTimer());
    }

    public void NextWaveCaller()
    {
        _countDown = 3;
        StartCoroutine(WaveTimer());
    }

    public void PlayerDied()
    {
        print("Gameover");
        GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().SaveHighScore();
        GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().ChangeAllowInput(false);
    }

    IEnumerator RestartGame()
    {
        _upcommingWaveText.text = "Game Over";
        yield return new WaitForSeconds(3f);
        GetComponent<SceneSwitcher>().ChangeScene("Game");
    }

}










/*


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
                    (-(_waves[_waveNumber - 1]._xAmount / 2) + (j * _waves[_waveNumber - 1]._xAmount/ _waves[_waveNumber - 1]._xAmount) * 1.4f),
                    -(_waves[_waveNumber - 1]._yAmount / 2) + (i  * _waves[_waveNumber - 1]._yAmount/ _waves[_waveNumber - 1]._yAmount),
                    0);
            }
        }
        thisWave.GetComponent<EnemyBase>().ChildrenAmount = _waves[_waveNumber - 1]._xAmount * _waves[_waveNumber - 1]._yAmount;
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
*/