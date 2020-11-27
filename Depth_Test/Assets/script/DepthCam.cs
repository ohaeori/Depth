using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(Camera))]
/*
 * ExecuteInEditMode
 * 스크립트가 에디터 모드에서 작동하도록 설정.
 * 기본 설정으로 스크립트 컴포넌트는 플레이모드에서만 동작.
 * 
 * RequireComponent(typeof(Camera))
 * Camera 컴포넌트가 자동으로 게임오브젝트에 추가됨. 설정오류 피하기 위함.
 */
public class DepthCam : MonoBehaviour
{
    [SerializeField] //private 필드 직렬화. inspector에서 해당 필드 노출(원래는 public만). 유니티는 사용자의 모든 스크립트 컴포턴트 직렬화.
    private Color background = Color.black;
    [SerializeField]
    private Camera OriginCam;

    private enum ChannelState
    {
        depth = 0,
        invertedDepth = 1,
        sourceImage = 2,
        disabled = 3
    }

    [SerializeField]
    private ChannelState redChannel;
    [SerializeField, Range(0f, 0.99f), Tooltip("Clamp minimum distance")]
    private float rMin = 0f;
    [SerializeField, Range(0.01f, 1f), Tooltip("Clamp maximum distance")]
    private float rMax = 1f;

    [SerializeField]
    private ChannelState greenChannel;
    [SerializeField, Range(0f, 0.99f), Tooltip("Clamp minimum distance")]
    private float gMin = 0f;
    [SerializeField, Range(0.01f, 1f), Tooltip("Clamp maximum distance")]
    private float gMax = 1f;

    [SerializeField]
    private ChannelState blueChannel;
    [SerializeField, Range(0f, 0.99f), Tooltip("Clamp minimum distance")]
    private float bMin = 0f;
    [SerializeField, Range(0.01f, 1f), Tooltip("Clamp maximum distance")]
    private float bMax = 1f;

    [Header("Debug Draw")]
    [SerializeField, Range(0, 4), Tooltip("0 disables GUI")]
    private int GUIMagnification = 0;
    [SerializeField]
    private Vector2Int GUIPosition = new Vector2Int(0, 0);
    private bool drawGUI;
    private Rect guiRect;

    [Space, SerializeField]
    private RenderTexture renderTexture;
    [SerializeField]
    Shader shader;//모든 렌더링에 사용되는 셰이더 스크립트. 고급 렌더링은 대부분 Material 클래스를 통해. Material이 존재여부를 체크하는데 사용됨.
    private Material material;// inspector 뷰를 통해 접근할 수 없는 사용자 정의 shader 속성도 설정가능. 오브젝트의 속성을 받아옴.

    private void ApplySettings()
    {
        drawGUI = GUIMagnification > 0;
        if (drawGUI)
        {
            int w = renderTexture.width;
            int h = renderTexture.height;
            int m = GUIMagnification;
            //x, y좌표, width, height
            guiRect = new Rect(GUIPosition.x * w * m, GUIPosition.y * h * m, w * m, h * m);
        }

        if (material == null)
        {
            material = new Material(shader);
            material.hideFlags = HideFlags.DontSave;//해닫 객체는 수동으로 제거됨.
        }
        
        Camera cam = GetComponent<Camera>();
        cam.depthTextureMode = DepthTextureMode.Depth;//depth texture 생성
        cam.targetTexture = renderTexture;

        material.SetColor("_Color", background);
        material.SetInt("_R_State", (int)redChannel);
        material.SetFloat("_R_Min", rMin);
        material.SetFloat("_R_Max", rMax);
        material.SetInt("_G_State", (int)greenChannel);
        material.SetFloat("_G_Min", gMin);
        material.SetFloat("_G_Max", gMax);
        material.SetInt("_B_State", (int)blueChannel);
        material.SetFloat("_B_Min", bMin);
        material.SetFloat("_B_Max", bMax);
    }

    private void Awake()
    {
        ApplySettings();
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material, 0);
    }

    private void OnValidate()
    {
        rMax = Mathf.Max(rMin + 0.01f, rMax);
        gMax = Mathf.Max(gMin + 0.01f, gMax);
        bMax = Mathf.Max(bMin + 0.01f, bMax);

        ApplySettings();
    }

    private void OnGUI()
    {
        if (drawGUI)
        {
            GUI.DrawTexture(guiRect, renderTexture);
        }
    }

    private void OnDestroy()
    {
        if (material != null)
        {
            if (Application.isPlaying)
            {
                Destroy(material);
            }
            else
            {
                DestroyImmediate(material);
            }
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(OriginCam.transform.position.x, OriginCam.transform.position.y, OriginCam.transform.position.z);
        transform.rotation = new Quaternion(OriginCam.transform.rotation.x, OriginCam.transform.rotation.y, OriginCam.transform.rotation.z, OriginCam.transform.rotation.w);

        Camera cam = GetComponent<Camera>();
        cam.fieldOfView = OriginCam.fieldOfView;
        cam.farClipPlane = OriginCam.farClipPlane;
    }
}