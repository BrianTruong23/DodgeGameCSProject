using UnityEngine;

public class SafeAreaController : MonoBehaviour
{
    [Header("Shrink Settings")]
    [SerializeField] float initialHalfWidth = 8f;
    [SerializeField] float minimumHalfWidth = 3f;
    [SerializeField] float shrinkRate = 0.35f;

    [Header("Optional Visuals")]
    [SerializeField] Transform leftBoundaryVisual;
    [SerializeField] Transform rightBoundaryVisual;
    [SerializeField] float boundaryVisualWidth = 0.12f;
    [SerializeField] float boundaryVisualHeight = 12f;
    [SerializeField] Color boundaryColor = new Color(1f, 0.25f, 0.25f, 0.85f);
    [SerializeField] float boundaryVisualY = -3.5f;
    [SerializeField] float boundaryVisualZ = 0f;

    public float CurrentHalfWidth { get; private set; }

    public float LeftBound => -CurrentHalfWidth;
    public float RightBound => CurrentHalfWidth;

    static Sprite boundarySprite;

    void Awake()
    {
        EnsureBoundaryVisuals();
        ResetArea();
    }

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }

        if (CurrentHalfWidth <= minimumHalfWidth)
        {
            return;
        }

        CurrentHalfWidth = Mathf.Max(
            minimumHalfWidth,
            CurrentHalfWidth - shrinkRate * Time.deltaTime
        );

        UpdateVisuals();
    }

    public void ResetArea()
    {
        CurrentHalfWidth = initialHalfWidth;
        UpdateVisuals();
    }

    public float GetSpawnX(float padding = 0f)
    {
        float left = LeftBound + padding;
        float right = RightBound - padding;

        if (right <= left)
        {
            return 0f;
        }

        return Random.Range(left, right);
    }

    void UpdateVisuals()
    {
        if (leftBoundaryVisual != null)
        {
            leftBoundaryVisual.position = new Vector3(LeftBound, boundaryVisualY, boundaryVisualZ);
        }

        if (rightBoundaryVisual != null)
        {
            rightBoundaryVisual.position = new Vector3(RightBound, boundaryVisualY, boundaryVisualZ);
        }
    }

    void EnsureBoundaryVisuals()
    {
        if (leftBoundaryVisual == null)
        {
            leftBoundaryVisual = CreateBoundaryVisual("LeftBoundary");
        }

        if (rightBoundaryVisual == null)
        {
            rightBoundaryVisual = CreateBoundaryVisual("RightBoundary");
        }
    }

    Transform CreateBoundaryVisual(string objectName)
    {
        GameObject visual = new GameObject(objectName);
        SpriteRenderer renderer = visual.AddComponent<SpriteRenderer>();
        renderer.sprite = GetBoundarySprite();
        renderer.color = boundaryColor;
        renderer.sortingOrder = 100;
        visual.transform.localScale = new Vector3(boundaryVisualWidth, boundaryVisualHeight, 1f);
        return visual.transform;
    }

    static Sprite GetBoundarySprite()
    {
        if (boundarySprite == null)
        {
            boundarySprite = Sprite.Create(
                Texture2D.whiteTexture,
                new Rect(0f, 0f, 1f, 1f),
                new Vector2(0.5f, 0.5f),
                1f
            );
        }

        return boundarySprite;
    }

    void OnValidate()
    {
        initialHalfWidth = Mathf.Max(0f, initialHalfWidth);
        minimumHalfWidth = Mathf.Clamp(minimumHalfWidth, 0f, initialHalfWidth);
        shrinkRate = Mathf.Max(0f, shrinkRate);
        boundaryVisualWidth = Mathf.Max(0.01f, boundaryVisualWidth);
        boundaryVisualHeight = Mathf.Max(0.01f, boundaryVisualHeight);
    }
}
