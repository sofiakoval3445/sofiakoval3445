using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static _0xfaef8027;

public class _0xeb787fb1 : MonoBehaviour
{
    public void _0x5a7c9f13()
    {
        _0x4d6f6bc6._0x0f5f3b07 = true;
    }

    public Button ShowResetTutorialButton;
    public static bool IsAfterLevelFailed = false;
    private IEnumerator _0xa332be29(string _0xfc3c4c2d)
    {
        _0x95eb9f22.Instance._0xda9a5301(_0xec2ae8dc.SPLASH);
        //AudioController.Instance.SaveLastMusicTimes();
        AsyncOperation _0xf4c7aca2 = SceneManager.LoadSceneAsync(_0xfc3c4c2d);
        while (!_0xf4c7aca2.isDone)
            yield return null;
    }

    [HideInInspector]
    public GameObject RootGameObject; // tag - "Root"
    public Transform EnvironmentWithTweensToToggle;
    private static void ExitGame()
    {
        Application.Quit();
    }

    public void _0xf04b6c96(bool _0x7a59390e)
    {
        this._0xd0a09e2c = _0x7a59390e;
        this._0x43bf0e87(!this._0xd0a09e2c);
        Physics2D.simulationMode = this._0xd0a09e2c ? SimulationMode2D.FixedUpdate : SimulationMode2D.Script;
        if (this.EnvironmentWithTweensToToggle != null)
            this._0xb49d51c1(this.EnvironmentWithTweensToToggle);
    }

    private void _0xb49d51c1(Transform _0xaa093c28)
    {
        Transform[] _0x649f439b = _0xaa093c28.GetComponentsInChildren<Transform>();
        foreach (Transform _0xcab63c76 in _0x649f439b)
            if (_0xcab63c76 != null && DOTween.IsTweening(_0xcab63c76))
            {
                if (this._0xd0a09e2c)
                    DOTween.Play(_0xcab63c76);
                else
                    DOTween.Pause(_0xcab63c76);
            }
    }

    public bool _0xd0a09e2c { get; private set; }

    private void _0x43bf0e87(bool _0xdea659c4)
    {
        Rigidbody2D[] _0x17e89b32 = this.RootGameObject.GetComponentsInChildren<Rigidbody2D>(true);
        foreach (Rigidbody2D _0x57b4ff78 in _0x17e89b32)
            if (_0xdea659c4)
                _0x57b4ff78.constraints = RigidbodyConstraints2D.FreezeAll;
            else
                _0x57b4ff78.constraints = RigidbodyConstraints2D.None;
    }

    public Transform Environment;
    private IEnumerator _0x2978ab9d(int _0x76923913)
    {
        _0x95eb9f22.Instance._0xda9a5301(_0xec2ae8dc.SPLASH);
        AsyncOperation _0x3baf3e25 = SceneManager.LoadSceneAsync(_0x76923913);
        while (!_0x3baf3e25.isDone)
            yield return null;
    }

    public void _0x2bac048d()
    {
        foreach (_0x055edff1 _0xefd8ca5f in this.MoneyCountContainers)
            _0xefd8ca5f._0x63f8fb6f();
    }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0xeb787fb1>();
        this.RootGameObject = GameObject.FindWithTag(_0xc2c0759b._0x0463e224(new byte[4] { 89, 100, 100, 127 }, 11));
        if (this._0xfda347e3 == _0xc501cde9.SCENE_0)
            this._0xf04b6c96(true);
        else
            this._0xf04b6c96(false);
        this.MoneyCountContainers = this.RootGameObject.GetComponentsInChildren<_0x055edff1>(true).ToList();
    }

    public static _0xeb787fb1 Instance;
    private static void MakeGrid(List<RectTransform> _0xe2d8b48d, AspectRatioFitter _0x0c9a4518, float _0xeb928de9, int _0xe6cd8428, int _0xfbae4468)
    {
        _0x0c9a4518.aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
        _0x0c9a4518.aspectRatio = _0xeb928de9;
        foreach (RectTransform _0xe55d5741 in _0xe2d8b48d)
        {
            int _0x8f5aae08 = _0xe55d5741.transform.GetSiblingIndex();
            _0xe55d5741.anchorMin = new Vector3(Mathf.FloorToInt((float)_0x8f5aae08 % _0xe6cd8428) * (1f / _0xe6cd8428), (_0xfbae4468 - (Mathf.FloorToInt((float)_0x8f5aae08 / _0xe6cd8428) % _0xfbae4468 + 1f)) * (1f / _0xfbae4468));
            _0xe55d5741.anchorMax = new Vector3(Mathf.FloorToInt((float)_0x8f5aae08 % _0xe6cd8428 + 1f) * (1f / _0xe6cd8428), (_0xfbae4468 - Mathf.FloorToInt((float)_0x8f5aae08 / _0xe6cd8428) % _0xfbae4468) * (1f / _0xfbae4468));
            _0xe55d5741.offsetMin = Vector2.zero;
            _0xe55d5741.offsetMax = Vector2.zero;
        }
    }

    public void LoadSceneByIndex(int _0x6ba02efc)
    {
        //if (SceneManager.GetActiveScene().buildIndex == sceneIndex)
        //    AdsInitializer.Instance?.ShowAd();
        this.StartCoroutine(this._0x2978ab9d(_0x6ba02efc));
    }

    [HideInInspector]
    public List<_0x055edff1> MoneyCountContainers = new();
    private static _0xdedf6d46 GAME_INDEX_SETTINGS(int _0x71d68863)
    {
        return _0xdedf6d46.ALL_SCENES_SETTING_SINGLETONS[_0x71d68863];
    }

    public static _0xdedf6d46 _0x4d6f6bc6 => _0xdedf6d46.ALL_SCENES_SETTING_SINGLETONS[Instance._0xfda347e3];

    public void _0xc3fabe22()
    {
        this.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex);
    }

    private void _0x8a1e6837()
    {
        IsAfterLevelComplete = true;
        Instance.LoadSceneByIndex(_0xc501cde9.SCENE_0);
    }

    public int _0xfda347e3 => SceneManager.GetActiveScene().buildIndex;

    public Button DeleteProgressDataButton;
    public Canvas MainCanvas;
    public static bool IsAfterLevelComplete;
    private void Start()
    {
        if (this._0xfda347e3 != _0xc501cde9.SCENE_0)
            Screen.orientation = ScreenOrientation.Portrait;
        this.DeleteProgressDataButton?.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteAll();
            //AudioController.Instance.UpdateMusics();
            //AudioController.Instance.UpdateSfxes();
            Instance.LoadSceneByIndex(_0xc501cde9.SCENE_0);
        });
        this.ShowResetTutorialButton?.onClick.AddListener(() =>
        {
            _0x4d6f6bc6._0x0f5f3b07 = false;
            _0x148306eb.Instance._0xc14479c5();
            _0x95eb9f22.Instance._0xda9a5301(_0xec2ae8dc.TUTORIAL0);
        });
    }

    private static _0xdedf6d46 _0xce447fff => _0xdedf6d46.ALL_SCENES_SETTING_SINGLETONS[0];
}

internal static class _0xc2c0759b
{
    internal static string _0x0463e224(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}