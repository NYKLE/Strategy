public interface ISelectable
{
    void OnSelect();
    void OnDeselect();
    private void OnEnable()
    {
        Events.Cursor.onDeselect += OnDeselect;
    }

    private void OnDisable()
    {
        Events.Cursor.onDeselect -= OnDeselect;
    }
}
