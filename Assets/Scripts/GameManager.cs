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
  static GameManager instance;
  public GameObject lightOfCrystals;
  public bool isActive;
  [SerializeField]public int lights;
  protected override void  Awake() {
      base.Awake();
  }
  void Start()
  {
    if (instance != null)
    {
      isActive = false;
      Destroy(gameObject);
    }
    else
    {
      instance = this;
      lights = 5;
      isActive = true;
      DontDestroyOnLoad(this);
    }
  }

  public void updateLightSize(){
    lights++;
    if (lightOfCrystals.activeSelf) {
      float scaleX = lightOfCrystals.transform.localScale.x;
      lightOfCrystals.transform.localScale = new Vector3(scaleX + 0.3f,scaleX + 0.3f, 1f);
    } else {
      print("null");
    }
  }
}