using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static _0xfaef8027;

public class _0x95eb9f22 : MonoBehaviour
{
    public void _0xda9a5301(int _0xf9b54c3e)
    {
        this._0x7dbb980c(_0xf9b54c3e);
        this._0xbeb78958(_0xf9b54c3e);
        this.CurrentPanelIndex = _0xf9b54c3e;
        this.Panels[_0xf9b54c3e].Show();
    }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x95eb9f22>();
    }

    private void _0xbeb78958(int _0xbe71f9af)
    {
        if (_0xbe71f9af == _0xec2ae8dc.SPLASH)
            _0xb350fe60.Instance._0xb74f32a7();
        if (_0xeb787fb1.Instance._0xfda347e3 == _0xc501cde9.SCENE_0)
        {
        }
    }

    public int CurrentPanelIndex;
    private void _0xba98642a()
    {
        this._0x12b83c9f(_0xec2ae8dc.SPLASH);
        if (_0xeb787fb1.Instance._0xfda347e3 == _0xc501cde9.SCENE_0)
        {
        }
        else
        {
            this.Invoke(nameof(this.SwitchSplash), _0xb350fe60.Instance.DefaultAnimationTime);
        }
    }

    public List<_0xedbb5775> Panels;
    private void _0x5128a6d2(int _0xb753c768)
    {
        this.LastPanelIndexes.Add(_0xb753c768);
        this.CurrentPanelIndex = _0xb753c768;
        for (int _0x95883ec2 = 0; _0x95883ec2 < this.Panels.Count; _0x95883ec2++)
            if (_0x95883ec2 != _0xb753c768 && this.Panels[_0x95883ec2] != null)
                this.Panels[_0x95883ec2]._0x1bf187f8();
    }

    private _0xedbb5775 _0xb42ac2ed(int _0xae77f5da)
    {
        return this.Panels[_0xae77f5da];
    }

    public void _0x77788017()
    {
        this.LastPanelIndexes.RemoveAll(_0x75d9323e => _0x75d9323e == this.CurrentPanelIndex);
        int _0xb64a724c = this.LastPanelIndexes.Last();
        this._0xbeb78958(_0xb64a724c);
        this._0x5128a6d2(_0xb64a724c);
        this.CurrentPanelIndex = _0xb64a724c;
        this.Panels[_0xb64a724c].Show();
    }

    [HideInInspector]
    public List<int> LastPanelIndexes = new()
    {
        1
    };
    public void _0xc57d705d(int _0x2a905580)
    {
        if (_0x2a905580 == _0xec2ae8dc.SPLASH && _0xeb787fb1.Instance._0xfda347e3 != _0xc501cde9.SCENE_0)
            _0xb350fe60.Instance._0x5925c447();
        if (_0xeb787fb1.Instance._0xfda347e3 != _0xc501cde9.SCENE_0)
        {
            if (_0x2a905580 == _0xec2ae8dc.SPLASH || _0x2a905580 == _0xec2ae8dc.TUTORIAL0)
                _0xeb787fb1.Instance._0xf04b6c96(false);
            else if (_0x2a905580 == _0xec2ae8dc.DEFAULT)
                _0xeb787fb1.Instance._0xf04b6c96(true);
        }
    }

    private void _0x7dbb980c(int _0x1de394de)
    {
        this.LastPanelIndexes.Add(_0x1de394de);
        this.CurrentPanelIndex = _0x1de394de;
        for (int _0x04ab390d = 0; _0x04ab390d < this.Panels.Count; _0x04ab390d++)
            if (_0x04ab390d != _0x1de394de && this.Panels[_0x04ab390d] != null)
                this.Panels[_0x04ab390d]._0x1bf187f8();
    }

    private void Start()
    {
        this._0xba98642a();
    }

    private void SwitchSplash()
    {
        if (_0xe1dd8ede.Instance.IsTutorialEnabled && !_0xeb787fb1._0x4d6f6bc6._0x0f5f3b07)
            this._0xda9a5301(_0xec2ae8dc.TUTORIAL0);
        else
            this._0xda9a5301(_0xec2ae8dc.DEFAULT);
    }

    public bool IsShowSplashOnStart = true;
    public static _0x95eb9f22 Instance;
    public float ScaleDuration = 0.4f;
    public float StaticBlurMaterialInitialValue;
    private void _0x12b83c9f(int _0x1518ea98)
    {
        this._0x7dbb980c(_0x1518ea98);
        this._0xbeb78958(_0x1518ea98);
        this.CurrentPanelIndex = _0x1518ea98;
        this.Panels[_0x1518ea98]._0x7a228f47();
    }
}