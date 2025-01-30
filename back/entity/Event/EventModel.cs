namespace meero.entity;
public class EventModel
{
    public required string Title {get;set;}
    public string? Description {get;set;}

    public required DateTime Date {get;set;}

    public required int Duration {get;set;}
}