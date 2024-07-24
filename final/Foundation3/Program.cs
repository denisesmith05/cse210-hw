using System;
using System.Collections.Generic;

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public override string ToString()
    {
        return $"{_street}, {_city}, {_state}, {_country}";
    }
}

public class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public virtual string StandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address}";
    }

    public virtual string FullDetails()
    {
        return StandardDetails();
    }

    public virtual string ShortDescription()
    {
        return $"{GetType().Name} Event: {_title} on {_date}";
    }
}

public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string FullDetails()
    {
        return $"{base.FullDetails()}\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }
}

public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string FullDetails()
    {
        return $"{base.FullDetails()}\nRSVP Email: {_rsvpEmail}";
    }
}

public class OutdoorGathering : Event
{
    private string _weather;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        _weather = weather;
    }

    public override string FullDetails()
    {
        return $"{base.FullDetails()}\nWeather: {_weather}";
    }
}

public class Program
{
    public static void Main()
    {
        var address = new Address("789 Park Ave", "New York", "NY", "USA");

        var lecture = new Lecture("Tech Talk", "A talk on the latest in tech", "01 Aug 2024", "10:00 AM", address, "John Tech", 100);
        var reception = new Reception("Networking Event", "An event to network with peers", "02 Aug 2024", "6:00 PM", address, "rsvp@event.com");
        var outdoorGathering = new OutdoorGathering("Summer BBQ", "A fun BBQ event", "03 Aug 2024", "12:00 PM", address, "Sunny");

        var events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (var evt in events)
        {
            Console.WriteLine(evt.StandardDetails());
            Console.WriteLine(evt.FullDetails());
            Console.WriteLine(evt.ShortDescription());
            Console.WriteLine();
        }
    }
}