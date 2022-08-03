using UnityEngine;

public class BuildingWorkshopButtonsUI : MonoBehaviour
{
    private BuildingWorkshop _buildingWorkshop;

    private void Awake()
    {
        _buildingWorkshop = GetComponentInParent<BuildingWorkshop>();
    }

    public void SetToolTypePitchfork()
    {
        _buildingWorkshop.ToolType = ToolType.Pitchfork;
    }

    public void SetToolTypeHammer()
    {
        _buildingWorkshop.ToolType = ToolType.Hammer;
    }

    public void SetToolTypeSword()
    {
        _buildingWorkshop.ToolType = ToolType.Sword;
    }

    public void SetToolTypeBow()
    {
        _buildingWorkshop.ToolType = ToolType.Bow;
    }
}
