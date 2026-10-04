using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _0xb350fe60 : MonoBehaviour
{
    public GameObject Content;
    public void _0xa0276314()
    {
        this._0xb038a1f8?.Pause();
    }

    public void _0xb74f32a7()
    {
        this._0xb038a1f8?.Kill();
        this.AnimationSlider.value = _0xf2f75a9c ? this.SecondPassSliderValue : 0.05f;
    }

    public GameObject Error;
    private Sequence _0xb038a1f8;
    public GameObject Background;
    public Slider AnimationSlider;
    private static bool _0xf2f75a9c = false;
    public float FirstAnimationTime = 10.0f;
    public void _0x5925c447()
    {
        this._0xb74f32a7();
        bool _0x87f76dac = _0xf2f75a9c;
        this._0xb038a1f8 = DOTween.Sequence().Append(DOTween.To(() => this.AnimationSlider.value, _0xe21d4d26 => this.AnimationSlider.value = _0xe21d4d26, _0x87f76dac ? 1f : this.SecondPassSliderValue, this.DefaultAnimationTime)).SetEase(Ease.Linear);
        _0xf2f75a9c = !_0xf2f75a9c;
    }

    public float SecondPassSliderValue = 0.5f;
    public float DefaultAnimationTime = 0.4f;
    public void _0x88218947()
    {
        {
#if B_LOGS
            {
                Debug.Log($"[Test] Animate Force");
            }
#endif
        }

        this._0xb038a1f8?.Kill();
        if (AnimationSlider != null)
            this.AnimationSlider.value = 1f;
        _0xf2f75a9c = false;
    }

    public static _0xb350fe60 Instance;
    private void _0x61bab6e1()
    {
        this.AnimationSlider.value = 0.05f;
        _0xf2f75a9c = !_0xf2f75a9c;
        this._0xb038a1f8 = DOTween.Sequence().Append(DOTween.To(() => this.AnimationSlider.value, _0xe21d4d26 => this.AnimationSlider.value = _0xe21d4d26, 1f, this.FirstAnimationTime)).SetEase(Ease.Linear).OnComplete(() =>
        {
            _0x73b3491c._0xe937bad0?._0x5afa9b37();
        });
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == _0xfaef8027._0xc501cde9.SCENE_0 && !_0xf2f75a9c)
        {
            this._0x61bab6e1();
        }
        else
        {
            this._0x5925c447();
        }
    }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0xb350fe60>();
    }

    public void _0x9bdfba71()
    {
        this._0xb038a1f8?.Play();
    }
}