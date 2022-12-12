namespace VisitorPlacementTool.ConsoleApp;

public class Event
{
    public DateTime EventDate { get; private set; }
    private DateTime _signupEndDate;
    public List<List<Visitor>> ListOfGroups = new List<List<Visitor>>();
    public List<Visitor> FilteredVisitorList = new List<Visitor>();
    private int _maxVisitors;
    
    public Event(DateTime eventDate, int maxVisitors)
    {
        EventDate = eventDate;
        _signupEndDate = eventDate.AddDays(-7);
        _maxVisitors = maxVisitors;
    }
    
    public void AddGroup(List<Visitor> group)
    {
        ListOfGroups.Add(group);
    }
    
    public List<Visitor> FilterVisitors(List<List<Visitor>> listOfGroups)
    {
        List<Visitor> FullVisitorList = listOfGroups.SelectMany(x => x).OrderBy(x => x.RegistrationTime).ToList();;
        for (int i = 0; i < _maxVisitors; i++)
        {
            if (FullVisitorList[i].RegistrationTime < _signupEndDate)
            {
                FilteredVisitorList.Add(FullVisitorList[i]);
            }
        }
        
        return FilteredVisitorList;
    }
}