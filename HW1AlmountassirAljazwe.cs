using Assets;
using UnityEngine;


// Quad Brush Sizes
enum QuadSize : int
{
    Small = 0,
    Medium = 1,
    Large = 2
};

public class HW1AlmountassirAljazwe : MonoBehaviour
{
    private int painterMode = -1;
    private Color painterColor = Color.red;
    private int painterSize = (int)QuadSize.Medium;

    // This variable is used to prevent anything from being drawn without the user drawing...
    // Without this, a drawing is drawn at the bottom left corner (0, 0)...
    // There could be a better way, but this does its job for now.
    private bool isDrawing = false;


    public float polygonRotationDegrees;

    // ------------------------------------------------------------------------------------------
    // These variables are used to hold coordinates of the starting and ending points of a line :
    // ------------------------------------------------------------------------------------------
    private float startingX;
    private float startingY;
    // ------------------------------------------------------------------------------------------
    private float endingX;
    private float endingY;
    // ------------------------------------------------------------------------------------------


    public float mousePositionX;
    public float mousePositionY;


    static Material drawMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.clearFlags = CameraClearFlags.Nothing;
        GL.Clear(false, true, Color.white, 0.0f);

        Debug.Log($"Painter Mode : {painterMode}");
        Debug.Log($"Starting x : {startingX}, Starting y : {startingY}");
        Debug.Log($"Ending x : {endingX}, Ending y : {endingY}");
    }

    // Update is called once per frame
    void Update()
    {

        int rightMouseButton = 0;
        int leftMouseButton = 1;
        Vector3 WorldPoint = new Vector3();

        switch (painterMode)
        {
            case 0:

                if (Input.GetMouseButtonDown(rightMouseButton))
                {
                    isDrawing = true;

                    WorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

                    mousePositionX = WorldPoint.x;
                    mousePositionY = WorldPoint.y;

                    // For organic lines...
                    startingX = endingX = mousePositionX;
                    startingY = endingY = mousePositionY;
                }

                if (Input.GetMouseButton(rightMouseButton))
                {
                    WorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

                    // Beginning of organic line will be the coordinates of the previous point's ending vertex :
                    startingX = endingX;
                    startingY = endingY;

                    // Ending of organic line will simply be the current mouse position :
                    endingX = WorldPoint.x;
                    endingY = WorldPoint.y;

                }

                break;

            case 1:

                if (Input.GetMouseButtonDown(rightMouseButton))
                {
                    isDrawing = true;

                    WorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

                    mousePositionX = WorldPoint.x;
                    mousePositionY = WorldPoint.y;
                }

                break;

            case 2:

                if (Input.GetMouseButtonDown(rightMouseButton))
                {
                    isDrawing = true;
                }

                if (Input.GetMouseButton(rightMouseButton))
                {

                    WorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

                    mousePositionX = WorldPoint.x;
                    mousePositionY = WorldPoint.y;
                }

                break;

            case 3:

                if (Input.GetMouseButtonDown(rightMouseButton))
                {
                    isDrawing = true;

                    WorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

                    mousePositionX = WorldPoint.x;
                    mousePositionY = WorldPoint.y;

                    startingX = WorldPoint.x;
                    startingY = WorldPoint.y;

                    endingX = WorldPoint.x;
                    endingY = WorldPoint.y;
                }

                if (Input.GetMouseButtonDown(leftMouseButton))
                {
                    WorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

                    endingX = WorldPoint.x;
                    endingY = WorldPoint.y;
                }

                break;

            case 4:

                if (Input.GetMouseButtonDown(rightMouseButton))
                {
                    isDrawing = true;

                    WorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

                    mousePositionX = WorldPoint.x;
                    mousePositionY = WorldPoint.y;
                }

                break;

            default:
                Debug.Log("No painter mode has been selected... Select a painter mode from the toolbox.");

                if (Input.GetMouseButtonDown(rightMouseButton))
                {
                    WorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

                    mousePositionX = WorldPoint.x;
                    mousePositionY = WorldPoint.y;
                }

                break;
        }

    }


    private void OnPostRender()
    {

        if (!drawMaterial)
        {
            Shader myShader = Shader.Find("Hidden/Internal-Colored");
            drawMaterial = new Material(myShader);
        }

        drawMaterial.SetPass(0);


        GL.LoadIdentity();

        // --------------------------------------------------------
        // (1) setting up projection matrix to orthographic projection:
        // --------------------------------------------------------
        UnityEngine.Matrix4x4 projM = Matrix4x4.identity;
        projM = UnityEngine.Matrix4x4.Ortho(0, 1, 0, 1, -1, 100);
        GL.LoadProjectionMatrix(projM);
        Camera.main.projectionMatrix = projM;
        // --------------------------------------------------------


        // --------------------------------------------------------
        // TODO : Understand what this code does, step by step.
        // --------------------------------------------------------
        // With the code commented out...
        // mouse at: x:408.6667 and y:124.3333
        // world pt at: x:0.4394266 and y:1.417226 and z:-9.699997

        // With the code uncommented...
        // mouse at: x: 530 and y:59.66665
        // world pt at: x: 0.5698925 and y:0.2002236 and z:0.6999969
        // --------------------------------------------------------
        // (2) setting up camera (view matrix) and resetting camera in unity
        // --------------------------------------------------------
        UnityEngine.Matrix4x4 modelviewM = Matrix4x4.identity;
        modelviewM = UnityEngine.Matrix4x4.LookAt(new Vector3(0, 0, -1), new Vector3(0, 0, 1), new Vector3(0, 1, 0));
        GL.modelview = modelviewM;
        Camera.main.worldToCameraMatrix = modelviewM;
        // --------------------------------------------------------

        // --------------------------------------------------------
        // (3) declaring and initializing the modelview matrix:
        // --------------------------------------------------------
        UnityEngine.Matrix4x4 MV;
        MV = Matrix4x4.identity;
        // --------------------------------------------------------

        float[] sizes = new float[3] { 0.02f, 0.035f, 0.05f };

        float toolboxWidth = 0.2f;
        float toolboxHeight = 1f;

        Toolbox tb = new Toolbox(painterColor, painterMode, painterSize);
        (painterMode, painterSize, painterColor) = tb.DrawToolboxAndReturnPainterMode(toolboxWidth, toolboxHeight, sizes, mousePositionX, mousePositionY);

        float size = sizes[painterSize];



        switch (painterMode)
        {
            case 0:

                if(isDrawing)
                {
                    OrganicLine organicLine = new OrganicLine();
                    organicLine.Draw(size, painterColor, startingX, startingY, endingX, endingY);
                }

                break;

            case 1:

                if (isDrawing)
                {
                    QuadBrush quadBrush = new QuadBrush();
                    quadBrush.Draw(size, size, painterColor, mousePositionX, mousePositionY);
                }

                break;

            case 2:

                if (isDrawing)
                {
                    QuadErase quadErase = new QuadErase();
                    quadErase.Draw(size, mousePositionX, mousePositionY);
                }

                break;

            case 3:

                if (isDrawing)
                {
                    StraightLine straightLine = new StraightLine();
                    straightLine.Draw(painterColor, startingX, startingY, endingX, endingY);
                }

                break;

            case 4:

                // Pushing and popping the matrix from the stack is done inside the polygon.Draw method...

                Vector3 translationToOriginVector = new Vector3(-mousePositionX, -mousePositionY, 0);
                UnityEngine.Matrix4x4 translationToOriginMatrix = UnityEngine.Matrix4x4.Translate(translationToOriginVector);

                Quaternion rotation = Quaternion.Euler(0, 0, polygonRotationDegrees);
                UnityEngine.Matrix4x4 rotationMatrix = UnityEngine.Matrix4x4.Rotate(rotation);

                Vector3 translationBackToMousePointVector = new Vector3(mousePositionX, mousePositionY, 0);
                UnityEngine.Matrix4x4 translationBackToMousePointMatrix = UnityEngine.Matrix4x4.Translate(translationBackToMousePointVector);

                MV = translationBackToMousePointMatrix * rotationMatrix * translationToOriginMatrix * GL.modelview;
                GL.modelview = MV;

                if (isDrawing)
                {
                    Polygon polygon = new Polygon();
                    polygon.Draw(mousePositionX, mousePositionY);
                }

                break;

            default:

                Debug.Log("No painter mode has been selected... Select a painter mode from the toolbox.");
                break;
        }
    }

}
