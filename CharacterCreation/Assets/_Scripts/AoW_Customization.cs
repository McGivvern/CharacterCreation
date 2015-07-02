using UnityEngine;
using UnityEngine.UI;
using UMA;
using System.Collections.Generic;
using System.Linq;

public class AoW_Customization : MonoBehaviour
{
    #region Sliders
    private Slider _heightSlider;
    private Slider _upperMuscleSlider;
    private Slider _upperWeightSlider;
    private Slider _lowerMuscleSlider;
    private Slider _lowerWeightSlider;
    private Slider _armLengthSlider;
    private Slider ForearmLengthSlider;
    private Slider LegSeparationSlider;
    private Slider HandSizeSlider;
    private Slider FeetSizeSlider;
    private Slider LegSizeSlider;
    private Slider ArmWidthSlider;
    private Slider ForearmWidthSlider;
    private Slider BreastSlider;
    private Slider BellySlider;
    private Slider WaistSizeSlider;
    private Slider GlueteusSizeSlider;
    private Slider HeadSizeSlider;
    private Slider NeckThickSlider;
    private Slider EarSizeSlider;
    private Slider EarPositionSlider;
    private Slider EarRotationSlider;
    private Slider NoseSizeSlider;
    private Slider NoseCurveSlider;
    private Slider NoseWidthSlider;
    private Slider NoseInclinationSlider;
    private Slider NosePositionSlider;
    private Slider NosePronuncedSlider;
    private Slider NoseFlattenSlider;
    private Slider ChinSizeSlider;
    private Slider ChinPronouncedSlider;
    private Slider ChinPositionSlider;
    private Slider MandibleSizeSlider;
    private Slider JawSizeSlider;
    private Slider JawPositionSlider;
    private Slider CheekSizeSlider;
    private Slider CheekPositionSlider;
    private Slider lowCheekOutSlider;
    private Slider ForeHeadSizeSlider;
    private Slider ForeHeadPositionSlider;
    private Slider LipSizeSlider;
    private Slider MouthSlider;
    private Slider EyeSizeSlider;
    private Slider EyeRotationSlider;
    private Slider EyeSpacingSlider;
    private Slider LowCheekPosSlider;
    private Slider HeadWidthSlider;
    #endregion

    #region general private variables
    private string _bodyTargetPath = "Root/Global/Position/Hips/LowerBack/Spine/SpineAdjust";
    private string _headTargetPath = "Root/Global/Position/Hips/LowerBack/Spine/Spine1/Neck/Head/HeadAdjust";

    private UMADnaHumanoid _umaDna;

    private GameObject _orbitCamera;
    private CameraController _orbitCameraScript;

    private GameObject maleAvatarSpawn;
    private GameObject maleAvatar;
    private Transform maleAvatarHead;
    private Transform maleAvatarBody;
    private GameObject femaleAvatarSpawn;
    private GameObject femaleAvatar;
    private Transform femaleAvatarHead;
    private Transform femaleAvatarBody;

    private bool _hasCreatedMale = false;
    private bool _hasCreatedFemale = false;
    private bool _hasSelectedHead = false;

    private UITextList _characterNameHolder;
    private bool _hasName = false;
    #endregion

    public UMAData UmaData;
    public UMADynamicAvatar UmaDynamicAvatar;
    public RaceLibrary RaceLibrary;
    public SlotLibrary SlotLibrary;
    public OverlayLibrary OverlayLibrary;
    public UMAGeneratorBase Generator;
    public float AtlasResolutionScale;
    [HideInInspector]public GameObject MaleGO;
    [HideInInspector]public GameObject FemaleGO;

    public GameObject MaleHeadPanel;
    public GameObject MaleBodyPanel;
    public GameObject FemaleHeadPanel;
    public GameObject FemaleBodyPanel;
    public RuntimeAnimatorController AnimationController;


    [HideInInspector]public bool BodyCameraSet = false;
    [HideInInspector]public bool HeadCameraSet = false;

    public Color SkinColor;
    [HideInInspector]public string SelectedGender = "";

    public List<Color> EyeColors;
    public List<Color> HairColors;
    public List<Color> SkinTones;
    public List<Color> ShirtColors;
    public List<Color> PantsColors;
    public List<Color> UnderwearColors;
    public List<Color> LipstickColors;

    public List<string> LipstickTextures;
    public List<string> EyeballTextures;
    public List<string> EyeballTexturesAdjust;

    #region Male Specific Variables
    // Male-specific
    public List<string> MaleEyeballs;
    public List<string> MaleEyesockets;
    public List<string> MaleEars;
    public List<string> MaleNoses;
    public List<string> MaleMouths;
    public List<string> MaleBodyMeshes;
    public List<string> MaleHands;
    public List<string> MaleLegs;
    public List<string> MaleFeet;
    public List<string> MaleHeadMeshes;
    public List<string> MaleHeadTextures;
    public List<string> MaleHairStyles;
    public List<string> MaleBeardStyles;
    public List<string> MaleEyebrows;
    public List<string> MaleBodies;
    public List<string> MaleShirts;
    public List<string> MalePants;
    public List<string> MaleUnderwear;

    private UMADnaHumanoid _savedMaleUmaDna;

    int selectedMaleEyeballs = 0;
    int selectedMaleEyeballTexture = 0;
    int selectedMaleEyeballTextureAdjust = 0;
    int selectedMaleEyesockets = 0;
    int selectedMaleEars = 0;
    int selectedMaleNose = 0;
    int selectedMaleMouth = 0;
    int selectedMaleBodyMesh = 0;
    int selectedMaleHands = 0;
    int selectedMaleLegs = 0;
    int selectedMaleFeet = 0;

    int selectedMaleEyeColor = 0;
    int selectedMaleHeadMesh = 0;
    int selectedMaleHeadTexture = 0;
    int selectedMaleHairColor = 0;
    int selectedMaleHairStyle = 0;
    int selectedMaleBeardStyle = 0;
    int selectedMaleEyebrow = 0;
    int selectedMaleBody = 0;
    int selectedMaleSkinTone = 0;

    int selectedMaleShirt = 0;
    int selectedMaleShirtColor = 0;

    int selectedMalePants = 0;
    int selectedMalePantsColor = 0;

    int selectedMaleUnderwear = 0;
    int selectedMaleUnderwearColor = 0;
    #endregion
    #region Female Specific Variables
    // Female-specific
    public List<string> FemaleEyeballs;
    public List<string> FemaleEyesockets;
    public List<string> FemaleEars;
    public List<string> FemaleNoses;
    public List<string> FemaleMouths;
    public List<string> FemaleBodyMeshes;
    public List<string> FemaleHands;
    public List<string> FemaleLegs;
    public List<string> FemaleFeet;
    public List<string> FemaleHeadMeshes;
    public List<string> FemaleHeadTextures;
    public List<string> FemaleHairStyles;
    public List<string> FemaleEyebrows;
    public List<string> FemaleBodies;
    public List<string> FemaleShirts;
    public List<string> FemalePants;
    public List<string> FemaleUnderwear;

    private UMADnaHumanoid _savedFemaleUmaDna;

    private int _selectedFemaleEyeballs = 0;
    private int _selectedFemaleEyeballTexture = 0;
    private int _selectedFemaleEyeballTextureAdjust = 0;
    private int _selectedFemaleEyesockets = 0;
    private int _selectedFemaleEars = 0;
    private int _selectedFemaleNose = 0;
    private int _selectedFemaleMouth = 0;
    private int _selectedFemaleBodyMesh = 0;
    private int _selectedFemaleLipstickTexture = 0;
    private int _selectedFemaleHands = 0;
    private int _selectedFemaleLegs = 0;
    private int _selectedFemaleFeet = 0;
    private int _selectedFemaleEyeColor = 0;
    private int _selectedFemaleHeadMesh = 0;
    private int _selectedFemaleHeadTexture = 0;
    private int _selectedFemaleLipstickColor = 0;
    private int _selectedFemaleHairColor = 0;
    private int _selectedFemaleHairStyle = 0;
    private int _selectedFemaleEyebrow = 0;
    private int _selectedFemaleBody = 0;
    private int _selectedFemaleSkinTone = 0;
    private int _selectedFemaleShirt = 0;
    private int _selectedFemaleShirtColor = 0;
    private int _selectedFemalePants = 0;
    private int _selectedFemalePantsColor = 0;
    private int _selectedFemaleUnderwear = 0;
    private int _selectedFemaleUnderwearColor = 0;
    #endregion



