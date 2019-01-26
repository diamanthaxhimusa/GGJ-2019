using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Object
{
  #region Member Variables

  private static T instance;

  #endregion

  #region Properties

  public static T Instance
  {
    get
    {
      // If the instance is null then either Instance was called to early or this object is not active.
      if (instance == null)
      {
        instance = GameObject.FindObjectOfType<T>();

      }
      if (instance == null)
      {
        Debug.LogWarningFormat("[SingletonComponent] Returning null instance for component of type {0}.", typeof(T));
      }
      return instance;
    }
  }

  #endregion

  #region Unity Methods

  protected virtual void Awake()
  {
    SetInstance();
  }

  #endregion

  #region Public Methods

  public static bool Exists()
  {
    return instance != null;
  }

  public bool SetInstance()
  {
    if (instance != null && instance != gameObject.GetComponent<T>())
    {
      Debug.LogWarning("[SingletonComponent] Instance already set for type " + typeof(T));

      return false;
    }

    instance = gameObject.GetComponent<T>();
    // DontDestroyOnLoad(gameObject);
    return true;
  }
  #endregion
}
public sealed class GameManager : Singleton<GameManager>
{
  [SerializeField]private int lights = 5;

  public int Lights { get => lights; set => lights = value; }
}