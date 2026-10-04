using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static _0xfaef8027;

public class _0x148306eb : MonoBehaviour
{
    public List<int> LastPopIndexes = new();
    public List<GameObject> GameObjectsToHide;
    private void Start()
    {
        this.BackgroundHidden();
        foreach (_0x058495bc _0x8488468b in this.Pops)
            if (_0x8488468b != null)
                _0x8488468b.gameObject.SetActive(true);
    }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x148306eb>();
    }

    private void _0x90183900()
    {
        this.Invoke(nameof(this.BackgroundHidden), this.ScaleDuration);
    }

    public GameObject BlurBackground;
    public static _0x148306eb Instance;
    private void BackgroundHidden()
    {
        this.BlurBackground.gameObject.SetActive(false);
    }

    public void _0x1eb41fb2(int _0x023e6ca4)
    {
        this.CurrentPopIndex = _0x023e6ca4;
        this.LastPopIndexes.Add(this.CurrentPopIndex);
        this._0xf195a19f(true);
        this._0x7245af82();
        this.Pops[_0x023e6ca4].Show();
        foreach (GameObject _0x2fcc38d5 in this.GameObjectsToHide)
            _0x2fcc38d5.SetActive(false);
    }

    private void _0xf195a19f(bool _0x150e1746 = false)
    {
        for (int _0xb8eeae21 = 0; _0xb8eeae21 < this.Pops.Count; ++_0xb8eeae21)
            if (this.Pops[_0xb8eeae21] != null && !(_0xb8eeae21 == this.CurrentPopIndex && _0x150e1746))
                this.Pops[_0xb8eeae21]._0x4af66a8b();
    }

    public void _0xc14479c5()
    {
        this.LastPopIndexes.Clear();
        this._0xf195a19f();
        foreach (GameObject _0x26f8afe0 in this.GameObjectsToHide)
            if (_0x26f8afe0 != null)
                _0x26f8afe0.SetActive(true);
        this._0x90183900();
    }

    public float ScaleDuration = 0.4f;
    public int CurrentPopIndex;
    public List<_0x058495bc> Pops;
    public _0x058495bc _0x81d70f7c(int _0x3878e099)
    {
        return this.Pops[_0x3878e099];
    }

    public void _0xc36bcafb()
    {
        this.LastPopIndexes.RemoveAll(_0x75d9323e => _0x75d9323e == this.CurrentPopIndex);
        if (this.LastPopIndexes.Count <= 0)
            this._0xc14479c5();
        else
            this._0x1eb41fb2(this.LastPopIndexes.Last());
    }

    private void _0x7245af82()
    {
        this.BlurBackground.gameObject.SetActive(true);
    }
}