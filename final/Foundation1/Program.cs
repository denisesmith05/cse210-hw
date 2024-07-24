using System;
using System.Collections.Generic;

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} minutes");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine(comment);
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Tutorial", "John Doe", 20);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful."));
        video1.AddComment(new Comment("Charlie", "Thanks for the tips."));
        videos.Add(video1);

        Video video2 = new Video("Cooking Pasta", "Jane Smith", 12);
        video2.AddComment(new Comment("Dave", "Looks delicious!"));
        video2.AddComment(new Comment("Eve", "Can't wait to try this."));
        video2.AddComment(new Comment("Frank", "Yummy!"));
        videos.Add(video2);

        Video video3 = new Video("How to Make Cloud Slime", "Sandy Lee", 7);
        video3.AddComment(new Comment("Wanda", "Such a fun activity for the kids!"));
        video3.AddComment(new Comment("Kara", "So pretty!"));
        video3.AddComment(new Comment("Harry", "Very soft and relaxing."));
        videos.Add(video3);

        Video video4 = new Video("Is the earth really round?", "Shia Kensy", 23);
        video4.AddComment(new Comment("Daryll", "Seems pretty round to me!"));
        video4.AddComment(new Comment("Lilly", "Super interesting!"));
        video4.AddComment(new Comment("Carl", "I'd love hear more about this in future videos."));
        videos.Add(video4);

        foreach (var video in videos)
        {
            video.Display();
        }
    }
}