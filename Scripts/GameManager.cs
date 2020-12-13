using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [Header("Panels")]
    [SerializeField] private GameObject PanelStart;
    [SerializeField] private GameObject PanelRestart;

    [Header("Spawn Platform")]
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject platform;
    [SerializeField] private float rate;
    void Start()
    {
        Time.timeScale = 0f;
        player.Death += Lose;
        InvokeRepeating("SpawnTop", 0f, rate);
        InvokeRepeating("SpawnBottom", 0f, rate);
    }

    // Update is called once per frame
    void SpawnTop()
    {
        GameObject _platformTop = Instantiate(platform,new Vector2( SpawnPoint.position.x,6f), Quaternion.identity);
        _platformTop.transform.localScale =new Vector3 (Random.Range(5f, 15f), _platformTop.transform.localScale.y, _platformTop.transform.localScale.z);
        _platformTop.tag = "Platform";
    }
    void SpawnBottom()
    {
        GameObject _platformBottom = Instantiate(platform, new Vector2(SpawnPoint.position.x, -4f), Quaternion.identity);
        _platformBottom.transform.localScale = new Vector3(Random.Range(5f, 15f), _platformBottom.transform.localScale.y, _platformBottom.transform.localScale.z);
        _platformBottom.tag = "PlatformBottom";
    }

    public void startPlay()
    {
        Time.timeScale = 1f;
        PanelStart.SetActive(false);
    }
    public void Restart()
    {
        PanelRestart.SetActive(false);
        SceneManager.LoadScene("Game");

    }

    private void Lose()
    {
        PanelRestart.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Pause()
    {
        if (Time.timeScale == 0f) Time.timeScale = 1f;
        else Time.timeScale = 0f;
    }
}
