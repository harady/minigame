using UnityEngine;

public abstract class PageBase : MonoBehaviour
{
    public virtual void Show(object data = null)
    {
        gameBject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameBject.SetActive(false);
    }
}