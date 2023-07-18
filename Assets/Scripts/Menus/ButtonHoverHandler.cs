using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text modeDescription;

    public enum GameMode
    {
        Easy,
        Medium,
        Hard,
    };

    public GameMode mode;

    private string originalText = "Choose your option!\n\n<b>Hover over the button and see mode description</b>";

    private string easyModeText = "Easy mode here";
    private string mediumModeText = "Medium mode here";
    private string hardModeText = "Hard mode here";


    private void Awake()
    {
        modeDescription.text = originalText;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (mode)
        {
            case GameMode.Easy:
                modeDescription.text = easyModeText;
                break;
            case GameMode.Medium:
                modeDescription.text = mediumModeText;
                break;
            case GameMode.Hard:
                modeDescription.text = hardModeText;
                break;
            default:
                modeDescription.text = originalText;
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        modeDescription.text = originalText;
    }
}
