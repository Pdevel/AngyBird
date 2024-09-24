using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton class: GameManager

    public static GameManager Instance;

    void Awake ()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    #endregion

    Camera cam;

    public Ball ball;
    public Trajectory trajectory;
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    //---------------------------------------
    void Start ()
    {
        cam = Camera.main;
        ball.DesactivateRb ();
    }


    void Update ()
    {
        if (!isDragging && Input.GetMouseButtonDown(0)) {
            isDragging = true;
            OnDragStart ();
        }

        if (isDragging) {
            OnDrag ();
        }

        if (isDragging && Input.GetMouseButtonUp(0)) {
            isDragging = false;
            OnDragEnd ();
        }
    }

    //-Drag--------------------------------------
    void OnDragStart ()
    {
        ball.DesactivateRb ();
        startPoint = cam.ScreenToWorldPoint (Input.mousePosition);

        trajectory.Show ();
    }

    void OnDrag ()
    {
        endPoint = cam.ScreenToWorldPoint (Input.mousePosition);
        distance = Vector2.Distance (startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        Debug.DrawLine (startPoint, endPoint);

        trajectory.UpdateDots (ball.pos, force);
    }

    void OnDragEnd ()
    {
        ball.ActivateRb ();

        ball.Push (force);

        trajectory.Hide ();
    }

}
