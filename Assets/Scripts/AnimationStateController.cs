using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            var action = this.actionKeyDown();
            if (action.HasValue)
            {
                // キー入力があればAnimatorにstateをセットする
                setStateToAnimator(vector: action.Value);
                return;
            }
        }

        // 入力からVector2インスタンスを作成
        var vector = new Vector2(
            (int) Input.GetAxis("Horizontal"),
            (int) Input.GetAxis("Vertical"));

        // キー入力が続いている場合は、入力から作成したVector2を渡す
        // キー入力がなければ null
        setStateToAnimator(vector: vector != Vector2.zero ? vector : (Vector2?) null);
    }

    private void setStateToAnimator(Vector2? vector)
    {
        if (!vector.HasValue)
        {
            this.animator.speed = 0.0f;
            return;
        }

        //Debug.Log(vector.Value);
        this.animator.speed = 1.0f;
        this.animator.SetFloat("x", vector.Value.x);
        this.animator.SetFloat("y", vector.Value.y);
    }

    private Vector2? actionKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) return Vector2.up;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) return Vector2.left;
        if (Input.GetKeyDown(KeyCode.DownArrow)) return Vector2.down;
        if (Input.GetKeyDown(KeyCode.RightArrow)) return Vector2.right;
        return null;
    }
}
