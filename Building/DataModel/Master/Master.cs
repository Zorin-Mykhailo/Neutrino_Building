﻿namespace Building.DataModel.Master;
public class Master : Entity
{
    public DateTime CreationTime { get; private set; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public MasterType MasterType { get; set; } = MasterType.General;
    public const string Phrase = "I can fix anything!";
    public readonly long PhoneNumber;

    public Master(int id) : base(id)
    {
        CreationTime = DateTime.Now;
    }

    public Master(int id, DateTime creationTime) : base(id)
    {
        CreationTime = creationTime;
    }

    //several error types
    public override string ToString()
    {
        try
        {
            while (true)  return $"{base.ToString()} 📝 {CreationTime:yyyy.MM.dd(ddd) HH:mm} -- {FirstName} {LastName} -- from {Email} -- {MasterType.AsStr()}";
        }
        catch (StackOverflowException ex)
        {
            return $"Oops! You did too much: {ex}";
        }
        catch (Exception ex)
        {
            return $"Oops! You will never ever rich this exception :) {ex}";
        }

    }

    //try catch inside of try catch, one stacktrace is overriden
    public string GetInfo(int experience)
    {
        try
        {
            Console.WriteLine("Trying to get info");

            try
            {
                throw new ArgumentNullException("Some incorrect text");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A custom made error was caughtю \n {ex.StackTrace}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            throw new Exception($"Some overriden incorrect text \n{e.StackTrace}");
        }
        return $"I'm a {MasterType} with {experience} of experience.";
    }

    public string GetInfo(int experience, int age)
    {
        return $"I'm a {age}-year old {MasterType} with {experience} of experience.";
    }
}

