using UnityEngine;
using UnityEngine.Assertions;

public abstract class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static T _instance;

    public static T GetInstance()
    {
        if (_instance == null)
        {
            var objects = FindObjectsByType<T>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None
            );

            if (objects.Length == 0)
            {
                Assert.IsNotNull(
                    _instance,
                    typeof(T).Name
                        + ": No object of this type found.  Make sure to add one to the Controllers root gameObject."
                );
                throw new System.NullReferenceException();
            }

            if (objects.Length > 1)
            {
                Assert.IsNotNull(
                    _instance,
                    typeof(T).Name + ": Too many of this singleton found " + objects.Length
                );
                throw new System.NullReferenceException();
            }

            _instance = objects[0];
        }

        return _instance;
    }

    // protected virtual void Awake()
    // {
    //     if (_instance != null && _instance != this)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }

    //     _instance = this as T;
    //     DontDestroyOnLoad(gameObject);
    // }
}
