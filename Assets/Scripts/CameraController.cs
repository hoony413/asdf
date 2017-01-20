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
    readonly string jpg = ".jpg";
    readonly string png = ".png";
    readonly string DCIM = "/mnt/sdcard/DCIM/Camera/";
    readonly string filePath = "C:/Certpia/";
    readonly string fileName = "Picture_";
    //Quaternion rotation = Quaternion.Euler(0, 0, 90);

    WebCamDevice[] device;
    WebCamTexture cam;
    public WebCamTexture Cam
    {
        get { return cam; }
    }

    FilterPool filterPool = new FilterPool();

    public Material mt;
    public Transform Plane;

    public const int PresetCount = 3;
    public StringBuilder sb = new StringBuilder();

    List<Preset> presetList = new List<Preset>();
    /*
    Vector3 sero = new Vector3(1f, 1.6f, 1f);
    Vector3 garo = new Vector3(2.6f, 1.5f, 1f);
    */

    public Dictionary<FilterPool.eFilter, MonoBehaviour> DicFilter = new Dictionary<FilterPool.eFilter, MonoBehaviour>();

    void Start ()
    {
        int iMaxSize = Mathf.Max(Screen.width, Screen.height);
        int iMinSize = Mathf.Min(Screen.width, Screen.height);
        float fRatio = (float)iMaxSize / (float)iMinSize;
        Plane.localScale = new Vector3(fRatio, 1f, 1f);

        cam = new WebCamTexture(Mathf.FloorToInt(fRatio * 720), 720, 60);
        filterPool.SetUp(); // 필터 최초 등록.

        _DefaultPreset defaultp = new _DefaultPreset(); //프리셋 생성
        defaultp.BackupDefaultData();
        presetList.Add(defaultp);

        _GrayScale grayscale = new _GrayScale(); //프리셋 생성
        grayscale.BackupDefaultData();
        presetList.Add(grayscale);

        _SepiaTone sepiatone = new _SepiaTone(); //프리셋 생성
        sepiatone.BackupDefaultData();
        presetList.Add(sepiatone);

        device = WebCamTexture.devices;
        if (device.Length > 0)
        {
            cam.deviceName = device[0].name;
            cam.Play();
        }
        
        mt.mainTexture = cam;
    }
	
	void FixedUpdate ()
    {

    }

    static int takeCount = 0;
    public void TakePicture()
    {
        StartCoroutine(CorNextFrame());

        Texture2D tex = new Texture2D(cam.width, cam.height);
        tex.SetPixels(cam.GetPixels());
        tex.Apply();

        sb.Length = 0;
//#if UNITY_EDITOR
//        sb.Append(filePath);
//#elif UNITY_ANDROID
        sb.Append("/mnt/sdcard/Android/data/com.MyFirst.Camme/files/DCIM/Camera");
//#endif
        if (!System.IO.Directory.Exists(sb.ToString()))
            System.IO.Directory.CreateDirectory(sb.ToString());

        byte[] bytes = tex.EncodeToPNG();
        System.IO.File.WriteAllBytes("pic_" + takeCount.ToString() + ".jpg", bytes);
    
        /*
        Texture2DToAndroidBitmap(tex);
        SaveImageToGallery(tex, "abc", "def");
        */
        takeCount++;
        //cam.Play();
        sb.Length = 0;
    }

    IEnumerator CorNextFrame()
    {
        yield return new WaitForEndOfFrame();
    }
    public void SwitchCamera()
    {

    }

    public void Drag()
    {
    }

    public void ChangePreset()
    {
        Preset.currentIndex++;

        if ((int)Preset.currentIndex >= PresetCount)
            Preset.currentIndex = Preset.ePreset.Default;
        else if((int)Preset.currentIndex < 0)
            Preset.currentIndex = Preset.ePreset.MAX - 1;

        presetList[(int)Preset.currentIndex].SetData(Preset.currentIndex);
    }

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
        byte[] encoded = texture2D.EncodeToPNG();
        using (var bf = new AndroidJavaClass("android.graphics.BitmapFactory"))
        {
            return bf.CallStatic<AndroidJavaObject>("decodeByteArray", encoded, 0, encoded.Length);
        }
    }
}
