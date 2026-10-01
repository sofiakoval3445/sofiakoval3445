using UnityEngine;
using UnityEngine.UI;

public class _0x1556b7af : MonoBehaviour
{
    public int NextTutorialPanelIndex;
    private void Start()
    {
        if (this.NextTutorialButton != null)
        {
            if (this.IsTutorialEndPanel)
            {
                this.NextTutorialButton.onClick.AddListener(() => _0x95eb9f22.Instance._0xda9a5301(this.EndTutorialPanelIndex));
                this.NextTutorialButton.onClick.AddListener(() => _0xeb787fb1.Instance._0x5a7c9f13());
            }
            else
            {
                this.NextTutorialButton.onClick.AddListener(() => _0x95eb9f22.Instance._0xda9a5301(this.NextTutorialPanelIndex));
            }
        }

        if (this.TutorialEndButton != null)
        {
            this.TutorialEndButton.onClick.AddListener(() => _0x95eb9f22.Instance._0xda9a5301(this.EndTutorialPanelIndex));
            this.TutorialEndButton.onClick.AddListener(() => _0xeb787fb1.Instance._0x5a7c9f13());
        }
    }

    public bool IsTutorialEndPanel;
    public Button TutorialEndButton;
    public Button NextTutorialButton;
    public int EndTutorialPanelIndex = 1;
}