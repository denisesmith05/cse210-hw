using System;
using System.Collections.Generic;

public class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public override string ToString()
    {
        return $"{_name}: {_text}";
    }
}

public class Video
{
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in _comments)
        {
            Console.WriteLine(comment);
        }
    }
}

public class Program
{
    public static void Main()
    {
        var video1 = new Video("Introduction to C#", "John Doe", 300);
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Thanks for the tips."));
        
        var video2 = new Video("Advanced C# Techniques", "Jane Smith", 450);
        video2.AddComment(new Comment("Charlie", "Loved the advanced topics."));
        video2.AddComment(new Comment("Dave", "Learned a lot!"));
        video2.AddComment(new Comment("Frank", "Yummy!"));

        var video3 = new Video("How to Make Cloud Slime", "Sandy Lee", 7);
        video3.AddComment(new Comment("Wanda", "Such a fun activity for the kids!"));
        video3.AddComment(new Comment("Kara", "So pretty!"));
        video3.AddComment(new Comment("Harry", "Very soft and relaxing."));

        var video4 = new Video("Is the earth really round?", "Shia Kensy", 23);
        video4.AddComment(new Comment("Daryll", "Seems pretty round to me!"));
        video4.AddComment(new Comment("Lilly", "Super interesting!"));
        video4.AddComment(new Comment("Carl", "I'd love hear more about this in future videos."));
        
        var videos = new List<Video> { video1, video2, video3, video4 };

        foreach (var video in videos)
        {
            video.Display();
            Console.WriteLine();
        }
    }
}
