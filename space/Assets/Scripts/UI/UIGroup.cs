using UnityEngine;
using UnityEngine.Animations;

public class UIGroup : MonoBehaviour
{
    [SerializeField] public string name;
    [SerializeField] public CanvasGroup canvasGroup;

    public virtual void UpdateUI <T> (bool active, T param)
    {

    }

    public virtual void UpdateUI(bool active, Player thePlayer)
    {

    }

	public virtual void UpdateUI(bool active)
	{
        canvasGroup.alpha = active ? 1 : 0;
        canvasGroup.interactable = active;
        canvasGroup.blocksRaycasts = active;
	}
}
