using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("C# Basics", "TechTutor", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Carol", "Clear and concise."));
        videos.Add(video1);

        // Create Video 2
        Video video2 = new Video("Unity Game Dev", "GameGuru", 1200);
        video2.AddComment(new Comment("Dave", "I learned a lot."));
        video2.AddComment(new Comment("Eve", "Could you do a follow-up?"));
        video2.AddComment(new Comment("Frank", "Awesome content!"));
        videos.Add(video2);

        // Create Video 3
        Video video3 = new Video("How to Cook Jollof", "ChefKwame", 900);
        video3.AddComment(new Comment("Gifty", "Yummy! Trying this tonight."));
        video3.AddComment(new Comment("Kwabena", "Love Ghanaian food!"));
        video3.AddComment(new Comment("Ama", "More recipes, please."));
        videos.Add(video3);

        // Display video details and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
