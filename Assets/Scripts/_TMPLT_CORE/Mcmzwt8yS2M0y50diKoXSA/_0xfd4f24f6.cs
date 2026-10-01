using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0xfd4f24f6 : MonoBehaviour
{
    public void _0xafc7d67c(int scoreToAdd)
    {
        if (!this.IsGameEnd)
        {
            this.ScoreCurrent += scoreToAdd;
            this._0xbc598ef0();
            this._0x4674f3eb();
        }
    }

    private void _0xbc598ef0()
    {
        if (_0xe1dd8ede.Instance.IsCheckScoreEnabled)
            this.ScoreText.ForEach(_0xc402818c => _0xc402818c.text = $"{this.ScoreCurrent}/{this._0x4591661c}");
        else
            this.ScoreText.ForEach(_0xc402818c => _0xc402818c.text = $"{this.ScoreCurrent}");
    }

    public List<Button> HomeButtons = new();
    private static _0xfd4f24f6 _0xa882eed3;
    private IEnumerator _0x4c8f9102()
    {
        this._0xf944cb64();
        while (!this.IsGameEnd && this.TimeLeft > 0 && _0xeb787fb1.Instance._0xfda347e3 == this.CurrentGameIndex)
        {
            yield return new WaitForSeconds(1f);
            if (_0xeb787fb1.Instance._0xd0a09e2c)
            {
                if (this.IsGameEnd)
                    break;
                this.TimeLeft--;
                this._0xf944cb64();
            }
        }

        if (!this.IsGameEnd)
            this._0xb123cdde();
    }

    public void _0x751659d0()
    {
        _0xeb787fb1.Instance._0xf04b6c96(true);
        _0xeb787fb1.Instance.LoadSceneByIndex(_0xfaef8027._0xc501cde9.SCENE_0);
    }

    public void _0xb123cdde()
    {
        if (_0xe1dd8ede.Instance.IsOnlyWinGameEndEnabled)
            this._0xcb92fb1c();
        if (!this.IsGameEnd)
        {
            this._0x71f4d2d2();
            _0xeb787fb1.IsAfterLevelComplete = false;
            _0xeb787fb1.IsAfterLevelFailed = true;
            _0x058495bc _0x47db04b0 = _0x148306eb.Instance._0x81d70f7c(_0xfaef8027._0x250cf309.LOSE).GetComponent<_0x058495bc>();
            if (_0xe1dd8ede.Instance.IsCheckScoreEnabled)
                _0x47db04b0.ContentMainText.text = $"{this.ScoreCurrent}/{this._0x4591661c}";
            else
                _0x47db04b0.ContentMainText.text = $"{this.ScoreCurrent}";
            _0x47db04b0.ContentAdditionalText.text = $"{0}";
            _0xfaef8027._0x6b1ba0f2._0x53608a6a += 0;
            _0x148306eb.Instance._0x1eb41fb2(_0xfaef8027._0x250cf309.LOSE);
        }
    }

    public List<TMP_Text> TimerText = new();
    public void _0xcb92fb1c()
    {
        if (!this.IsGameEnd)
        {
            this._0x71f4d2d2();
            _0xeb787fb1.IsAfterLevelComplete = true;
            _0xeb787fb1.IsAfterLevelFailed = false;
            _0x058495bc _0xf157283c = _0x148306eb.Instance._0x81d70f7c(_0xfaef8027._0x250cf309.WIN).GetComponent<_0x058495bc>();
            if (_0xe1dd8ede.Instance.IsCheckScoreEnabled)
                _0xf157283c.ContentMainText.text = $"{this.ScoreCurrent}/{this._0x4591661c}";
            else
                _0xf157283c.ContentMainText.text = $"{this.ScoreCurrent}";
            if (_0xe1dd8ede.Instance.IsBestScoreEnabled)
            {
                if (this.ScoreCurrent > _0xfaef8027._0x6b1ba0f2._0x53608a6a)
                    _0xfaef8027._0x6b1ba0f2._0x53608a6a = this.ScoreCurrent;
                _0xf157283c.ContentAdditionalText.text = $"{_0xfaef8027._0x6b1ba0f2._0x53608a6a}";
            }
            else
            {
                _0xf157283c.ContentAdditionalText.text = $"{this._0x73c005a9}";
                _0xfaef8027._0x6b1ba0f2._0x53608a6a += this._0x73c005a9;
            }

            if (_0xe1dd8ede.Instance.IsLevelIncrementOnWin)
                ++_0xeb787fb1._0x4d6f6bc6._0x8238ecef;
            _0x148306eb.Instance._0x1eb41fb2(_0xfaef8027._0x250cf309.WIN);
        }
    }

    private void Start()
    {
        this.IsGameEnd = false;
        this.TimeLeft = this._0xc539c445;
        this.CurrentGameIndex = _0xeb787fb1.Instance._0xfda347e3;
        foreach (Button _0x4a534ed2 in this.HomeButtons)
            _0x4a534ed2.onClick.AddListener(() =>
            {
                this._0x751659d0();
            });
        foreach (Button _0xfbde39df in this.PauseButtons)
            _0xfbde39df.onClick.AddListener(() =>
            {
                _0xeb787fb1.Instance._0xf04b6c96(false);
                _0x148306eb.Instance._0x1eb41fb2(_0xfaef8027._0x250cf309.PAUSE);
            });
        this._0xbc598ef0();
        this.LevelNumberText.ForEach(_0xc402818c => _0xc402818c.text = $"LVL {_0xeb787fb1._0x4d6f6bc6._0x8238ecef + 1}");
        if (_0xe1dd8ede.Instance.IsTimerEnabled)
        {
            this._0xf944cb64();
            this.StartCoroutine(this._0x4c8f9102());
        }
    }

    public List<TMP_Text> SubtitleText = new();
    private int _0x73c005a9 => this.ScoreCurrent;

    public int CustomTimeInitial = 30;
    public List<TMP_Text> ScoreText = new();
    [HideInInspector]
    public int TimeLeft;
    [HideInInspector]
    public int ScoreCurrent;
    private void _0x4674f3eb()
    {
        if (this.ScoreCurrent > _0xeb787fb1._0x4d6f6bc6._0x37de77c0)
            _0xeb787fb1._0x4d6f6bc6._0x37de77c0 = this.ScoreCurrent;
        if (_0xe1dd8ede.Instance.IsCheckScoreEnabled)
            if (this.ScoreCurrent >= this._0x4591661c)
                this._0xcb92fb1c();
    }

    private void _0x2d28a383()
    {
        if (this.ScoreCurrent >= this._0x4591661c)
            this._0xcb92fb1c();
        else
            this._0xb123cdde();
    }

    private int _0x4591661c => this.CustomTargetScore + _0xeb787fb1._0x4d6f6bc6._0x8238ecef * 10;

    private void _0xf944cb64()
    {
        this.TimerText.ForEach(_0xc402818c => _0xc402818c.text = TimeSpan.FromSeconds(this.TimeLeft).ToString(_0x0b6238f3._0x6bbd275d(new byte[6] { 255, 255, 206, 168, 225, 225 }, 146)));
    }

    public List<Button> PauseButtons = new();
    private int _0xc539c445 => this.CustomTimeInitial + _0xeb787fb1._0x4d6f6bc6._0x8238ecef * 10;

    [HideInInspector]
    public int CurrentGameIndex;
    public int CustomTargetScore = 10;
    private void Awake()
    {
        _0xa882eed3 = this.gameObject.GetComponent<_0xfd4f24f6>();
    }

    [HideInInspector]
    public bool IsGameEnd;
    private void _0x71f4d2d2()
    {
        this.IsGameEnd = true;
        _0xeb787fb1.IsAfterLevelComplete = true;
    }

    public List<TMP_Text> LevelNumberText = new();
}

internal static class _0x0b6238f3
{
    internal static string _0x6bbd275d(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}