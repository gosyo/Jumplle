using UnityEngine;

public class Skill : MonoBehaviour
{
    public static Skill skillInstance;
    private void Awake()
    {
        skillInstance = GetComponent<Skill>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SuperJump(Rigidbody rigidbody, int JumpCount)
    {

        rigidbody.velocity = Vector2.up * JumpCount;
    }
}