    void Awake()
    {
        #region get the sliders and store for later use
        //Get a reference to the Basic Panel Sliders
        HeadSizeSlider = GameObject.Find("HeadSizeSlider").GetComponent<Slider>();
        HeadWidthSlider = GameObject.Find("HeadWidthSlider").GetComponent<Slider>();
        _heightSlider = GameObject.Find("HeightSlider").GetComponent<Slider>();

        //Get a reference to the Head Panel Sliders
        ForeHeadSizeSlider = GameObject.Find("ForeheadSizeSlider").GetComponent<Slider>();
        ForeHeadPositionSlider = GameObject.Find("ForeheadPositionSlider").GetComponent<Slider>();
        NoseSizeSlider = GameObject.Find("NoseSizeSlider").GetComponent<Slider>();
        EyeSizeSlider = GameObject.Find("EyeSizeSlider").GetComponent<Slider>();
        LipSizeSlider = GameObject.Find("LipsSizeSlider").GetComponent<Slider>();
        MouthSlider = GameObject.Find("MouthSizeSlider").GetComponent<Slider>();
        NoseCurveSlider = GameObject.Find("NoseCurveSlider").GetComponent<Slider>();
        NoseWidthSlider = GameObject.Find("NoseWidthSlider").GetComponent<Slider>();
        NoseInclinationSlider = GameObject.Find("NoseInclinationSlider").GetComponent<Slider>();
        NosePositionSlider = GameObject.Find("NosePositionSlider").GetComponent<Slider>();
        NosePronuncedSlider = GameObject.Find("NosePronouncedSlider").GetComponent<Slider>();
        NoseFlattenSlider = GameObject.Find("NoseFlattenSlider").GetComponent<Slider>();
        ChinSizeSlider = GameObject.Find("ChinSizeSlider").GetComponent<Slider>();
        ChinPronouncedSlider = GameObject.Find("ChinOutSlider").GetComponent<Slider>();
        ChinPositionSlider = GameObject.Find("ChinPositionSlider").GetComponent<Slider>();
        MandibleSizeSlider = GameObject.Find("MandibleSizeSlider").GetComponent<Slider>();
        JawSizeSlider = GameObject.Find("JawsSizeSlider").GetComponent<Slider>();
        JawPositionSlider = GameObject.Find("JawsPositionSlider").GetComponent<Slider>();
        CheekSizeSlider = GameObject.Find("CheekSizeSlider").GetComponent<Slider>();
        CheekPositionSlider = GameObject.Find("CheekPositionSlider").GetComponent<Slider>();
        lowCheekOutSlider = GameObject.Find("LowCheekOutSlider").GetComponent<Slider>();
        EarSizeSlider = GameObject.Find("EarsSizeSlider").GetComponent<Slider>();
        EarPositionSlider = GameObject.Find("EarsPositionSlider").GetComponent<Slider>();
        EarRotationSlider = GameObject.Find("EarsRotationSlider").GetComponent<Slider>();
        LowCheekPosSlider = GameObject.Find("LowCheekPositionSlider").GetComponent<Slider>();
        EyeRotationSlider = GameObject.Find("EyeRotationSlider").GetComponent<Slider>();

        //Get a reference to the Body Sliders
        NeckThickSlider = GameObject.Find("NeckThicknessSlider").GetComponent<Slider>();
        _upperMuscleSlider = GameObject.Find("UpperMuscleSlider").GetComponent<Slider>();
        _lowerMuscleSlider = GameObject.Find("LowerMuscleSlider").GetComponent<Slider>();
        BreastSlider = GameObject.Find("BreastSizeSlider").GetComponent<Slider>();
        _upperWeightSlider = GameObject.Find("UpperWeightSlider").GetComponent<Slider>();
        _lowerWeightSlider = GameObject.Find("LowerWeightSlider").GetComponent<Slider>();
        LegSizeSlider = GameObject.Find("LegsSizeSlider").GetComponent<Slider>();
        BellySlider = GameObject.Find("BellySlider").GetComponent<Slider>();
        WaistSizeSlider = GameObject.Find("WaistSlider").GetComponent<Slider>();
        GlueteusSizeSlider = GameObject.Find("GluteusSlider").GetComponent<Slider>();
        _armLengthSlider = GameObject.Find("ArmLengthSlider").GetComponent<Slider>();
        ArmWidthSlider = GameObject.Find("ArmWidthSlider").GetComponent<Slider>();
        ForearmLengthSlider = GameObject.Find("ForeArmLengthSlider").GetComponent<Slider>();
        ForearmWidthSlider = GameObject.Find("ForeArmWidthSlider").GetComponent<Slider>();
        HandSizeSlider = GameObject.Find("HandsSizeSlider").GetComponent<Slider>();
        LegSeparationSlider = GameObject.Find("LegSeparationSlider").GetComponent<Slider>();
        FeetSizeSlider = GameObject.Find("FeetSizeSlider").GetComponent<Slider>();
        #endregion

        //After getting a reference to the sliders, hide their panels
        GameObject.Find("BasicPanel").SetActive(false);
        GameObject.Find("HeadPanel").SetActive(false);
        GameObject.Find("BodyPanel").SetActive(false);
        //GameObject.Find("__CharacterCreationMenus").SetActive(false);

        //find the camera and get a reference to the CameraController script
        _orbitCamera = GameObject.Find("Orbit Camera");
        _orbitCameraScript = _orbitCamera.GetComponent<CameraController>();
        _orbitCameraScript.cameraTarget = GameObject.Find("Camera Target").transform;

        //Check if the UMA stuff we need is there, and if it is get a reference. if not throw an error
        RaceLibrary = GameObject.Find("RaceLibrary").GetComponent<RaceLibrary>();
        if (RaceLibrary == null)
            Debug.LogError("UMA: Race Library not Found!!!");

        SlotLibrary = GameObject.Find("SlotLibrary").GetComponent<SlotLibrary>();
        if (SlotLibrary == null)
            Debug.LogError("UMA: Slot Library not Found!!!");

        OverlayLibrary = GameObject.Find("OverlayLibrary").GetComponent<OverlayLibrary>();
        if (OverlayLibrary == null)
            Debug.LogError("UMA: Overlay Library not Found!!!");

        Generator = GameObject.Find("UMAGenerator").GetComponent<UMAGenerator>();
        if (Generator == null)
            Debug.LogError("UMA: UMAGenerator not Found!!!");

        _characterNameHolder = GameObject.Find("NameText").GetComponent<UITextList>();

    }

    void Start()
    {
        //Deactivate both preset Avatars
        MaleGO.SetActive(false);
        FemaleGO.SetActive(false);
    }

