using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0xedbb5775 : MonoBehaviour
{
    public GameObject OuterBackground;
    private void _0xa764418a()
    {
        if (this.OuterBackground != null)
        {
            Image _0xca9ad46a = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0xca9ad46a, true);
            _0xca9ad46a.DOFade(0f, 0.01f);
        }

        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.DOScale(0f, 0.01f);
    }

    private void Awake()
    {
        this.Content.SetActive(true);
        if (this.OuterBackground != null)
            this.OuterBackground.gameObject.SetActive(true);
        if (this.IsScaledDownOnAwake)
            this._0xa764418a();
    }

    public void Show()
    {
        this._0xb617b79e();
        if (this.Content != null)
        {
            DOTween.Kill(this.Content.transform, true);
            this.Content.SetActive(true);
            this.Content.transform.DOScale(1f, this.ScaleDuration).SetEase(this.Ease).OnComplete(() =>
            {
                _0x95eb9f22.Instance._0xc57d705d(_0x95eb9f22.Instance.CurrentPanelIndex);
            });
        }
    }

    public TMP_Text MainText;
    public void _0x7a228f47()
    {
        this._0x8f9aed54();
        this.Content.SetActive(true);
        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.localScale = Vector3.one;
        _0x95eb9f22.Instance._0xc57d705d(_0x95eb9f22.Instance.CurrentPanelIndex);
    }

    public float ScaleDuration = 0.4f;
    private void _0xb617b79e()
    {
        if (this.OuterBackground != null)
        {
            Image _0xce9c1bdf = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0xce9c1bdf, true);
            _0xce9c1bdf.DOFade(1f, this.ScaleDuration / 2f);
        }
    }

    public Ease Ease = Ease.OutSine;
    public void _0x1bf187f8()
    {
        this._0xe07338df();
        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.DOScale(0f, this.ScaleDuration).SetEase(this.Ease).OnComplete(() =>
        {
            this.Content.SetActive(false);
        });
    }

    public bool IsScaledDownOnAwake = true;
    private void _0xe07338df()
    {
        if (this.OuterBackground != null)
        {
            Image _0xd78185df = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0xd78185df, true);
            _0xd78185df.DOFade(0f, this.ScaleDuration);
        }
    }

    public TMP_Text HeaderText;
    private bool _0x8490b76c => this.Content.transform.localScale.x > 0.5f && this.Content.transform.localScale.y > 0.5f;

    public GameObject Content;
    private void _0x8f9aed54()
    {
        if (this.OuterBackground != null)
        {
            Image _0xb0c2fbb8 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0xb0c2fbb8, true);
            _0xb0c2fbb8.DOFade(1f, 0f);
        }
    }
}