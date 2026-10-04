using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _0x35897933 : MonoBehaviour
{
    public Button Button;
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    private void Start()
    {
        if (this.IsLoadCurrentScene)
            this.Button.onClick.AddListener(() =>
            {
                _0xeb787fb1.Instance.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex);
            });
        else
            this.Button.onClick.AddListener(() => _0xeb787fb1.Instance.LoadSceneByIndex(this.LoadSceneId));
    }

    public bool IsLoadCurrentScene;
    public int LoadSceneId;
}