    void Update()
    {
        if (UmaData == null)
        {
            SetSliders("Basic");
        }

        // Don't raycast if the editor is open
        if (UmaData != null)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                Transform tempTransform = hit.collider.transform;
                UmaData = tempTransform.GetComponent<UMAData>();

                if (UmaData)
                {
                    AvatarSetup();
                }
            }
        }

        if (!_hasName)
        {
            
        }
    }

    public void SelectGender(string gender)
    {
        AoW_Customization script = GameObject.Find("AoW_Customization").GetComponent<AoW_Customization>();
        if (gender == "Male")
        {
            SelectedGender = ActivateMale(script);
        }
        else if (gender == "Female")
        {
            SelectedGender = ActivateFemale(script);
        }

        if (SelectedGender == null)
        {
            Debug.LogWarning("Gender Selection Failed!!!!");
        }

        _hasSelectedHead = false;
    }

    //Swap to Male Avatar
    private string ActivateMale(AoW_Customization script)
    {
        MaleGO.SetActive(true);


        if (FemaleGO == null)
            FemaleGO = GameObject.Find("Female");

        if (FemaleGO != null)
            FemaleGO.SetActive(false);

        script.UmaDynamicAvatar = GameObject.Find("Male").GetComponent<UMADynamicAvatar>();

        SelectedGender = "Male";

        if (!_hasCreatedMale)
        {
            SetAvarageDna();
        }

        _hasCreatedMale = true;
        return SelectedGender;

    }

    //Swap to Female Avatar
    private string ActivateFemale(AoW_Customization script)
    {
        FemaleGO.SetActive(true);

        if (MaleGO == null)
            MaleGO = GameObject.Find("Male");

        if (MaleGO != null)
            MaleGO.SetActive(false);

        script.UmaDynamicAvatar = GameObject.Find("Female").GetComponent<UMADynamicAvatar>();
        _hasCreatedFemale = true;
        return "Female";
    }

    public void SetCameraTarget(string gender, string cameraType)
    {
        if (GameObject.Find("Male") == null && GameObject.Find("Female") == null)
            return;

        if (cameraType == "Body")
        {
            if (!BodyCameraSet)
            {
                SetBodyCamera();
            }
        }
        else if (cameraType == "Head")
        {
            if (!HeadCameraSet)
            {
                SetHeadCamera();
            }
        }
    }

    private void SetBodyCamera()
    {
        Debug.Log("Setting Body Cam.");
        BodyCameraSet = true;
        HeadCameraSet = false;

        UpdateCameraTarget(_headTargetPath, _orbitCameraScript.bodyDistance + _umaDna.height);
    }

    private void SetHeadCamera()
    {
        Debug.Log("Setting Head Cam.");
        HeadCameraSet = true;
        BodyCameraSet = false;

        UpdateCameraTarget(_headTargetPath, _orbitCameraScript.headDistance - .1f + _umaDna.headSize + _umaDna.height);
    }

    private void UpdateCameraTarget(string targetPath, float targetDistance)
    {
        GameObject.Find("Camera Target").transform.position = 
            GameObject.Find(SelectedGender).transform.FindChild(targetPath).position;

        _orbitCameraScript.distance = targetDistance;
    }

    // Set all of the sliders to the values contained in the UMA Character
    public void SetSliders(string panel)
    {
        if (SelectedGender == "")
            return;

        UmaData = GameObject.Find(SelectedGender).GetComponent<UMAData>();
        Debug.Log("Managed to get here ;-)");
        if (UmaData == null)
        {
            Debug.LogError("UmaData is EMPTY!!!!");
            return;
        }

        Debug.Log("UmaData Found");

        _umaDna = UmaData.GetDna<UMADnaHumanoid>();

        switch (panel)
        {
            case "Basic":
                HeadSizeSlider.value = _umaDna.headSize;
                HeadWidthSlider.value = _umaDna.headWidth;
                _heightSlider.value = _umaDna.height;
                Debug.Log("Basic Sliders Set");
                SetCameraTarget(SelectedGender, "Body");
                break;
            case "Head":
                ForeHeadSizeSlider.value = _umaDna.foreheadSize;
                ForeHeadPositionSlider.value = _umaDna.foreheadPosition;
                NoseSizeSlider.value = _umaDna.noseSize;
                EyeSizeSlider.value = _umaDna.eyeSize;
                LipSizeSlider.value = _umaDna.lipsSize;
                MouthSlider.value = _umaDna.mouthSize;
                NoseCurveSlider.value = _umaDna.noseCurve;
                NoseWidthSlider.value = _umaDna.noseWidth;
                NoseInclinationSlider.value = _umaDna.noseInclination;
                NosePositionSlider.value = _umaDna.nosePosition;
                NosePronuncedSlider.value = _umaDna.nosePronounced;
                NoseFlattenSlider.value = _umaDna.noseFlatten;
                ChinSizeSlider.value = _umaDna.chinSize;
                ChinPronouncedSlider.value = _umaDna.chinPronounced;
                ChinPositionSlider.value = _umaDna.chinPosition;
                MandibleSizeSlider.value = _umaDna.mandibleSize;
                JawSizeSlider.value = _umaDna.jawsSize;
                JawPositionSlider.value = _umaDna.jawsPosition;
                CheekSizeSlider.value = _umaDna.cheekSize;
                CheekPositionSlider.value = _umaDna.cheekPosition;
                lowCheekOutSlider.value = _umaDna.lowCheekPronounced;
                EarSizeSlider.value = _umaDna.earsSize;
                EarPositionSlider.value = _umaDna.earsPosition;
                EarRotationSlider.value = _umaDna.earsRotation;
                LowCheekPosSlider.value = _umaDna.lowCheekPosition;
                Debug.Log("Head Sliders Set");
                SetCameraTarget(SelectedGender, "Head");
                break;
            case "Body":
                NeckThickSlider.value = _umaDna.neckThickness;
                _upperMuscleSlider.value = _umaDna.upperMuscle;
                _lowerMuscleSlider.value = _umaDna.lowerMuscle;
                BreastSlider.value = _umaDna.breastSize;
                _upperWeightSlider.value = _umaDna.upperWeight;
                _lowerWeightSlider.value = _umaDna.lowerWeight;
                LegSizeSlider.value = _umaDna.legsSize;
                BellySlider.value = _umaDna.belly;
                WaistSizeSlider.value = _umaDna.waist;
                GlueteusSizeSlider.value = _umaDna.gluteusSize;
                _armLengthSlider.value = _umaDna.armLength;
                ArmWidthSlider.value = _umaDna.armWidth;
                ForearmLengthSlider.value = _umaDna.forearmLength;
                ForearmWidthSlider.value = _umaDna.forearmWidth;
                HandSizeSlider.value = _umaDna.handsSize;
                LegSeparationSlider.value = _umaDna.legSeparation;
                FeetSizeSlider.value = _umaDna.feetSize;
                Debug.Log("Body Sliders Set");
                SetCameraTarget(SelectedGender, "Body");
                break;
        }
    }

    private void SetAvarageDna()
    {
        UmaData = GameObject.Find(SelectedGender).GetComponent<UMAData>();

        if (UmaData == null)
            return;

        _umaDna = UmaData.GetDna<UMADnaHumanoid>();

        float avg = .5f;

        _umaDna.headSize = avg;
        _umaDna.headWidth = avg;
        _umaDna.height = avg;

        _umaDna.foreheadSize = avg;
        _umaDna.foreheadPosition = avg;
        _umaDna.noseSize = avg;
        _umaDna.eyeSize = avg;
        _umaDna.lipsSize = avg;
        _umaDna.mouthSize = avg;
        _umaDna.noseCurve = avg;
        _umaDna.noseWidth = avg;
        _umaDna.noseInclination = avg;
        _umaDna.nosePosition = avg;
        _umaDna.nosePronounced = avg;
        _umaDna.noseFlatten = avg;
        _umaDna.chinSize = avg;
        _umaDna.chinPronounced = avg;
        _umaDna.chinPosition = avg;
        _umaDna.mandibleSize = avg;
        _umaDna.jawsSize = avg;
        _umaDna.jawsPosition = avg;
        _umaDna.cheekSize = avg;
        _umaDna.cheekPosition = avg;
        _umaDna.lowCheekPronounced = avg;
        _umaDna.earsSize = avg;
        _umaDna.earsPosition = avg;
        _umaDna.earsRotation = avg;
        _umaDna.lowCheekPosition = avg;

        _umaDna.neckThickness = avg;
        _umaDna.upperMuscle = avg;
        _umaDna.lowerMuscle = avg;
        _umaDna.breastSize = avg;
        _umaDna.upperWeight = avg;
        _umaDna.lowerWeight = avg;
        _umaDna.legsSize = avg;
        _umaDna.belly = avg;
        _umaDna.waist = avg;
        _umaDna.gluteusSize = avg;
        _umaDna.armLength = avg;
        _umaDna.armWidth = avg;
        _umaDna.forearmLength = avg;
        _umaDna.forearmWidth = avg;
        _umaDna.handsSize = avg;
        _umaDna.legSeparation = avg;
        _umaDna.feetSize = avg;
    }

    public void OnSliderMoved(string bodyPart)
    {
        bool isUpdated = true;

        if (_umaDna != null)
        {
            switch (bodyPart)
            {
                //Basic Sliders
                case "headSize":
                    _umaDna.headSize = HeadSizeSlider.value;
                    break;
                case "headWidth":
                    _umaDna.headWidth = HeadWidthSlider.value;
                    break;
                case "height":
                    _umaDna.height = _heightSlider.value;
                    SetBodyCamera();
                    break;
                //Head Sliders
                case "foreheadSize":
                    _umaDna.foreheadSize = ForeHeadSizeSlider.value;
                    break;
                case "foreheadPosition":
                    _umaDna.foreheadPosition = ForeHeadPositionSlider.value;
                    break;
                case "noseSize":
                    _umaDna.noseSize = NoseSizeSlider.value;
                    break;
                case "eyeSize":
                    _umaDna.eyeSize = EyeSizeSlider.value;
                    break;
                case "lipsSize":
                    _umaDna.lipsSize = LipSizeSlider.value;
                    break;
                case "mouthSize":
                    _umaDna.mouthSize = MouthSlider.value;
                    break;
                case "noseCurve":
                    _umaDna.noseCurve = NoseCurveSlider.value;
                    break;
                case "noseWidth":
                    _umaDna.noseWidth = NoseWidthSlider.value;
                    break;
                case "noseInclination":
                    _umaDna.noseInclination = NoseInclinationSlider.value;
                    break;
                case "nosePosition":
                    _umaDna.nosePosition = NosePositionSlider.value;
                    break;
                case "nosePronounced":
                    _umaDna.nosePronounced = NosePronuncedSlider.value;
                    break;
                case "noseFlatten":
                    _umaDna.noseFlatten = NoseFlattenSlider.value;
                    break;
                case "chinSize":
                    _umaDna.chinSize = ChinSizeSlider.value;
                    break;
                case "chinPronounced":
                    _umaDna.chinPronounced = ChinPronouncedSlider.value;
                    break;
                case "chinPosition":
                    _umaDna.chinPosition = ChinPositionSlider.value;
                    break;
                case "mandibleSize":
                    _umaDna.mandibleSize = MandibleSizeSlider.value;
                    break;
                case "jawsSize":
                    _umaDna.jawsSize = JawSizeSlider.value;
                    break;
                case "jawsPosition":
                    _umaDna.jawsPosition = JawPositionSlider.value;
                    break;
                case "cheekSize":
                    _umaDna.cheekSize = CheekSizeSlider.value;
                    break;
                case "cheekPosition":
                    _umaDna.cheekPosition = CheekPositionSlider.value;
                    break;
                case "lowCheekPronounced":
                    _umaDna.lowCheekPronounced = lowCheekOutSlider.value;
                    break;
                case "earsSize":
                    _umaDna.earsSize = EarSizeSlider.value;
                    break;
                case "earsPosition":
                    _umaDna.earsPosition = EarPositionSlider.value;
                    break;
                case "earsRotation":
                    _umaDna.earsRotation = EarRotationSlider.value;
                    break;
                case "lowCheekPosition":
                    _umaDna.lowCheekPosition = LowCheekPosSlider.value;
                    break;
                case "eyeRotation":
                    _umaDna.eyeRotation = EyeRotationSlider.value;
                    break;

                //Body Sliders
                case "neckThickness":
                    _umaDna.neckThickness = NeckThickSlider.value;
                    break;
                case "upperMuscle":
                    _umaDna.upperMuscle = _upperMuscleSlider.value;
                    break;
                case "lowerMuscle":
                    _umaDna.lowerMuscle = _lowerMuscleSlider.value;
                    break;
                case "breastSize":
                    _umaDna.breastSize = BreastSlider.value;
                    break;
                case "upperWeight":
                    _umaDna.upperWeight = _upperWeightSlider.value;
                    break;
                case "lowerWeight":
                    _umaDna.lowerWeight = _lowerWeightSlider.value;
                    break;
                case "legsSize":
                    _umaDna.legsSize = LegSizeSlider.value;
                    break;
                case "belly":
                    _umaDna.belly = BellySlider.value;
                    break;
                case "waist":
                    _umaDna.waist = WaistSizeSlider.value;
                    break;
                case "gluteusSize":
                    _umaDna.gluteusSize = GlueteusSizeSlider.value;
                    break;
                case "armLength":
                    _umaDna.armLength = _armLengthSlider.value;
                    break;
                case "armWidth":
                    _umaDna.armWidth = ArmWidthSlider.value;
                    break;
                case "forearmLength":
                    _umaDna.forearmLength = ForearmLengthSlider.value;
                    break;
                case "forearmWidth":
                    _umaDna.forearmWidth = ForearmWidthSlider.value;
                    break;
                case "handsSize":
                    _umaDna.handsSize = HandSizeSlider.value;
                    break;
                case "legSeparation":
                    _umaDna.legSeparation = LegSeparationSlider.value;
                    break;
                case "feetSize":
                    _umaDna.feetSize = FeetSizeSlider.value;
                    break;
                //Default used when a wrong sting is passed to OnSliderMoved
                default:
                    isUpdated = false;
                    break;
            }
        }

        if (isUpdated) UpdateUMAShape();
    }

    public void CycleToPrev(string part)
    {
        if (!UmaData.isTextureDirty)
        {
            bool refreshChar = false;
            bool isMale = (SelectedGender == "Male");

            switch (part)
            {
                case "body":
                    if (isMale) { if (selectedMaleBodyMesh > 0) {selectedMaleBodyMesh--; refreshChar = true;}}
                    else { if (_selectedFemaleBodyMesh > 0) { _selectedFemaleBodyMesh--; refreshChar = true; } }
                    break;
                case "skintype":
                    if (isMale) { if (selectedMaleBody > 0) { selectedMaleBody--; refreshChar = true; } }
                    else { if (_selectedFemaleBody > 0) { _selectedFemaleBody--; refreshChar = true; } }
                    break;
                case "skincolor":
                    if (isMale) { if (selectedMaleSkinTone > 0) { selectedMaleSkinTone--; refreshChar = true; } }
                    else { if (_selectedFemaleSkinTone > 0) { _selectedFemaleSkinTone--; refreshChar = true; } }
                    break;
                case "hands":
                    if (isMale) { if (selectedMaleHands > 0) { selectedMaleHands--; refreshChar = true; } }
                    else { if (_selectedFemaleHands > 0) { _selectedFemaleHands--; refreshChar = true; } }
                    break;
                case "legs":
                    if (isMale) { if (selectedMaleLegs > 0) { selectedMaleLegs--; refreshChar = true; } }
                    else { if (_selectedFemaleLegs > 0) { _selectedFemaleLegs--; refreshChar = true; } }
                    break;
                case "feet":
                    if (isMale) { if (selectedMaleFeet > 0) { selectedMaleFeet--; refreshChar = true; } }
                    else { if (_selectedFemaleFeet > 0) { _selectedFemaleFeet--; refreshChar = true; } }
                    break;
                case "upper":
                    if (isMale) { if (selectedMaleShirt > 0) { selectedMaleShirt--; refreshChar = true; } }
                    else { if (_selectedFemaleShirt > 0) { _selectedFemaleShirt--; refreshChar = true; } }
                    break;
                case "uppercolor":
                    if (isMale) { if (selectedMaleShirtColor > 0) { selectedMaleShirtColor--; refreshChar = true; } }
                    else { if (_selectedFemaleShirtColor > 0) { _selectedFemaleShirtColor--; refreshChar = true; } }
                    break;
                case "lower":
                    if (isMale) { if (selectedMalePants > 0) { selectedMalePants--; refreshChar = true; } }
                    else { if (_selectedFemalePants > 0) { _selectedFemalePants--; refreshChar = true; } }
                    break;
                case "lowercolor":
                    if (isMale) { if (selectedMalePantsColor > 0) { selectedMalePantsColor--; refreshChar = true; } }
                    else { if (_selectedFemalePantsColor > 0) _selectedFemalePantsColor--; }
                    break;
                case "underwear":
                    if (isMale) { if (selectedMaleUnderwear > 0) { selectedMaleUnderwear--; refreshChar = true; } }
                    else { if (_selectedFemaleUnderwear > 0) { _selectedFemaleUnderwear--; refreshChar = true; } }
                    break;
                case "underwearcolor":
                    if (isMale) { if (selectedMaleUnderwearColor > 0) { selectedMaleUnderwearColor--; refreshChar = true; } }
                    else { if (_selectedFemaleUnderwearColor > 0) { _selectedFemaleUnderwearColor--; refreshChar = true; } }
                    break;
                case "headmesh":
                    if (isMale) { if (selectedMaleHeadMesh > 0) { selectedMaleHeadMesh--; refreshChar = true; } }
                    else { if (_selectedFemaleHeadMesh > 0) { _selectedFemaleHeadMesh--; refreshChar = true; } }
                    break;
                case "headtexture":
                    if (isMale) { if (selectedMaleHeadTexture > 0) { selectedMaleHeadTexture--; refreshChar = true; } }
                    else { if (_selectedFemaleHeadTexture > 0) { _selectedFemaleHeadTexture--; refreshChar = true; } }
                    break;
                case "eyes":
                    if (isMale) { if (selectedMaleEyeColor > 0) { selectedMaleEyeColor--; refreshChar = true; } }
                    else { if (_selectedFemaleEyeColor > 0) { _selectedFemaleEyeColor--; refreshChar = true; } }
                    break;
                case "eyebrows":
                    if (isMale) { if (selectedMaleEyebrow > 0) { selectedMaleEyebrow--; refreshChar = true; } }
                    else { if (_selectedFemaleEyebrow > 0) { _selectedFemaleEyebrow--; refreshChar = true; } }
                    break;
                case "eyesockets":
                    if (isMale) { if (selectedMaleEyesockets > 0) { selectedMaleEyesockets--; refreshChar = true; } }
                    else { if (_selectedFemaleEyesockets > 0) { _selectedFemaleEyesockets--; refreshChar = true; } }
                    break;
                case "ears":
                    if (isMale) { if (selectedMaleEars > 0) { selectedMaleEars--; refreshChar = true; } }
                    else { if (_selectedFemaleEars > 0) { _selectedFemaleEars--; refreshChar = true; } }
                    break;
                case "nose":
                    if (isMale) { if (selectedMaleNose > 0) { selectedMaleNose--; refreshChar = true; } }
                    else { if (_selectedFemaleNose > 0) { _selectedFemaleNose--; refreshChar = true; } }
                    break;
                case "mouth":
                    if (isMale) { if (selectedMaleMouth > 0) { selectedMaleMouth--; refreshChar = true; } }
                    else { if (_selectedFemaleMouth > 0) { _selectedFemaleMouth--; refreshChar = true; } }
                    break;
                case "hairstyle":
                    if (isMale) { if (selectedMaleHairStyle > 0) { selectedMaleHairStyle--; refreshChar = true; } }
                    else { if (_selectedFemaleHairStyle > 0) { _selectedFemaleHairStyle--; refreshChar = true; } }
                    break;
                case "beardstyle":
                    if (isMale) { if (selectedMaleBeardStyle > 0) { selectedMaleBeardStyle--; refreshChar = true; } }
                    break;
                case "haircolor":
                    if (isMale) { if (selectedMaleHairColor > 0) { selectedMaleHairColor--; refreshChar = true; } }
                    else { if (_selectedFemaleHairColor > 0) { _selectedFemaleHairColor--; refreshChar = true; } }
                    break;
                case "lipstick":
                    if (!isMale) { if (_selectedFemaleLipstickColor > 0) { _selectedFemaleLipstickColor--; refreshChar = true; } }
                    break;
                default:
                    Debug.LogError("Unknown body part specified: " + part);
                    break;
            }

            if (refreshChar) GenerateOneUMA();
        }
    }

    public void CycleToNext(string part)
    {
        if (!UmaData.isTextureDirty)
        {
            bool refreshChar = false;
            bool isMale = (SelectedGender == "Male");

            switch (part)
            {
                case "body":
                    if (isMale) { if (selectedMaleBodyMesh < MaleBodyMeshes.Count - 1) { selectedMaleBodyMesh++; refreshChar = true; } }
                    else { if (_selectedFemaleBodyMesh < FemaleBodyMeshes.Count - 1) { _selectedFemaleBodyMesh++; refreshChar = true; } }
                    break;
                case "skintype":
                    if (isMale) { if (selectedMaleBody < MaleBodies.Count - 1) { selectedMaleBody++; refreshChar = true; } }
                    else { if (_selectedFemaleBody < FemaleBodies.Count - 1) { _selectedFemaleBody++; refreshChar = true; } }
                    break;
                case "skincolor":
                    if (isMale) { if (selectedMaleSkinTone < SkinTones.Count - 1) { selectedMaleSkinTone++; refreshChar = true; } }
                    else { if (_selectedFemaleSkinTone < SkinTones.Count - 1) { _selectedFemaleSkinTone++; refreshChar = true; } }
                    break;
                case "hands":
                    if (isMale) { if (selectedMaleHands < MaleHands.Count - 1) { selectedMaleHands++; refreshChar = true; } }
                    else { if (_selectedFemaleHands < FemaleHands.Count - 1) { _selectedFemaleHands++; refreshChar = true; } }
                    break;
                case "legs":
                    if (isMale) { if (selectedMaleLegs < MaleLegs.Count - 1) { selectedMaleLegs++; refreshChar = true; } }
                    else { if (_selectedFemaleLegs < FemaleLegs.Count - 1) { _selectedFemaleLegs++; refreshChar = true; } }
                    break;
                case "feet":
                    if (isMale) { if (selectedMaleFeet < MaleFeet.Count - 1) { selectedMaleFeet++; refreshChar = true; } }
                    else { if (_selectedFemaleFeet < FemaleFeet.Count - 1) { _selectedFemaleFeet++; refreshChar = true; } }
                    break;
                case "upper":
                    if (isMale) { if (selectedMaleShirt < MaleShirts.Count - 1) { selectedMaleShirt++; refreshChar = true; } }
                    else { if (_selectedFemaleShirt < FemaleShirts.Count - 1) { _selectedFemaleShirt++; refreshChar = true; } }
                    break;
                case "uppercolor":
                    if (isMale) { if (selectedMaleShirtColor < ShirtColors.Count - 1) { selectedMaleShirtColor++; refreshChar = true; } }
                    else { if (_selectedFemaleShirtColor < ShirtColors.Count - 1) { _selectedFemaleShirtColor++; refreshChar = true; } }
                    break;
                case "lower":
                    if (isMale) { if (selectedMalePants < MalePants.Count - 1) { selectedMalePants++; refreshChar = true; } }
                    else { if (_selectedFemalePants < FemalePants.Count - 1) { _selectedFemalePants++; refreshChar = true; } }
                    break;
                case "lowercolor":
                    if (isMale) { if (selectedMalePantsColor < PantsColors.Count - 1) { selectedMalePantsColor++; refreshChar = true; } }
                    else { if (_selectedFemalePantsColor < PantsColors.Count - 1) { _selectedFemalePantsColor++; refreshChar = true; } }
                    break;
                case "underwear":
                    if (isMale) { if (selectedMaleUnderwear < MaleUnderwear.Count - 1) { selectedMaleUnderwear++; refreshChar = true; } }
                    else { if (_selectedFemaleUnderwear < FemaleUnderwear.Count - 1) { _selectedFemaleUnderwear++; refreshChar = true; } }
                    break;
                case "underwearcolor":
                    if (isMale) { if (selectedMaleUnderwearColor < UnderwearColors.Count - 1) { selectedMaleUnderwearColor++; refreshChar = true; } }
                    else { if (_selectedFemaleUnderwearColor < UnderwearColors.Count - 1) { _selectedFemaleUnderwearColor++; refreshChar = true; } }
                    break;
                case "headmesh":
                    if (isMale) { if (selectedMaleHeadMesh < MaleHeadMeshes.Count - 1) { selectedMaleHeadMesh++; refreshChar = true; } }
                    else { if (_selectedFemaleHeadMesh < FemaleHeadMeshes.Count - 1) { _selectedFemaleHeadMesh++; refreshChar = true; } }
                    break;
                case "headtexture":
                    if (isMale) { if (selectedMaleHeadTexture < MaleHeadTextures.Count - 1) { selectedMaleHeadTexture++; refreshChar = true; } }
                    else { if (_selectedFemaleHeadTexture < FemaleHeadTextures.Count - 1) { _selectedFemaleHeadTexture++; refreshChar = true; } }
                    break;
                case "eyes":
                    if (isMale) { if (selectedMaleEyeColor < EyeColors.Count - 1) { selectedMaleEyeColor++; refreshChar = true; } }
                    else { if (_selectedFemaleEyeColor < EyeColors.Count - 1) { _selectedFemaleEyeColor++; refreshChar = true; } }
                    break;
                case "eyebrows":
                    if (isMale) { if (selectedMaleEyebrow < MaleEyebrows.Count - 1) { selectedMaleEyebrow++; refreshChar = true; } }
                    else { if (_selectedFemaleEyebrow < FemaleEyebrows.Count - 1) { _selectedFemaleEyebrow++; refreshChar = true; } }
                    break;
                case "eyesockets":
                    if (isMale) { if (selectedMaleEyesockets < MaleEyesockets.Count - 1) { selectedMaleEyesockets++; refreshChar = true; } }
                    else { if (_selectedFemaleEyesockets < FemaleEyesockets.Count - 1) { _selectedFemaleEyesockets++; refreshChar = true; } }
                    break;
                case "ears":
                    if (isMale) { if (selectedMaleEars < MaleEars.Count - 1) { selectedMaleEars++; refreshChar = true; } }
                    else { if (_selectedFemaleEars < FemaleEars.Count - 1) { _selectedFemaleEars++; refreshChar = true; } }
                    break;
                case "nose":
                    if (isMale) { if (selectedMaleNose < MaleNoses.Count - 1) { selectedMaleNose++; refreshChar = true; } }
                    else { if (_selectedFemaleNose < FemaleNoses.Count - 1) { _selectedFemaleNose++; refreshChar = true; } }
                    break;
                case "mouth":
                    if (isMale) { if (selectedMaleMouth < MaleMouths.Count - 1) { selectedMaleMouth++; refreshChar = true; } }
                    else { if (_selectedFemaleMouth < FemaleMouths.Count - 1) { _selectedFemaleMouth++; refreshChar = true; } }
                    break;
                case "hairstyle":
                    if (isMale) { if (selectedMaleHairStyle < MaleHairStyles.Count - 1) { selectedMaleHairStyle++; refreshChar = true; } }
                    else { if (_selectedFemaleHairStyle < FemaleHairStyles.Count - 1) { _selectedFemaleHairStyle++; refreshChar = true; } }
                    break;
                case "beardstyle":
                    if (isMale) { if (selectedMaleBeardStyle < MaleBeardStyles.Count - 1) { selectedMaleBeardStyle++; refreshChar = true; } }
                    break;
                case "haircolor":
                    if (isMale) { if (selectedMaleHairColor < HairColors.Count - 1) { selectedMaleHairColor++; refreshChar = true; } }
                    else { if (_selectedFemaleHairColor < HairColors.Count - 1) { _selectedFemaleHairColor++; refreshChar = true; } }
                    break;
                case "lipstick":
                    if (!isMale) { if (_selectedFemaleLipstickColor < LipstickColors.Count - 1) { _selectedFemaleLipstickColor++; refreshChar = true; } }
                    break;
                default:
                    Debug.LogError("Unknown body part specified: " + part);
                    break;
            }

            if (refreshChar) GenerateOneUMA();
        }
    }

    public void RandomizeHead()
    {
        if (!UmaData.isTextureDirty)
        {
            HeadRandomize();

            GenerateOneUMA();
        }
    }

    public void RandomizeBody()
    {
        if (!UmaData.isTextureDirty)
        {
            BodyRandomize();

            GenerateOneUMA();
        }
    }

    public void RandomizeAll()
    {
        if (!UmaData.isTextureDirty)
        {
            HeadRandomize();
            BodyRandomize();

            GenerateOneUMA(true);
        }
    }

    private void HeadRandomize()
    {
        if (SelectedGender == "Male")
        {
            selectedMaleEyeColor = Random.Range(0, EyeColors.Count);
            selectedMaleHairColor = Random.Range(0, HairColors.Count);
            selectedMaleHeadMesh = Random.Range(0, MaleHeadMeshes.Count);
            selectedMaleHeadTexture = Random.Range(0, MaleHeadTextures.Count);
            selectedMaleHairStyle = Random.Range(0, MaleHairStyles.Count);
            selectedMaleBeardStyle = Random.Range(0, MaleBeardStyles.Count);
            selectedMaleEyebrow = Random.Range(0, MaleEyebrows.Count);

            // Since in most games the eyes are not clearly visible I commented this out
            // If you really want it, just uncomment it ;-)
            /*
            _selectedMaleEyeballs = Random.Range(0,MaleEyeballs.Count);
            _selectedMaleEyeballTexture = Random.Range(0,EyeballTextures.Count);
            _selectedMaleEyeballTextureAdjust = Random.Range(0,EyeballTexturesAdjust.Count);
            */

            selectedMaleEyesockets = Random.Range(0, MaleEyesockets.Count);
            selectedMaleEars = Random.Range(0, MaleEars.Count);
            selectedMaleNose = Random.Range(0, MaleNoses.Count);
            selectedMaleMouth = Random.Range(0, MaleMouths.Count);

            _umaDna.earsSize = Random.Range(0.2f, 0.8f);
            _umaDna.earsPosition = Random.Range(0.2f, 0.8f);
            _umaDna.earsRotation = Random.Range(0.2f, 0.8f);

            _umaDna.noseSize = Random.Range(0.2f, 0.8f);
            _umaDna.noseCurve = Random.Range(0.2f, 0.8f);
            _umaDna.noseWidth = Random.Range(0.2f, 0.8f);
            _umaDna.noseInclination = Random.Range(0.2f, 0.8f);
            _umaDna.nosePosition = Random.Range(0.2f, 0.8f);
            _umaDna.nosePronounced = Random.Range(0.2f, 0.8f);
            _umaDna.noseFlatten = Random.Range(0.2f, 0.8f);

            _umaDna.chinSize = Random.Range(0.2f, 0.8f);
            _umaDna.chinPronounced = Random.Range(0.2f, 0.8f);
            _umaDna.chinPosition = Random.Range(0.2f, 0.8f);

            _umaDna.mandibleSize = Random.Range(0.45f, 0.52f);
            _umaDna.jawsSize = Random.Range(0.2f, 0.8f);
            _umaDna.jawsPosition = Random.Range(0.2f, 0.8f);

            _umaDna.cheekSize = Random.Range(0.2f, 0.8f);
            _umaDna.cheekPosition = Random.Range(0.2f, 0.8f);
            _umaDna.lowCheekPronounced = Random.Range(0.2f, 0.8f);
            _umaDna.lowCheekPosition = Random.Range(0.2f, 0.8f);

            _umaDna.foreheadSize = Random.Range(0.2f, 0.8f);
            _umaDna.foreheadPosition = Random.Range(0.15f, 0.65f);

            _umaDna.lipsSize = Random.Range(0.2f, 0.8f);
            _umaDna.mouthSize = Random.Range(0.2f, 0.8f);
            _umaDna.eyeRotation = Random.Range(0.2f, 0.8f);
            _umaDna.eyeSize = Random.Range(0.2f, 0.8f);
        }
        else
        {
            _selectedFemaleEyeColor = Random.Range(0, EyeColors.Count);
            _selectedFemaleHairColor = Random.Range(0, HairColors.Count);
            _selectedFemaleLipstickColor = Random.Range(0, LipstickColors.Count);
            _selectedFemaleHeadMesh = Random.Range(0, FemaleHeadMeshes.Count);
            _selectedFemaleHeadTexture = Random.Range(0, FemaleHeadTextures.Count);
            _selectedFemaleHairStyle = Random.Range(0, FemaleHairStyles.Count);
            _selectedFemaleEyebrow = Random.Range(0, FemaleEyebrows.Count);

            // Since in most games the eyes are not clearly visible I commented this out
            // If you really want it, just uncomment it ;-)
            /*
            _selectedFemaleEyeballs = Random.Range(0,FemaleEyeballs.Count);
            _selectedFemaleEyeballTexture = Random.Range(0,EyeballTextures.Count);
            _selectedFemaleEyeballTextureAdjust = Random.Range(0,EyeballTexturesAdjust.Count);
             */

            _selectedFemaleEyesockets = Random.Range(0, FemaleEyesockets.Count);
            _selectedFemaleEars = Random.Range(0, FemaleEars.Count);
            _selectedFemaleNose = Random.Range(0, FemaleNoses.Count);
            _selectedFemaleMouth = Random.Range(0, FemaleMouths.Count);

            _umaDna.earsSize = Random.Range(0.2f, 0.8f);
            _umaDna.earsPosition = Random.Range(0.2f, 0.8f);
            _umaDna.earsRotation = Random.Range(0.2f, 0.8f);

            _umaDna.noseSize = Random.Range(0.2f, 0.8f);
            _umaDna.noseCurve = Random.Range(0.2f, 0.8f);
            _umaDna.noseWidth = Random.Range(0.2f, 0.8f);
            _umaDna.noseInclination = Random.Range(0.2f, 0.8f);
            _umaDna.nosePosition = Random.Range(0.2f, 0.8f);
            _umaDna.nosePronounced = Random.Range(0.2f, 0.8f);
            _umaDna.noseFlatten = Random.Range(0.2f, 0.8f);

            _umaDna.chinSize = Random.Range(0.2f, 0.8f);
            _umaDna.chinPronounced = Random.Range(0.2f, 0.8f);
            _umaDna.chinPosition = Random.Range(0.2f, 0.8f);

            _umaDna.mandibleSize = Random.Range(0.45f, 0.52f);
            _umaDna.jawsSize = Random.Range(0.2f, 0.8f);
            _umaDna.jawsPosition = Random.Range(0.2f, 0.8f);

            _umaDna.cheekSize = Random.Range(0.2f, 0.8f);
            _umaDna.cheekPosition = Random.Range(0.2f, 0.8f);
            _umaDna.lowCheekPronounced = Random.Range(0.2f, 0.8f);
            _umaDna.lowCheekPosition = Random.Range(0.2f, 0.8f);

            _umaDna.foreheadSize = Random.Range(0.2f, 0.8f);
            _umaDna.foreheadPosition = Random.Range(0.15f, 0.65f);

            _umaDna.lipsSize = Random.Range(0.2f, 0.8f);
            _umaDna.mouthSize = Random.Range(0.2f, 0.8f);
            _umaDna.eyeRotation = Random.Range(0.2f, 0.8f);
            _umaDna.eyeSize = Random.Range(0.2f, 0.8f);
        }
    }

    private void BodyRandomize()
    {
        if (SelectedGender == "Male")
        {
            selectedMaleSkinTone = Random.Range(0, SkinTones.Count);
            selectedMaleShirtColor = Random.Range(0, ShirtColors.Count);
            selectedMalePantsColor = Random.Range(0, PantsColors.Count);
            selectedMaleUnderwearColor = Random.Range(0, UnderwearColors.Count);
            selectedMaleBody = Random.Range(0, MaleBodies.Count);
            selectedMaleShirt = Random.Range(0, MaleShirts.Count);
            selectedMalePants = Random.Range(0, MalePants.Count);
            selectedMaleUnderwear = Random.Range(0, MaleUnderwear.Count);

            selectedMaleBodyMesh = Random.Range(0, MaleBodyMeshes.Count);
            selectedMaleHands = Random.Range(0, MaleHands.Count);
            selectedMaleLegs = Random.Range(0, MaleLegs.Count);
            selectedMaleFeet = Random.Range(0, MaleFeet.Count);

            _umaDna.height = Random.Range(0.5f, 0.6f);
            _umaDna.waist = 0.5f;

            _umaDna.headSize = Random.Range(0.485f, 0.515f);
            _umaDna.headWidth = Random.Range(0.4f, 0.6f);

            _umaDna.neckThickness = Random.Range(0.495f, 0.51f);

            _umaDna.handsSize = Random.Range(0.485f, 0.515f);
            _umaDna.feetSize = Random.Range(0.485f, 0.515f);

            _umaDna.armLength = Random.Range(0.485f, 0.515f);
            _umaDna.forearmLength = Random.Range(0.485f, 0.515f);
            _umaDna.armWidth = Random.Range(0.4f, 0.6f);
            _umaDna.forearmWidth = Random.Range(0.4f, 0.6f);

            _umaDna.upperMuscle = Random.Range(0.4f, 0.6f);
            _umaDna.upperWeight = Random.Range(-0.2f, 0.2f) + _umaDna.upperMuscle;
            if (_umaDna.upperWeight > 1.0) { _umaDna.upperWeight = 1.0f; }
            if (_umaDna.upperWeight < 0.0) { _umaDna.upperWeight = 0.0f; }

            _umaDna.lowerMuscle = Random.Range(-0.2f, 0.2f) + _umaDna.upperMuscle;
            if (_umaDna.lowerMuscle > 1.0) { _umaDna.lowerMuscle = 1.0f; }
            if (_umaDna.lowerMuscle < 0.0) { _umaDna.lowerMuscle = 0.0f; }

            _umaDna.lowerWeight = Random.Range(-0.1f, 0.1f) + _umaDna.upperWeight;
            if (_umaDna.lowerWeight > 1.0) { _umaDna.lowerWeight = 1.0f; }
            if (_umaDna.lowerWeight < 0.0) { _umaDna.lowerWeight = 0.0f; }

            _umaDna.belly = _umaDna.upperWeight;
            _umaDna.legsSize = Random.Range(0.4f, 0.6f);
            _umaDna.gluteusSize = Random.Range(0.4f, 0.6f);

            _umaDna.breastSize = Random.Range(0.2f, 0.8f);
        }
        else
        {
            _selectedFemaleSkinTone = Random.Range(0, SkinTones.Count);
            _selectedFemaleShirtColor = Random.Range(0, ShirtColors.Count);
            _selectedFemalePantsColor = Random.Range(0, PantsColors.Count);
            _selectedFemaleUnderwearColor = Random.Range(0, UnderwearColors.Count);
            _selectedFemaleBody = Random.Range(0, FemaleBodies.Count);
            _selectedFemaleShirt = Random.Range(0, FemaleShirts.Count);
            _selectedFemalePants = Random.Range(0, FemalePants.Count);
            _selectedFemaleUnderwear = Random.Range(0, FemaleUnderwear.Count);

            _selectedFemaleBodyMesh = Random.Range(0, FemaleBodyMeshes.Count);
            _selectedFemaleHands = Random.Range(0, FemaleHands.Count);
            _selectedFemaleLegs = Random.Range(0, FemaleLegs.Count);
            _selectedFemaleFeet = Random.Range(0, FemaleFeet.Count);

            _umaDna.height = Random.Range(0.4f, 0.5f);
            _umaDna.waist = Random.Range(0.3f, 0.8f);

            _umaDna.headSize = Random.Range(0.485f, 0.515f);
            _umaDna.headWidth = Random.Range(0.4f, 0.6f);

            _umaDna.neckThickness = Random.Range(0.495f, 0.51f);

            _umaDna.handsSize = Random.Range(0.485f, 0.515f);
            _umaDna.feetSize = Random.Range(0.485f, 0.515f);

            _umaDna.armLength = Random.Range(0.485f, 0.515f);
            _umaDna.forearmLength = Random.Range(0.485f, 0.515f);
            _umaDna.armWidth = Random.Range(0.4f, 0.6f);
            _umaDna.forearmWidth = Random.Range(0.4f, 0.6f);

            _umaDna.upperMuscle = Random.Range(0.4f, 0.6f);
            _umaDna.upperWeight = Random.Range(-0.2f, 0.2f) + _umaDna.upperMuscle;
            if (_umaDna.upperWeight > 1.0) { _umaDna.upperWeight = 1.0f; }
            if (_umaDna.upperWeight < 0.0) { _umaDna.upperWeight = 0.0f; }

            _umaDna.lowerMuscle = Random.Range(-0.2f, 0.2f) + _umaDna.upperMuscle;
            if (_umaDna.lowerMuscle > 1.0) { _umaDna.lowerMuscle = 1.0f; }
            if (_umaDna.lowerMuscle < 0.0) { _umaDna.lowerMuscle = 0.0f; }

            _umaDna.lowerWeight = Random.Range(-0.1f, 0.1f) + _umaDna.upperWeight;
            if (_umaDna.lowerWeight > 1.0) { _umaDna.lowerWeight = 1.0f; }
            if (_umaDna.lowerWeight < 0.0) { _umaDna.lowerWeight = 0.0f; }

            _umaDna.belly = _umaDna.upperWeight;
            _umaDna.legsSize = Random.Range(0.4f, 0.6f);
            _umaDna.gluteusSize = Random.Range(0.4f, 0.6f);

            _umaDna.breastSize = Random.Range(0.2f, 0.8f);
        }
    }

    // Generate an UMA character
    void GenerateOneUMA(bool randomizeShape = false)
    {

        var newGO = new GameObject();
        newGO.transform.parent = GameObject.Find("AoW").transform;

        // Rotate the character to face the camera
        newGO.transform.localEulerAngles = new Vector3(0, 180, 0);
        UmaDynamicAvatar = newGO.AddComponent<UMADynamicAvatar>();
        UmaDynamicAvatar.Initialize();
        UmaData = UmaDynamicAvatar.umaData;
        UmaDynamicAvatar.umaGenerator = Generator;
        UmaData.umaGenerator = Generator;
        UmaData.OnCharacterUpdated += new System.Action<UMAData>(UmaData_OnUpdated);
        var umaRecipe = UmaDynamicAvatar.umaData.umaRecipe;

        if (_hasCreatedMale || _hasCreatedFemale)
        {
            if (SelectedGender == "Male")
            {
                _savedMaleUmaDna = _umaDna;
            }
            else if (SelectedGender == "Female")
            {
                _savedFemaleUmaDna = _umaDna;
            }

            DestroyCurrent();
        }

         // Male or female?
        if (SelectedGender == "Male")
        {
            umaRecipe.SetRace(RaceLibrary.GetRace("HumanMale"));
            newGO.name = "Male";
            maleAvatarSpawn = newGO;
        }
        else
        {
            umaRecipe.SetRace(RaceLibrary.GetRace("HumanFemale"));
            newGO.name = "Female";
            femaleAvatarSpawn = newGO;
        }

        UmaData.atlasResolutionScale = AtlasResolutionScale;
        UmaData.Dirty(true, true, true);

        // Set/randomize the shape values
        GenerateUMAShapes(randomizeShape);

        // Instantiate slots and add overlays
        DefineSlots();

        UmaDynamicAvatar.animationController = AnimationController;


        UmaDynamicAvatar.UpdateNewRace();

        //umaDynamicAvatar.umaData.myRenderer.enabled = false;
        if (SelectedGender == "Male")
            MaleGO = GameObject.Find("Male");
        else if (SelectedGender == "Female")
            FemaleGO = GameObject.Find("Female");

    }

    public void AvatarSetup()
    {
        UmaDynamicAvatar = UmaData.gameObject.GetComponent<UMADynamicAvatar>();

        _umaDna = UmaData.GetDna<UMADnaHumanoid>();
    }

    public void UpdateUMAShape()
    {
        UmaData = GameObject.Find(SelectedGender).GetComponent<UMAData>();
        _umaDna = UmaData.GetDna<UMADnaHumanoid>();

        DefineSlots();

        if (UmaData != null)
        {
            UmaData.isShapeDirty = true;
            UmaData.Dirty();
        }
    }

    public void SelectGenderPanel()
    {
        if (SelectedGender == "Male")
        {
            MaleHeadPanel.SetActive(true);
            MaleBodyPanel.SetActive(true);
            FemaleHeadPanel.SetActive(false);
            FemaleBodyPanel.SetActive(false);
        }
        else if (SelectedGender == "Female")
        {
            MaleHeadPanel.SetActive(false);
            MaleBodyPanel.SetActive(false);
            FemaleHeadPanel.SetActive(true);
            FemaleBodyPanel.SetActive(true);
        }
    }

    void GenerateUMAShapes(bool randomize = false)
    {

        // If it's the first time we create a female or male, add the default DNA
        if (SelectedGender == "Male")
        {
            if (_savedMaleUmaDna == null) { _savedMaleUmaDna = new UMADnaHumanoid(); }
            UmaData.umaRecipe.umaDna.Add(_savedMaleUmaDna.GetType(), _savedMaleUmaDna);
        }
        else
        {
            if (_savedFemaleUmaDna == null) { _savedFemaleUmaDna = new UMADnaHumanoid(); }
            UmaData.umaRecipe.umaDna.Add(_savedFemaleUmaDna.GetType(), _savedFemaleUmaDna);
        }

        // Here you can define the randomness ranges to suit what should be plausible in your game
        if (randomize)
        {
            // It's possible to do gender specific randomness like this
            if (SelectedGender == "Male")
            {
                _umaDna.height = Random.Range(0.5f, 0.6f);
                _umaDna.waist = 0.5f;
            }
            else
            {
                _umaDna.height = Random.Range(0.4f, 0.5f);
                _umaDna.waist = Random.Range(0.3f, 0.8f);
            }

            _umaDna.headSize = Random.Range(0.485f, 0.515f);
            _umaDna.headWidth = Random.Range(0.4f, 0.6f);

            _umaDna.neckThickness = Random.Range(0.495f, 0.51f);

            _umaDna.handsSize = Random.Range(0.485f, 0.515f);
            _umaDna.feetSize = Random.Range(0.485f, 0.515f);

            _umaDna.armLength = Random.Range(0.485f, 0.515f);
            _umaDna.forearmLength = Random.Range(0.485f, 0.515f);
            _umaDna.armWidth = Random.Range(0.4f, 0.6f);
            _umaDna.forearmWidth = Random.Range(0.4f, 0.6f);

            // It's also possible to have some values depend on others
            _umaDna.upperMuscle = Random.Range(0.4f, 0.6f);
            _umaDna.upperWeight = Random.Range(-0.2f, 0.2f) + _umaDna.upperMuscle;
            if (_umaDna.upperWeight > 1.0) { _umaDna.upperWeight = 1.0f; }
            if (_umaDna.upperWeight < 0.0) { _umaDna.upperWeight = 0.0f; }

            _umaDna.lowerMuscle = Random.Range(-0.2f, 0.2f) + _umaDna.upperMuscle;
            if (_umaDna.lowerMuscle > 1.0) { _umaDna.lowerMuscle = 1.0f; }
            if (_umaDna.lowerMuscle < 0.0) { _umaDna.lowerMuscle = 0.0f; }

            _umaDna.lowerWeight = Random.Range(-0.1f, 0.1f) + _umaDna.upperWeight;
            if (_umaDna.lowerWeight > 1.0) { _umaDna.lowerWeight = 1.0f; }
            if (_umaDna.lowerWeight < 0.0) { _umaDna.lowerWeight = 0.0f; }

            _umaDna.belly = _umaDna.upperWeight;
            _umaDna.legsSize = Random.Range(0.4f, 0.6f);
            _umaDna.gluteusSize = Random.Range(0.4f, 0.6f);

            _umaDna.earsSize = Random.Range(0.2f, 0.8f);
            _umaDna.earsPosition = Random.Range(0.2f, 0.8f);
            _umaDna.earsRotation = Random.Range(0.2f, 0.8f);

            _umaDna.noseSize = Random.Range(0.2f, 0.8f);
            _umaDna.noseCurve = Random.Range(0.2f, 0.8f);
            _umaDna.noseWidth = Random.Range(0.2f, 0.8f);
            _umaDna.noseInclination = Random.Range(0.2f, 0.8f);
            _umaDna.nosePosition = Random.Range(0.2f, 0.8f);
            _umaDna.nosePronounced = Random.Range(0.2f, 0.8f);
            _umaDna.noseFlatten = Random.Range(0.2f, 0.8f);

            _umaDna.chinSize = Random.Range(0.2f, 0.8f);
            _umaDna.chinPronounced = Random.Range(0.2f, 0.8f);
            _umaDna.chinPosition = Random.Range(0.2f, 0.8f);

            _umaDna.mandibleSize = Random.Range(0.45f, 0.52f);
            _umaDna.jawsSize = Random.Range(0.2f, 0.8f);
            _umaDna.jawsPosition = Random.Range(0.2f, 0.8f);

            _umaDna.cheekSize = Random.Range(0.2f, 0.8f);
            _umaDna.cheekPosition = Random.Range(0.2f, 0.8f);
            _umaDna.lowCheekPronounced = Random.Range(0.2f, 0.8f);
            _umaDna.lowCheekPosition = Random.Range(0.2f, 0.8f);

            _umaDna.foreheadSize = Random.Range(0.2f, 0.8f);
            _umaDna.foreheadPosition = Random.Range(0.15f, 0.65f);

            _umaDna.lipsSize = Random.Range(0.2f, 0.8f);
            _umaDna.mouthSize = Random.Range(0.2f, 0.8f);
            _umaDna.eyeRotation = Random.Range(0.2f, 0.8f);
            _umaDna.eyeSize = Random.Range(0.2f, 0.8f);
            _umaDna.breastSize = Random.Range(0.2f, 0.8f);
        }
    }

    void DestroyCurrent()
    {
        if (SelectedGender == "Male")
        {
            Destroy(GameObject.Find("Male"));
            maleAvatarHead = null;
            maleAvatarBody = null;
        }
        else
        {
            Destroy(GameObject.Find("Female"));
            femaleAvatarHead = null;
            femaleAvatarBody = null;
        }
    }

    void DefineSlots()
    {
        UmaData.umaRecipe.slotDataList = new SlotData[15];

        if (SelectedGender == "Male")
        {
            // Eyeballs
            UmaData.umaRecipe.slotDataList[0] = SlotLibrary.InstantiateSlot(MaleEyeballs[selectedMaleEyeballs]);
            UmaData.umaRecipe.slotDataList[0].AddOverlay(OverlayLibrary.InstantiateOverlay(EyeballTextures[selectedMaleEyeballTexture]));
            UmaData.umaRecipe.slotDataList[0].AddOverlay(OverlayLibrary.InstantiateOverlay(EyeballTexturesAdjust[selectedMaleEyeballTextureAdjust], EyeColors[selectedMaleEyeColor]));

            // Head Mesh
            UmaData.umaRecipe.slotDataList[1] = SlotLibrary.InstantiateSlot(MaleHeadMeshes[selectedMaleHeadMesh]);

            // Head Texture
            UmaData.umaRecipe.slotDataList[1].AddOverlay(OverlayLibrary.InstantiateOverlay(MaleHeadTextures[selectedMaleHeadTexture], SkinTones[selectedMaleSkinTone]));

            //Eyes
            UmaData.umaRecipe.slotDataList[7] = SlotLibrary.InstantiateSlot(MaleEyesockets[selectedMaleEyesockets], UmaData.umaRecipe.slotDataList[1].GetOverlayList());

            // Ears
            UmaData.umaRecipe.slotDataList[8] = SlotLibrary.InstantiateSlot("MaleHead_ElvenEars");
            UmaData.umaRecipe.slotDataList[8].AddOverlay(OverlayLibrary.InstantiateOverlay("ElvenEars", SkinColor));
            UmaData.umaRecipe.slotDataList[8] = SlotLibrary.InstantiateSlot(MaleEars[selectedMaleEars], UmaData.umaRecipe.slotDataList[1].GetOverlayList());

            // Mouth
            UmaData.umaRecipe.slotDataList[9] = SlotLibrary.InstantiateSlot(MaleMouths[selectedMaleMouth], UmaData.umaRecipe.slotDataList[1].GetOverlayList());

            // Nose
            UmaData.umaRecipe.slotDataList[10] = SlotLibrary.InstantiateSlot(MaleNoses[selectedMaleNose], UmaData.umaRecipe.slotDataList[1].GetOverlayList());

            // Hair
            if (MaleHairStyles[selectedMaleHairStyle] != "")
            {
                UmaData.umaRecipe.slotDataList[1].AddOverlay(OverlayLibrary.InstantiateOverlay(MaleHairStyles[selectedMaleHairStyle], HairColors[selectedMaleHairColor] * 0.25f));
            }

            // Beard
            if (MaleBeardStyles[selectedMaleBeardStyle] != "")
            {
                UmaData.umaRecipe.slotDataList[1].AddOverlay(OverlayLibrary.InstantiateOverlay(MaleBeardStyles[selectedMaleBeardStyle], HairColors[selectedMaleHairColor] * 0.15f));
            }

            // Eyebrows
            UmaData.umaRecipe.slotDataList[1].AddOverlay(OverlayLibrary.InstantiateOverlay(MaleEyebrows[selectedMaleEyebrow], HairColors[selectedMaleHairColor] * 0.05f));

            // Torso mesh
            UmaData.umaRecipe.slotDataList[2] = SlotLibrary.InstantiateSlot(MaleBodyMeshes[selectedMaleBodyMesh]);

            // Body skin
            UmaData.umaRecipe.slotDataList[2].AddOverlay(OverlayLibrary.InstantiateOverlay(MaleBodies[selectedMaleBody], SkinTones[selectedMaleSkinTone]));

            //Shirt
            if (MaleShirts[selectedMaleShirt] != "")
            {
                UmaData.umaRecipe.slotDataList[2].AddOverlay(OverlayLibrary.InstantiateOverlay(MaleShirts[selectedMaleShirt], ShirtColors[selectedMaleShirtColor]));
            }

            //Hands
            UmaData.umaRecipe.slotDataList[3] = SlotLibrary.InstantiateSlot(MaleHands[selectedMaleHands], UmaData.umaRecipe.slotDataList[2].GetOverlayList());

            //Inner mouth
            UmaData.umaRecipe.slotDataList[4] = SlotLibrary.InstantiateSlot("MaleInnerMouth");
            UmaData.umaRecipe.slotDataList[4].AddOverlay(OverlayLibrary.InstantiateOverlay("InnerMouth"));

            // Legs and underwear
            UmaData.umaRecipe.slotDataList[5] = SlotLibrary.InstantiateSlot(MaleLegs[selectedMaleLegs], UmaData.umaRecipe.slotDataList[2].GetOverlayList());
            //if (maleUnderwear[selectedMaleUnderwear] != "")
            //{
            UmaData.umaRecipe.slotDataList[2].AddOverlay(OverlayLibrary.InstantiateOverlay(MaleUnderwear[selectedMaleUnderwear], UnderwearColors[selectedMaleUnderwearColor]));
            //}

            // Pants
            if (MalePants[selectedMalePants] != "")
            {
                UmaData.umaRecipe.slotDataList[5] = SlotLibrary.InstantiateSlot(MalePants[selectedMalePants]);
                UmaData.umaRecipe.slotDataList[5].AddOverlay(OverlayLibrary.InstantiateOverlay(MalePants[selectedMalePants], PantsColors[selectedMalePantsColor]));
            }

            // Feet or shoes
            UmaData.umaRecipe.slotDataList[6] = SlotLibrary.InstantiateSlot(MaleFeet[selectedMaleFeet], UmaData.umaRecipe.slotDataList[2].GetOverlayList());


        }
        else if (SelectedGender == "Female")
        {

            // Eyeballs
            UmaData.umaRecipe.slotDataList[0] = SlotLibrary.InstantiateSlot(FemaleEyeballs[_selectedFemaleEyeballs]);
            UmaData.umaRecipe.slotDataList[0].AddOverlay(OverlayLibrary.InstantiateOverlay(EyeballTextures[_selectedFemaleEyeballTexture]));
            UmaData.umaRecipe.slotDataList[0].AddOverlay(OverlayLibrary.InstantiateOverlay(EyeballTexturesAdjust[_selectedFemaleEyeballTextureAdjust], EyeColors[_selectedFemaleEyeColor]));

            // Head Mesh
            UmaData.umaRecipe.slotDataList[1] = SlotLibrary.InstantiateSlot(FemaleHeadMeshes[_selectedFemaleHeadMesh]);

            // Head Texture
            UmaData.umaRecipe.slotDataList[1].AddOverlay(OverlayLibrary.InstantiateOverlay(FemaleHeadTextures[_selectedFemaleHeadTexture], SkinTones[_selectedFemaleSkinTone]));

            // Eyebrows
            UmaData.umaRecipe.slotDataList[1].AddOverlay(OverlayLibrary.InstantiateOverlay(FemaleEyebrows[_selectedFemaleEyebrow], HairColors[_selectedFemaleHairColor] * 0.05f));

            //Eyes
            UmaData.umaRecipe.slotDataList[7] = SlotLibrary.InstantiateSlot(FemaleEyesockets[_selectedFemaleEyesockets], UmaData.umaRecipe.slotDataList[1].GetOverlayList());

            // Ears
            UmaData.umaRecipe.slotDataList[8] = SlotLibrary.InstantiateSlot("FemaleHead_ElvenEars");
            UmaData.umaRecipe.slotDataList[8].AddOverlay(OverlayLibrary.InstantiateOverlay("ElvenEars", SkinColor));
            UmaData.umaRecipe.slotDataList[8] = SlotLibrary.InstantiateSlot(FemaleEars[_selectedFemaleEars], UmaData.umaRecipe.slotDataList[1].GetOverlayList());

            // Mouth
            UmaData.umaRecipe.slotDataList[9] = SlotLibrary.InstantiateSlot(FemaleMouths[_selectedFemaleMouth], UmaData.umaRecipe.slotDataList[1].GetOverlayList());
            UmaData.umaRecipe.slotDataList[9].AddOverlay(OverlayLibrary.InstantiateOverlay(LipstickTextures[_selectedFemaleLipstickTexture], LipstickColors[_selectedFemaleLipstickColor]));

            // Nose
            UmaData.umaRecipe.slotDataList[10] = SlotLibrary.InstantiateSlot(FemaleNoses[_selectedFemaleNose], UmaData.umaRecipe.slotDataList[1].GetOverlayList());


            // Eyelashes
            UmaData.umaRecipe.slotDataList[11] = SlotLibrary.InstantiateSlot("FemaleEyelash");
            UmaData.umaRecipe.slotDataList[11].AddOverlay(OverlayLibrary.InstantiateOverlay("FemaleEyelash", Color.black));

            // Torso mesh
            UmaData.umaRecipe.slotDataList[2] = SlotLibrary.InstantiateSlot(FemaleBodyMeshes[_selectedFemaleBodyMesh]);

            // Body skin
            UmaData.umaRecipe.slotDataList[2].AddOverlay(OverlayLibrary.InstantiateOverlay(FemaleBodies[_selectedFemaleBody], SkinTones[_selectedFemaleSkinTone]));

            // Hands
            UmaData.umaRecipe.slotDataList[3] = SlotLibrary.InstantiateSlot(FemaleHands[_selectedFemaleHands], UmaData.umaRecipe.slotDataList[2].GetOverlayList());

            //Inner mouth
            UmaData.umaRecipe.slotDataList[4] = SlotLibrary.InstantiateSlot("FemaleInnerMouth");
            UmaData.umaRecipe.slotDataList[4].AddOverlay(OverlayLibrary.InstantiateOverlay("InnerMouth"));

            // Legs
            UmaData.umaRecipe.slotDataList[5] = SlotLibrary.InstantiateSlot(FemaleLegs[_selectedFemaleLegs], UmaData.umaRecipe.slotDataList[2].GetOverlayList());

            // Underwear
            if (FemaleUnderwear[_selectedFemaleUnderwear] != "")
            {
                UmaData.umaRecipe.slotDataList[2].AddOverlay(OverlayLibrary.InstantiateOverlay(FemaleUnderwear[_selectedFemaleUnderwear], UnderwearColors[_selectedFemaleUnderwearColor]));
            }

            // Pants
            if (FemalePants[_selectedFemalePants] != "")
            {
                UmaData.umaRecipe.slotDataList[5].AddOverlay(OverlayLibrary.InstantiateOverlay(FemalePants[_selectedFemalePants], PantsColors[_selectedFemalePantsColor]));
            }

            // Feet or shoes
            UmaData.umaRecipe.slotDataList[6] = SlotLibrary.InstantiateSlot(FemaleFeet[_selectedFemaleFeet], UmaData.umaRecipe.slotDataList[2].GetOverlayList());

            // Shirt
            if (FemaleShirts[_selectedFemaleShirt] != "")
            {
                if (FemaleShirts[_selectedFemaleShirt] != "FemaleTshirt01")
                {
                    UmaData.umaRecipe.slotDataList[2].AddOverlay(OverlayLibrary.InstantiateOverlay(FemaleShirts[_selectedFemaleShirt], ShirtColors[_selectedFemaleShirtColor]));
                }
                else
                {
                    UmaData.umaRecipe.slotDataList[14] = SlotLibrary.InstantiateSlot(FemaleShirts[_selectedFemaleShirt]);
                    UmaData.umaRecipe.slotDataList[14].AddOverlay(OverlayLibrary.InstantiateOverlay(FemaleShirts[_selectedFemaleShirt], ShirtColors[_selectedFemaleShirtColor]));
                }
            }

            // Hair (mesh)
            if (FemaleHairStyles[_selectedFemaleHairStyle] != "")
            {
                if (FemaleHairStyles[_selectedFemaleHairStyle] != "FemaleLongHair01_Module")
                {
                    UmaData.umaRecipe.slotDataList[12] = SlotLibrary.InstantiateSlot(FemaleHairStyles[_selectedFemaleHairStyle], UmaData.umaRecipe.slotDataList[1].GetOverlayList());
                    UmaData.umaRecipe.slotDataList[1].AddOverlay(OverlayLibrary.InstantiateOverlay(FemaleHairStyles[_selectedFemaleHairStyle], HairColors[_selectedFemaleHairColor]));
                }
                else
                {
                    UmaData.umaRecipe.slotDataList[12] = SlotLibrary.InstantiateSlot("FemaleLongHair01", UmaData.umaRecipe.slotDataList[1].GetOverlayList());
                    UmaData.umaRecipe.slotDataList[1].AddOverlay(OverlayLibrary.InstantiateOverlay("FemaleLongHair01", HairColors[_selectedFemaleHairColor]));
                    UmaData.umaRecipe.slotDataList[13] = SlotLibrary.InstantiateSlot("FemaleLongHair01_Module");
                    UmaData.umaRecipe.slotDataList[13].AddOverlay(OverlayLibrary.InstantiateOverlay("FemaleLongHair01_Module", HairColors[_selectedFemaleHairColor]));
                }
            }
        }
    }

    void UmaData_OnUpdated(UMAData obj)
    {

    }
}
