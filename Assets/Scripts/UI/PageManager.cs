using UnityEngine;
using System;
using System.Collections.Generic;
using System;

public sealed class PageManager : MonoBehaviour
{
    public static PageManager Instance { get; private set; }

    [SerializeField("pageRoot")]
    private Transform pageRoot;

    [SerializeField("pagePrefabs"]
    private List<PageBase> pagePrefabs;

    private Dictionary<Type, PageBase> prefabMap = new();
    private PageBase current;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameBject);
            return;
        }
        Instance = this;

        foreach (var page in pagePrefabs)
        {
            prefabMap[page.GetType()] = page;
        }
    }

    public void Show<T>(object data = null) where T : PageBase
    {
        Type type = typeof(T);

        if (!prefabMap.TryGetValue(type, out PageBase prefab))
        {
            Debug.LogError("PageManager: No prefab found for type " + type.name);
            return;
        }

        if (current != null)
        {
            Destroy(current.gameBject);
            current = null;
        }

        current = Instantiate(prefab, pageRoot);
        current.Show(data);
    }
}