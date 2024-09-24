using UnityEngine;
using UnityEngine.UI;

public class PlayerHeightDisplay : MonoBehaviour
{
    public Transform playerTransform;
    public Text heightText;

    private float initialHeight;
    private bool isFalling = false;

    public Animator playerAnimator;
    public string fallAnimationTrigger = "Fall";
    void Start()
    {
        if (playerTransform != null)
        {
            initialHeight = playerTransform.position.y;
        }
    }

    void Update()
    {
        if (playerTransform != null && heightText != null)
        {
            float playerHeightMeters = playerTransform.position.y - initialHeight;
            string heightString = "Wysokość gracza: " + playerHeightMeters.ToString("F2") + " m";
            heightText.text = heightString;

            if (playerHeightMeters < 0 && !isFalling)
            {
                playerAnimator.SetBool(fallAnimationTrigger, true);
                isFalling = true;
            }
            else if (playerHeightMeters >= 0 && isFalling)
            {
                playerAnimator.SetBool(fallAnimationTrigger, false);
                isFalling = false;
            }
        }
    }
}
