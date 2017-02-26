using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
//using UnityStandardAssets.ImageEffects;

public class CameraController : MonoBehaviour
{
    #region singleton
    private static CameraController s_instance;
    public static CameraController instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = GameObject.FindObjectOfType(typeof(CameraController)) as CameraController;
                if (s_instance == null)
                {
                    GameObject container = new GameObject();
                    container.name = "CameraController";
                    s_instance = container.AddComponent(typeof(CameraController)) as CameraController;
                }
            }

            return s_instance;
        }

    }

    private void OnDestroy()
    {
        s_instance = null;
    }

    #endregion
    public static readonly string jpg = ".jpg";

    public StringBuilder sb = new StringBuilder();
    public UILabel LbLog;

    FilterPool filterPool = new FilterPool();
    List<Preset> presetList = new List<Preset>();

    public Dictionary<FilterPool.eFilter, MonoBehaviour> DicFilter = new Dictionary<FilterPool.eFilter, MonoBehaviour>();

    void RegistPreset<T> () where T : Preset
    {
        T t = System.Activator.CreateInstance<T>();
        t.BackupDefaultData();
        presetList.Add(t);
    }

    private void Awake()
    {
        filterPool.SetUp(); // 필터 최초 등록.

        RegistPreset<_Bloom>();
        RegistPreset<_Blur>();
        RegistPreset<_ColorCorrectionsCurve>();
        RegistPreset<_ConstrastEnhance>();
        RegistPreset<_CreaseShading>();
        RegistPreset<_DefaultPreset>();
        RegistPreset<_DepthOfField>();
        RegistPreset<_EdgeDetection>();
        RegistPreset<_Fisheye>();
        RegistPreset<_GrayScale>();
        RegistPreset<_SepiaTone>();
        RegistPreset<_TiltShift>();
        RegistPreset<_ToneMapping>();
        RegistPreset<_VignetteAndChromaticAberration>();

        cameraIndex = 0;
    }

    WebCamTexture cam;
    WebCamDevice[] device;

    public WebCamTexture Cam { get { return cam; } }
    public Transform Plane;
    public Material mt;
    void Start ()
    {
        int iMaxSize = Mathf.Max(Screen.width, Screen.height);
        int iMinSize = Mathf.Min(Screen.width, Screen.height);

        float fRatio = (float)(iMaxSize) / (float)(iMinSize);

        Plane.localScale = new Vector3(1f * fRatio, 1f, 1f);

        Resolution res = Screen.currentResolution;
        cam = new WebCamTexture(iMinSize, iMaxSize, res.refreshRate);
        Screen.SetResolution(iMinSize, iMaxSize, true, 60);

        device = WebCamTexture.devices;
        if (device.Length > 0)
        {
            cam.deviceName = device[cameraIndex].name;
            cam.Play();
        }
        
        mt.mainTexture = cam;
    }

    public void TakePicture()
    {
        StartCoroutine(TakePic());
    }

    IEnumerator TakePic()
    {
        yield return new WaitForFixedUpdate();

        Texture2D tex = new Texture2D(cam.width, cam.height);
        tex.SetPixels(cam.GetPixels());
        tex.Apply();

        SaveImageToGallery(tex, Application.persistentDataPath + System.DateTime.Now.ToString() + jpg, "");
        sb.Length = 0;
    }

    int cameraIndex;
    public void SwitchCamera()
    {
        cam.Stop();
        if (cameraIndex == 0)
            cameraIndex = 1;
        else if (cameraIndex == 1)
            cameraIndex = 0;

        if (cameraIndex <= device.Length)
        {
            cam.Play();
            return;
        }

        cam.deviceName = device[cameraIndex].name;
        cam.Play();
    }

    public void Drag()
    {
    }

    public void ChangePreset()
    {
        Preset.currentIndex++;

        if ((int)Preset.currentIndex >= (int)Preset.ePreset.MAX)
            Preset.currentIndex = Preset.ePreset.Bloom;
        else if((int)Preset.currentIndex < (int)Preset.ePreset.Bloom)
            Preset.currentIndex = Preset.ePreset.MAX - 1;

        presetList[(int)Preset.currentIndex].SetData(Preset.currentIndex);
        LbLog.text = Preset.currentIndex.ToString();
    }

    #region Android_GallerySave
    private const string MediaStoreImagesMediaClass = "android.provider.MediaStore$Images$Media";
    static AndroidJavaObject _activity;
    public static AndroidJavaObject Activity
    {
        get
        {
            if (_activity == null)
            {
                var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                _activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            }
            return _activity;
        }
    }

    public static string SaveImageToGallery(Texture2D texture2D, string title, string description)
    {
        using (var mediaClass = new AndroidJavaClass(MediaStoreImagesMediaClass))
        {
            using (var cr = Activity.Call<AndroidJavaObject>("getContentResolver"))
            {
                var image = Texture2DToAndroidBitmap(texture2D);
                var imageUrl = mediaClass.CallStatic<string>("insertImage", cr, image, title, description);
                return imageUrl;
            }
        }
    }

    public static AndroidJavaObject Texture2DToAndroidBitmap(Texture2D texture2D)
    {
        byte[] encoded = texture2D.EncodeToJPG(100);
        using (var bf = new AndroidJavaClass("android.graphics.BitmapFactory"))
        {
            return bf.CallStatic<AndroidJavaObject>("decodeByteArray", encoded, 0, encoded.Length);
        }
    }
    #endregion
}
