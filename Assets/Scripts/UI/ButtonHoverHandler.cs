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
    private string easyModeText = "<b>Easy mode</b>\n\nYou can use both hands and legs to destroy obstacles. It doesn't matter which part of the body you will use!\n\nHave fun and try to store as many points as possible!";
    private string mediumModeText = "<b>Medium mode</b>\n\nPink elements have to be destroyed using left part of the body, similarly blue ones can be collected only with right part of the body.\n\nBe careful and remember about the rules!";
    private string hardModeText = "<b>Hard mode</b>\n\nYour hands can collect green spheres, but blue ones can be destroyed only using your legs!\n\nYou have to react quickly, obstacles are coming really fast!";


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
