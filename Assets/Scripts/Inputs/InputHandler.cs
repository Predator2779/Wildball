using Controllers;
using UnityEngine;
using GlobalVars;
using Managers;

// using Photon.Pun;

[RequireComponent(typeof(BallBehaviour))]
public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    
    // private PhotonView _photonView;
    private BallBehaviour _ballBehaviour;
    private CameraController _cameraController;
    private SphereScaler _sphereScaler;

    private float _holdTime;
    
    private void Awake()
    {
        Cursor.visible = false;

        if (_gameSettings == null)
            _gameSettings = FindObjectOfType<GameSettings>();
        
        // _photonView = GetComponent<PhotonView>();
        _ballBehaviour = GetComponent<BallBehaviour>();
        _cameraController = _ballBehaviour.wildCamera.GetComponent<CameraController>();
        _sphereScaler = GetComponent<SphereScaler>();
    }

    private void Update()
    {
        //if (!_photonView.IsMine) return;

        if (_ballBehaviour.isDeath || _gameSettings.CurrentMode != GameSettings.GameModes.Playing) return;

        MouseScrollWheel();
        
        GetJumpButton();
        GetShiftButton();

        GetQ();
        GetE();
        GetX();
    }

    private void LateUpdate()
    {
        //if (!_photonView.IsMine) return;
        
        CameraControl();
    }

    private void FixedUpdate()
    {
        //if (!_photonView.IsMine) return;
        
        Movement();
    }

    private void Movement()
    {
        var verticalAxis = Input.GetAxis(GlobalVariables.VerticalAxis);
        var horizontalAxis = Input.GetAxis(GlobalVariables.HorizontalAxis);

        _ballBehaviour.Move(verticalAxis, horizontalAxis);
        _ballBehaviour.GroundControl();
    }

    private void CameraControl()
    {
        var mouse_X = Input.GetAxis(GlobalVariables.MouseX);
        var mouse_Y = Input.GetAxis(GlobalVariables.MouseY);

        _cameraController.CameraControl(mouse_X, mouse_Y);
    }

    private void GetJumpButton()
    {
        if (Input.GetButton(GlobalVariables.JumpButton))
            HoldJump();

        if (Input.GetButtonUp(GlobalVariables.JumpButton))
        {
            _ballBehaviour.Jump(_holdTime);
            _holdTime = 0;
        }
    }

    private void HoldJump() => _holdTime += Time.deltaTime;
    
    private void GetShiftButton()
    {
        _ballBehaviour.Acceleration(Input.GetKey(KeyCode.LeftShift));

        var verticalAxis = Input.GetAxis(GlobalVariables.VerticalAxis);
        var horizontalAxis = Input.GetAxis(GlobalVariables.HorizontalAxis);
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _ballBehaviour.Boost(verticalAxis, horizontalAxis);
    }

    private void MouseScrollWheel()
    {
        var scrollWheel = Input.GetAxis(GlobalVariables.MouseScrollWheel);

        if (scrollWheel != 0)
            _sphereScaler.ScaleWheel(scrollWheel * 5);
    }

    private void GetQ()
    {
        if (Input.GetKeyUp(KeyCode.Q))
            _sphereScaler.SetScaleAndWeight(1.0f, 10.0f);
    }

    private void GetX()
    {
        if (Input.GetKeyUp(KeyCode.X))
            _sphereScaler.SetScaleAndWeight(3.0f, 10.0f);
    }

    private void GetE()
    {
        if (Input.GetKeyUp(KeyCode.E))
            _sphereScaler.SetScaleAndWeight(9.0f, 350.0f);
    }
}