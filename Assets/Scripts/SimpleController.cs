using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using Photon.Pun;

public class SimpleController : MonoBehaviourPunCallbacks, IPunObservable
{
    private PlayerInputActions _inputActions;

    private Transform _transform;
    private Vector2 _direction;
    public Vector3 screenPosition;
    private Color color = new Color(.5f,.5f,.5f);

    private void Awake()
    {
        _inputActions = new PlayerInputActions();

        _transform = this.transform;
    }

    private void OnEnable()
    {
        //var foo = photonView.IsMine;
        //Debug.LogFormat("isMine is {0}", foo);
        _inputActions.Game.Enable();

        _inputActions.Game.Move.performed += OnMove;
        _inputActions.Game.Move.canceled += OnMove; // We need an event for when you STOP sending a direction, otherwise it won't get reset to (0,0) (eg. letting go of stick)
        _inputActions.Game.Attack.performed += OnAttack;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(screenPosition.x, screenPosition.y, 100, 20), PhotonNetwork.NickName);
    }

    private void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            // skip if instance is not controlled by the player (only when connected, not for local development)
            return;
        }
        // update position
        float frameRateScaler = 10 * Time.deltaTime;
        _transform.position += new Vector3(_direction.x, _direction.y, 0) * frameRateScaler;

        // update color
        Material mat = GetComponent<SpriteShapeRenderer>().material;
        if (mat != null) mat.color = this.color;

        screenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        screenPosition.y = Screen.height - screenPosition.y;

    }

    // IPunObservable Methods
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // if (stream.IsWriting)
        // {
        //     stream.SendNext(this.color.r);
        // }
        // else
        // {
        //     this.color = (Color)stream.ReceiveNext();
        // }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext _)
    {
        // Setting a random color yay
        this.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    private void OnDisable()
    {
        _inputActions.Game.Attack.performed -= OnAttack;
        _inputActions.Game.Move.canceled -= OnMove;
        _inputActions.Game.Move.performed -= OnMove;

        _inputActions.Game.Disable();
    }
}
